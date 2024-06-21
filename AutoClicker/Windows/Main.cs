using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using AutoClicker.Helpers;
using AutoClicker.Objects;
using AutoClicker.Windows;
using Newtonsoft.Json;

namespace AutoClicker
{
    public partial class Main : Form
    {
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

        bool isStopped = false;

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            isStopped = false;
            toolStripProgressBar.Maximum = (int)numericUpDownRepeat.Value;
            toolStripProgressBar.Value = 0;

            Stopwatch stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < numericUpDownRepeat.Value; i++)
            {
                toolStripStatusLabel.Text = $"Running iteration: {i + 1} / {numericUpDownRepeat.Value}";
                statusStrip.Update(); //Update label

                foreach (object item in listBoxQueue.Items)
                {
                    if (isStopped)
                    {
                        return;
                    }

                    if (item is IBaseEvent baseEvent)
                    {
                        baseEvent.PerformAction(); //Todo: this might have to be async
                    }
                }

                toolStripProgressBar.Value++;
                statusStrip.Update(); //Update progress bar
            }

            toolStripStatusLabel.Text = $"Finished! {numericUpDownRepeat.Value} / {numericUpDownRepeat.Value} (elapsed: {stopwatch.Elapsed})";
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            isStopped = true;
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

            listBoxQueue.Items.Clear();

            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "json files (*.json)|*.json";
                dialog.RestoreDirectory = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
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
    }
}
