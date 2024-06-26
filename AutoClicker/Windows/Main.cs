using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
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
        //Todo: save target program's window position and allow adjusting all absolute coordinates to compensate
        //  - We may even want an addition CoordinateSystem option of "Relative to Window" so it works regardless of where the window is
        //Todo: allow re-arrange queue list (at a minimum: up & down arrows)
        //Todo: maybe use native GetCursorPos and SetCursorPos instead of Cursor.Postion (maybe this is more reliable?)
        //Todo: maybe allow keyboard input
        //Todo: maybe add a hook for listening for keyboard events and stop running actions after Esc (or maybe 3x Esc) is pressed
        //    (because moving the cursor to the "stop" button could be hard while the program is running)

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            MouseLocationHelper.Init();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddEditEventDialog addEditEventDialog = new AddEditEventDialog(null);
            addEditEventDialog.ResultEventAction += result => listBoxQueue.Items.Add(result);
            addEditEventDialog.ShowDialog();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            listBoxQueue.Items.RemoveAt(listBoxQueue.SelectedIndex);
        }

        bool isStopped = false; //Todo: convert to CancellationToken

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            isStopped = false;
            toolStripProgressBar.Maximum = (int)numericUpDownRepeat.Value;
            toolStripProgressBar.Value = 0;

            Stopwatch stopwatch = Stopwatch.StartNew();

            List<IBaseEvent> queuedActions = listBoxQueue.Items.Cast<IBaseEvent>().ToList();

            for (int i = 0; i < numericUpDownRepeat.Value; i++)
            {
                toolStripStatusLabel.Text = $"Running iteration: {i + 1} / {numericUpDownRepeat.Value}";
                statusStrip.Update(); //Update label

                foreach (IBaseEvent action in queuedActions)
                {
                    if (isStopped)
                    {
                        return;
                    }

                    listBoxQueue.SelectedItem = action;

                    action.PerformAction(); //Todo: this needs to be async
                }

                toolStripProgressBar.Value++;
                statusStrip.Update(); //Update progress bar
            }

            listBoxQueue.SelectedItem = null;
            toolStripStatusLabel.Text = $"Finished! {numericUpDownRepeat.Value} / {numericUpDownRepeat.Value} (elapsed: {stopwatch.Elapsed})";
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            isStopped = true; //Todo: this doesn't work because the Thread.Sleep blocks the UI thread
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
                    File.WriteAllText(dialog.FileName, JsonConvert.SerializeObject(listBoxQueue.Items, new JsonSerializerSettings
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

                    List<IBaseEvent> actions = JsonConvert.DeserializeObject<List<IBaseEvent>>(File.ReadAllText(dialog.FileName), new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.Objects,
                    });

                    foreach (IBaseEvent action in actions)
                    {
                        listBoxQueue.Items.Add(action);
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
    }
}
