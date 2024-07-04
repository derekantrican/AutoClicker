using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoClicker.Helpers;
using AutoClicker.Objects;
using AutoClicker.Windows;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AutoClicker
{
    public partial class Main : Form
    {
        //Todo: maybe use native GetCursorPos and SetCursorPos instead of Cursor.Postion (maybe this is more reliable?)
        //Todo: maybe allow keyboard input
        //Todo: maybe add a hook for listening for keyboard events and stop running actions after Esc (or maybe 3x Esc) is pressed
        //    (because moving the cursor to the "stop" button could be hard while the program is running)
        //Todo: add a "Image Validation" or similar action that will check a certain section on the screen against a reference image and stop the program if there isn't a match

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            MouseLocationHelper.Init();
        }

        bool isStopped = false; //Todo: convert to CancellationToken

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            buttonPlay.Enabled = false;
            isStopped = false;
            toolStripProgressBar.Maximum = (int)numericUpDownRepeat.Value;
            toolStripProgressBar.Value = 0;

            Task.Run(() =>
            {
                Stopwatch stopwatch = Stopwatch.StartNew();

                List<IBaseEvent> queuedActions = listBoxQueue.Items.Cast<IBaseEvent>().ToList();

                for (int i = 0; i < numericUpDownRepeat.Value; i++)
                {
                    UpdateControlOnUI(statusStrip, () =>
                    { 
                        toolStripStatusLabel.Text = $"Running iteration: {i + 1} / {numericUpDownRepeat.Value}";
                        statusStrip.Update(); 
                    });

                    foreach (IBaseEvent action in queuedActions)
                    {
                        if (isStopped)
                        {
                            UpdateControlOnUI(statusStrip, () =>
                            {
                                toolStripStatusLabel.Text = $"Stopped! {i} / {numericUpDownRepeat.Value} (elapsed: {stopwatch.Elapsed})";
                                statusStrip.Update();
                            });

                            UpdateControlOnUI(listBoxQueue, () => listBoxQueue.SelectedItem = null);
                            UpdateControlOnUI(buttonPlay, () => buttonPlay.Enabled = true);
                            return;
                        }

                        UpdateControlOnUI(listBoxQueue, () => listBoxQueue.SelectedItem = action);

                        action.PerformAction();
                    }

                    UpdateControlOnUI(statusStrip, () =>
                    {
                        toolStripProgressBar.Value++;
                        statusStrip.Update();
                    });
                }

                UpdateControlOnUI(statusStrip, () =>
                {
                    toolStripStatusLabel.Text = $"Finished! {numericUpDownRepeat.Value} / {numericUpDownRepeat.Value} (elapsed: {stopwatch.Elapsed})";
                    statusStrip.Update();
                });
                UpdateControlOnUI(listBoxQueue, () => listBoxQueue.SelectedItem = null);
                UpdateControlOnUI(buttonPlay, () => buttonPlay.Enabled = true);
            });
        }

        private void UpdateControlOnUI(Control control, Action action)
        {
            control.Invoke((MethodInvoker)delegate
            {
                action();
            });
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            isStopped = true;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddEditEventDialog addEditEventDialog = new AddEditEventDialog(null);
            addEditEventDialog.ResultEventAction += result => listBoxQueue.Items.Add(result);
            addEditEventDialog.ShowDialog();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (listBoxQueue.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an item in the list to remove");
                return;
            }

            listBoxQueue.Items.RemoveAt(listBoxQueue.SelectedIndex);
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            if (listBoxQueue.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an item in the list to move");
                return;
            }

            int targetIndex = listBoxQueue.SelectedIndex == 0 ? 0 : listBoxQueue.SelectedIndex - 1;
            object targetItem = listBoxQueue.SelectedItem;

            listBoxQueue.Items.RemoveAt(listBoxQueue.SelectedIndex);
            listBoxQueue.Items.Insert(targetIndex, targetItem);

            listBoxQueue.SelectedIndex = targetIndex; //Re-select the item
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            if (listBoxQueue.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an item in the list to move");
                return;
            }

            int targetIndex = listBoxQueue.SelectedIndex == listBoxQueue.Items.Count - 1 ? listBoxQueue.Items.Count - 1 : listBoxQueue.SelectedIndex + 1;
            object targetItem = listBoxQueue.SelectedItem;

            listBoxQueue.Items.RemoveAt(listBoxQueue.SelectedIndex);
            listBoxQueue.Items.Insert(targetIndex, targetItem);

            listBoxQueue.SelectedIndex = targetIndex; //Re-select the item
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "json files (*.json)|*.json";
                dialog.Title = "Choose where to save your file";
                dialog.ShowDialog();

                if (!string.IsNullOrEmpty(dialog.FileName))
                {
                    //Todo: if no target window is selected, we should grab the window from the first click location and save its current position & size
                    SavedWindow savedWindow = comboBoxWindowList.SelectedItem == null ? null : new SavedWindow
                    {
                        Title = (comboBoxWindowList.SelectedItem as WindowInfo).Process.MainWindowTitle,
                        Bounds = (comboBoxWindowList.SelectedItem as WindowInfo).GetBounds(), //Calling GetBounds again ensures that we have the latest bounds for the window
                    };

                    File.WriteAllText(dialog.FileName, JsonConvert.SerializeObject(new SaveData
                    {
                        TargetWindow = savedWindow,
                        Actions = listBoxQueue.Items.Cast<IBaseEvent>().ToList(),
                    }, 
                    new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.Objects,
                        TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
                        Formatting = Formatting.Indented,
                        Converters = new List<JsonConverter>
                        {
                            new StringEnumConverter()
                        },
                    }));
                }
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (listBoxQueue.Items.Count > 0)
            {
                DialogResult result = MessageBox.Show("This will clear your current queue of actions. Are you sure?", "Warning", MessageBoxButtons.YesNo);

                if (result != DialogResult.Yes)
                {
                    return;
                }
            }

            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "json files (*.json)|*.json";
                dialog.RestoreDirectory = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    listBoxQueue.Items.Clear();

                    SaveData saveData = JsonConvert.DeserializeObject<SaveData>(File.ReadAllText(dialog.FileName), new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.Objects,
                    });

                    foreach (IBaseEvent action in saveData.Actions)
                    {
                        listBoxQueue.Items.Add(action);
                    }

                    if (checkBoxRestoreWindow.Checked && saveData.TargetWindow != null)
                    {
                        buttonRefresh_Click(null, null); //Refresh list of open windows

                        List<WindowInfo> windowList = comboBoxWindowList.Items.Cast<WindowInfo>().ToList();
                        WindowInfo matchingTargetWindow = windowList.Find(w => w.Process.MainWindowTitle == saveData.TargetWindow.Title);
                        //Todo: attempt to find by process name or something better if title doesn't work
                        //Todo: warn if there are multiple matching windows found
                        if (matchingTargetWindow == null)
                        {
                            MessageBox.Show($"Can't find a matching window for saved target window '{saveData.TargetWindow.Title}'", "Target window not found (by title)");
                        }
                        else
                        {
                            comboBoxWindowList.SelectedItem = matchingTargetWindow;

                            if (matchingTargetWindow.GetBounds().ToString() != saveData.TargetWindow.Bounds.ToString()) //ToString is not "technically proper" but is the easiest
                            {
                                DialogResult result = MessageBox.Show($"The postion or size for '{saveData.TargetWindow.Title}' is not the same as last time. Adjust the target window to match saved position & size?\n" +
                                    $"\nSaved: {saveData.TargetWindow.Bounds}" +
                                    $"\nCurrent: {matchingTargetWindow.GetBounds()}",
                                    "Target window size/position not the same",
                                    MessageBoxButtons.YesNo);

                                if (result == DialogResult.Yes)
                                {
                                    Rect savedBounds = saveData.TargetWindow.Bounds;
                                    //Todo: maybe check if (Left, Top) will put the Window off the screen & warn

                                    matchingTargetWindow.AdjustWindowBounds(savedBounds);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void checkBoxDisplayMouseLoc_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDisplayMouseLoc.Checked)
            {
                MouseLocationHelper.LocationChangeCallback += MouseLocationUpdate;
            }
            else
            {
                MouseLocationHelper.LocationChangeCallback -= MouseLocationUpdate;
            }
        }

        private void MouseLocationUpdate(Point p)
        {
            toolStripStatusLabelMouseLoc.Text = $"Mouse Location: {p.X}, {p.Y}";
            statusStrip.Update();
        }

        private void listBoxQueue_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = listBoxQueue.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                AddEditEventDialog editDialog = new AddEditEventDialog(listBoxQueue.Items[index] as IBaseEvent);
                editDialog.ResultEventAction += result =>
                {
                    listBoxQueue.Items.RemoveAt(index);
                    listBoxQueue.Items.Insert(index, result);
                };
                editDialog.ShowDialog();
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            comboBoxWindowList.Items.Clear();
            comboBoxWindowList.Items.AddRange(Process.GetProcesses().Where(p => !string.IsNullOrEmpty(p.MainWindowTitle)).Select(p => new WindowInfo(p)).ToArray());
            UpdateComboboxDropDownWidth(comboBoxWindowList);
        }

        //https://stackoverflow.com/a/4842576
        private void UpdateComboboxDropDownWidth(ComboBox comboBox)
        {
            int maxWidth = 0;
            int temp = 0;
            Label label1 = new Label();

            foreach (var obj in comboBox.Items)
            {
                label1.Text = obj.ToString();
                temp = label1.PreferredWidth;
                if (temp > maxWidth)
                {
                    maxWidth = temp;
                }
            }

            label1.Dispose();

            comboBox.DropDownWidth = maxWidth;
        }

        private void comboBoxWindowList_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBoxWindowList.SelectedItem != null && comboBoxWindowList.SelectedItem is WindowInfo windowInfo)
            {
                labelWindowInfo.Text = windowInfo.GetBounds().ToString();
            }
        }
    }
}
