namespace AutoClicker
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.buttonPlay = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.listBoxQueue = new System.Windows.Forms.ListBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelMouseLoc = new System.Windows.Forms.ToolStripStatusLabel();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.labelRepeat = new System.Windows.Forms.Label();
            this.numericUpDownRepeat = new System.Windows.Forms.NumericUpDown();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.checkBoxDisplayMouseLoc = new System.Windows.Forms.CheckBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageActions = new System.Windows.Forms.TabPage();
            this.buttonDown = new System.Windows.Forms.Button();
            this.buttonUp = new System.Windows.Forms.Button();
            this.tabPageSettings = new System.Windows.Forms.TabPage();
            this.groupBoxWindow = new System.Windows.Forms.GroupBox();
            this.checkBoxRestoreWindow = new System.Windows.Forms.CheckBox();
            this.labelWindowInfo = new System.Windows.Forms.Label();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.comboBoxWindowList = new System.Windows.Forms.ComboBox();
            this.labelEscTip = new System.Windows.Forms.Label();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRepeat)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPageActions.SuspendLayout();
            this.tabPageSettings.SuspendLayout();
            this.groupBoxWindow.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonPlay
            // 
            this.buttonPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPlay.Location = new System.Drawing.Point(2, 4);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(43, 50);
            this.buttonPlay.TabIndex = 1;
            this.buttonPlay.Text = "▶️";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStop.Location = new System.Drawing.Point(51, 4);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(43, 50);
            this.buttonStop.TabIndex = 2;
            this.buttonStop.Text = "⏹️";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // listBoxQueue
            // 
            this.listBoxQueue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxQueue.FormattingEnabled = true;
            this.listBoxQueue.Location = new System.Drawing.Point(3, 33);
            this.listBoxQueue.Name = "listBoxQueue";
            this.listBoxQueue.Size = new System.Drawing.Size(498, 303);
            this.listBoxQueue.TabIndex = 3;
            this.listBoxQueue.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxQueue_MouseDoubleClick);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar,
            this.toolStripStatusLabel,
            this.toolStripStatusLabelMouseLoc});
            this.statusStrip.Location = new System.Drawing.Point(0, 439);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(514, 22);
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(397, 17);
            this.toolStripStatusLabel.Spring = true;
            // 
            // toolStripStatusLabelMouseLoc
            // 
            this.toolStripStatusLabelMouseLoc.Name = "toolStripStatusLabelMouseLoc";
            this.toolStripStatusLabelMouseLoc.Size = new System.Drawing.Size(0, 17);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(6, 6);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(70, 23);
            this.buttonAdd.TabIndex = 5;
            this.buttonAdd.Text = "+ Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(82, 6);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(70, 23);
            this.buttonRemove.TabIndex = 6;
            this.buttonRemove.Text = "- Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // labelRepeat
            // 
            this.labelRepeat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelRepeat.AutoSize = true;
            this.labelRepeat.Location = new System.Drawing.Point(433, 9);
            this.labelRepeat.Name = "labelRepeat";
            this.labelRepeat.Size = new System.Drawing.Size(42, 13);
            this.labelRepeat.TabIndex = 7;
            this.labelRepeat.Text = "Repeat";
            // 
            // numericUpDownRepeat
            // 
            this.numericUpDownRepeat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownRepeat.Location = new System.Drawing.Point(436, 27);
            this.numericUpDownRepeat.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.numericUpDownRepeat.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownRepeat.Name = "numericUpDownRepeat";
            this.numericUpDownRepeat.Size = new System.Drawing.Size(66, 20);
            this.numericUpDownRepeat.TabIndex = 8;
            this.numericUpDownRepeat.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Location = new System.Drawing.Point(452, 7);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(46, 23);
            this.buttonSave.TabIndex = 9;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLoad.Location = new System.Drawing.Point(400, 7);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(46, 23);
            this.buttonLoad.TabIndex = 10;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // checkBoxDisplayMouseLoc
            // 
            this.checkBoxDisplayMouseLoc.AutoSize = true;
            this.checkBoxDisplayMouseLoc.Location = new System.Drawing.Point(6, 6);
            this.checkBoxDisplayMouseLoc.Name = "checkBoxDisplayMouseLoc";
            this.checkBoxDisplayMouseLoc.Size = new System.Drawing.Size(149, 30);
            this.checkBoxDisplayMouseLoc.TabIndex = 11;
            this.checkBoxDisplayMouseLoc.Text = "Display mouse location\r\nin status bar when clicked";
            this.checkBoxDisplayMouseLoc.UseVisualStyleBackColor = true;
            this.checkBoxDisplayMouseLoc.CheckedChanged += new System.EventHandler(this.checkBoxDisplayMouseLoc_CheckedChanged);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPageActions);
            this.tabControl.Controls.Add(this.tabPageSettings);
            this.tabControl.Location = new System.Drawing.Point(2, 60);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(512, 379);
            this.tabControl.TabIndex = 12;
            // 
            // tabPageActions
            // 
            this.tabPageActions.Controls.Add(this.buttonDown);
            this.tabPageActions.Controls.Add(this.buttonUp);
            this.tabPageActions.Controls.Add(this.listBoxQueue);
            this.tabPageActions.Controls.Add(this.buttonRemove);
            this.tabPageActions.Controls.Add(this.buttonLoad);
            this.tabPageActions.Controls.Add(this.buttonSave);
            this.tabPageActions.Controls.Add(this.buttonAdd);
            this.tabPageActions.Location = new System.Drawing.Point(4, 22);
            this.tabPageActions.Name = "tabPageActions";
            this.tabPageActions.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageActions.Size = new System.Drawing.Size(504, 342);
            this.tabPageActions.TabIndex = 0;
            this.tabPageActions.Text = "Actions";
            this.tabPageActions.UseVisualStyleBackColor = true;
            // 
            // buttonDown
            // 
            this.buttonDown.Location = new System.Drawing.Point(190, 7);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(26, 23);
            this.buttonDown.TabIndex = 12;
            this.buttonDown.Text = "⬇️";
            this.buttonDown.UseVisualStyleBackColor = true;
            this.buttonDown.Click += new System.EventHandler(this.buttonDown_Click);
            // 
            // buttonUp
            // 
            this.buttonUp.Location = new System.Drawing.Point(158, 7);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(26, 23);
            this.buttonUp.TabIndex = 11;
            this.buttonUp.Text = "⬆";
            this.buttonUp.UseVisualStyleBackColor = true;
            this.buttonUp.Click += new System.EventHandler(this.buttonUp_Click);
            // 
            // tabPageSettings
            // 
            this.tabPageSettings.Controls.Add(this.groupBoxWindow);
            this.tabPageSettings.Controls.Add(this.checkBoxDisplayMouseLoc);
            this.tabPageSettings.Location = new System.Drawing.Point(4, 22);
            this.tabPageSettings.Name = "tabPageSettings";
            this.tabPageSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSettings.Size = new System.Drawing.Size(504, 353);
            this.tabPageSettings.TabIndex = 1;
            this.tabPageSettings.Text = "Settings";
            this.tabPageSettings.UseVisualStyleBackColor = true;
            // 
            // groupBoxWindow
            // 
            this.groupBoxWindow.Controls.Add(this.checkBoxRestoreWindow);
            this.groupBoxWindow.Controls.Add(this.labelWindowInfo);
            this.groupBoxWindow.Controls.Add(this.buttonRefresh);
            this.groupBoxWindow.Controls.Add(this.comboBoxWindowList);
            this.groupBoxWindow.Location = new System.Drawing.Point(6, 42);
            this.groupBoxWindow.Name = "groupBoxWindow";
            this.groupBoxWindow.Size = new System.Drawing.Size(249, 109);
            this.groupBoxWindow.TabIndex = 12;
            this.groupBoxWindow.TabStop = false;
            this.groupBoxWindow.Text = "Target Window";
            // 
            // checkBoxRestoreWindow
            // 
            this.checkBoxRestoreWindow.AutoSize = true;
            this.checkBoxRestoreWindow.Location = new System.Drawing.Point(9, 70);
            this.checkBoxRestoreWindow.Name = "checkBoxRestoreWindow";
            this.checkBoxRestoreWindow.Size = new System.Drawing.Size(236, 30);
            this.checkBoxRestoreWindow.TabIndex = 14;
            this.checkBoxRestoreWindow.Text = "Check target window position & size on action\r\nlist load";
            this.checkBoxRestoreWindow.UseVisualStyleBackColor = true;
            // 
            // labelWindowInfo
            // 
            this.labelWindowInfo.AutoSize = true;
            this.labelWindowInfo.Location = new System.Drawing.Point(6, 43);
            this.labelWindowInfo.Name = "labelWindowInfo";
            this.labelWindowInfo.Size = new System.Drawing.Size(0, 13);
            this.labelWindowInfo.TabIndex = 13;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRefresh.Location = new System.Drawing.Point(133, 17);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(23, 25);
            this.buttonRefresh.TabIndex = 1;
            this.buttonRefresh.Text = "🔄";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // comboBoxWindowList
            // 
            this.comboBoxWindowList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWindowList.FormattingEnabled = true;
            this.comboBoxWindowList.Location = new System.Drawing.Point(6, 19);
            this.comboBoxWindowList.Name = "comboBoxWindowList";
            this.comboBoxWindowList.Size = new System.Drawing.Size(121, 21);
            this.comboBoxWindowList.TabIndex = 0;
            this.comboBoxWindowList.SelectedValueChanged += new System.EventHandler(this.comboBoxWindowList_SelectedValueChanged);
            // 
            // labelEscTip
            // 
            this.labelEscTip.AutoSize = true;
            this.labelEscTip.ForeColor = System.Drawing.Color.Red;
            this.labelEscTip.Location = new System.Drawing.Point(100, 9);
            this.labelEscTip.Name = "labelEscTip";
            this.labelEscTip.Size = new System.Drawing.Size(162, 13);
            this.labelEscTip.TabIndex = 13;
            this.labelEscTip.Text = "Press Esc 3x within 5 sec to stop";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 461);
            this.Controls.Add(this.labelEscTip);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.numericUpDownRepeat);
            this.Controls.Add(this.labelRepeat);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonPlay);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(400, 500);
            this.Name = "Main";
            this.Text = "AutoClicker";
            this.Load += new System.EventHandler(this.Main_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRepeat)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPageActions.ResumeLayout(false);
            this.tabPageSettings.ResumeLayout(false);
            this.tabPageSettings.PerformLayout();
            this.groupBoxWindow.ResumeLayout(false);
            this.groupBoxWindow.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.ListBox listBoxQueue;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.Label labelRepeat;
        private System.Windows.Forms.NumericUpDown numericUpDownRepeat;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelMouseLoc;
        private System.Windows.Forms.CheckBox checkBoxDisplayMouseLoc;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageActions;
        private System.Windows.Forms.TabPage tabPageSettings;
        private System.Windows.Forms.GroupBox groupBoxWindow;
        private System.Windows.Forms.ComboBox comboBoxWindowList;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Label labelWindowInfo;
        private System.Windows.Forms.CheckBox checkBoxRestoreWindow;
        private System.Windows.Forms.Button buttonDown;
        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.Label labelEscTip;
    }
}

