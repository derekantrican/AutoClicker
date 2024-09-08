namespace AutoClicker.Windows
{
    partial class AddEditEventDialog
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
			AutoClicker.Objects.ImpreciseLocation impreciseLocation1 = new AutoClicker.Objects.ImpreciseLocation();
			AutoClicker.Objects.ImpreciseLocation impreciseLocation2 = new AutoClicker.Objects.ImpreciseLocation();
			AutoClicker.Objects.ImpreciseLocation impreciseLocation3 = new AutoClicker.Objects.ImpreciseLocation();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEditEventDialog));
			this.labelDuration = new System.Windows.Forms.Label();
			this.numericUpDownDurationMs = new System.Windows.Forms.NumericUpDown();
			this.labelMs = new System.Windows.Forms.Label();
			this.panelMouseMoveEvent = new System.Windows.Forms.Panel();
			this.panelWaitEvent = new System.Windows.Forms.Panel();
			this.labelVar = new System.Windows.Forms.Label();
			this.numericUpDownVarMs = new System.Windows.Forms.NumericUpDown();
			this.labelVarMs = new System.Windows.Forms.Label();
			this.comboBoxMouseButton = new System.Windows.Forms.ComboBox();
			this.labelMouseButton = new System.Windows.Forms.Label();
			this.panelClickEvent = new System.Windows.Forms.Panel();
			this.labelEventType = new System.Windows.Forms.Label();
			this.comboBoxEventType = new System.Windows.Forms.ComboBox();
			this.buttonSave = new System.Windows.Forms.Button();
			this.panelImageValidation = new System.Windows.Forms.Panel();
			this.labelImageAreaSize = new System.Windows.Forms.Label();
			this.textBoxCheckAreaHeight = new System.Windows.Forms.TextBox();
			this.labelCheckAreaHeight = new System.Windows.Forms.Label();
			this.textBoxCheckAreaWidth = new System.Windows.Forms.TextBox();
			this.labelCheckAreaWidth = new System.Windows.Forms.Label();
			this.labelImageLocation = new System.Windows.Forms.Label();
			this.textBoxImageLocY = new System.Windows.Forms.TextBox();
			this.labelY = new System.Windows.Forms.Label();
			this.textBoxImageLocX = new System.Windows.Forms.TextBox();
			this.labelX = new System.Windows.Forms.Label();
			this.buttonChooseImage = new System.Windows.Forms.Button();
			this.pictureBoxImage = new System.Windows.Forms.PictureBox();
			this.labelImageValidation = new System.Windows.Forms.Label();
			this.labelImageInfo = new System.Windows.Forms.Label();
			this.locationPickerStartLocation = new AutoClicker.Windows.LocationPicker();
			this.locationPickerEndLocation = new AutoClicker.Windows.LocationPicker();
			this.locationPickerClickEvent = new AutoClicker.Windows.LocationPicker();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownDurationMs)).BeginInit();
			this.panelMouseMoveEvent.SuspendLayout();
			this.panelWaitEvent.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownVarMs)).BeginInit();
			this.panelClickEvent.SuspendLayout();
			this.panelImageValidation.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
			this.SuspendLayout();
			// 
			// labelDuration
			// 
			this.labelDuration.AutoSize = true;
			this.labelDuration.Location = new System.Drawing.Point(3, 7);
			this.labelDuration.Name = "labelDuration";
			this.labelDuration.Size = new System.Drawing.Size(47, 13);
			this.labelDuration.TabIndex = 1;
			this.labelDuration.Text = "Duration";
			// 
			// numericUpDownDurationMs
			// 
			this.numericUpDownDurationMs.Location = new System.Drawing.Point(6, 26);
			this.numericUpDownDurationMs.Maximum = new decimal(new int[] {
            -1530494976,
            232830,
            0,
            0});
			this.numericUpDownDurationMs.Name = "numericUpDownDurationMs";
			this.numericUpDownDurationMs.Size = new System.Drawing.Size(102, 20);
			this.numericUpDownDurationMs.TabIndex = 2;
			this.numericUpDownDurationMs.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
			// 
			// labelMs
			// 
			this.labelMs.AutoSize = true;
			this.labelMs.Location = new System.Drawing.Point(114, 28);
			this.labelMs.Name = "labelMs";
			this.labelMs.Size = new System.Drawing.Size(20, 13);
			this.labelMs.TabIndex = 3;
			this.labelMs.Text = "ms";
			// 
			// panelMouseMoveEvent
			// 
			this.panelMouseMoveEvent.Controls.Add(this.locationPickerStartLocation);
			this.panelMouseMoveEvent.Controls.Add(this.locationPickerEndLocation);
			this.panelMouseMoveEvent.Location = new System.Drawing.Point(226, 33);
			this.panelMouseMoveEvent.Name = "panelMouseMoveEvent";
			this.panelMouseMoveEvent.Size = new System.Drawing.Size(220, 246);
			this.panelMouseMoveEvent.TabIndex = 5;
			// 
			// panelWaitEvent
			// 
			this.panelWaitEvent.Controls.Add(this.labelVar);
			this.panelWaitEvent.Controls.Add(this.numericUpDownVarMs);
			this.panelWaitEvent.Controls.Add(this.labelVarMs);
			this.panelWaitEvent.Controls.Add(this.labelDuration);
			this.panelWaitEvent.Controls.Add(this.numericUpDownDurationMs);
			this.panelWaitEvent.Controls.Add(this.labelMs);
			this.panelWaitEvent.Location = new System.Drawing.Point(452, 33);
			this.panelWaitEvent.Name = "panelWaitEvent";
			this.panelWaitEvent.Size = new System.Drawing.Size(220, 247);
			this.panelWaitEvent.TabIndex = 6;
			// 
			// labelVar
			// 
			this.labelVar.AutoSize = true;
			this.labelVar.Location = new System.Drawing.Point(3, 54);
			this.labelVar.Name = "labelVar";
			this.labelVar.Size = new System.Drawing.Size(52, 13);
			this.labelVar.TabIndex = 6;
			this.labelVar.Text = "Variance:";
			// 
			// numericUpDownVarMs
			// 
			this.numericUpDownVarMs.Location = new System.Drawing.Point(61, 52);
			this.numericUpDownVarMs.Maximum = new decimal(new int[] {
            -1530494976,
            232830,
            0,
            0});
			this.numericUpDownVarMs.Name = "numericUpDownVarMs";
			this.numericUpDownVarMs.Size = new System.Drawing.Size(47, 20);
			this.numericUpDownVarMs.TabIndex = 4;
			this.numericUpDownVarMs.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
			// 
			// labelVarMs
			// 
			this.labelVarMs.AutoSize = true;
			this.labelVarMs.Location = new System.Drawing.Point(114, 54);
			this.labelVarMs.Name = "labelVarMs";
			this.labelVarMs.Size = new System.Drawing.Size(20, 13);
			this.labelVarMs.TabIndex = 5;
			this.labelVarMs.Text = "ms";
			// 
			// comboBoxMouseButton
			// 
			this.comboBoxMouseButton.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxMouseButton.FormattingEnabled = true;
			this.comboBoxMouseButton.Items.AddRange(new object[] {
            "Left",
            "Middle",
            "Right"});
			this.comboBoxMouseButton.Location = new System.Drawing.Point(7, 23);
			this.comboBoxMouseButton.Name = "comboBoxMouseButton";
			this.comboBoxMouseButton.Size = new System.Drawing.Size(95, 21);
			this.comboBoxMouseButton.TabIndex = 1;
			// 
			// labelMouseButton
			// 
			this.labelMouseButton.AutoSize = true;
			this.labelMouseButton.Location = new System.Drawing.Point(9, 7);
			this.labelMouseButton.Name = "labelMouseButton";
			this.labelMouseButton.Size = new System.Drawing.Size(73, 13);
			this.labelMouseButton.TabIndex = 1;
			this.labelMouseButton.Text = "Mouse Button";
			// 
			// panelClickEvent
			// 
			this.panelClickEvent.Controls.Add(this.locationPickerClickEvent);
			this.panelClickEvent.Controls.Add(this.labelMouseButton);
			this.panelClickEvent.Controls.Add(this.comboBoxMouseButton);
			this.panelClickEvent.Location = new System.Drawing.Point(0, 35);
			this.panelClickEvent.Name = "panelClickEvent";
			this.panelClickEvent.Size = new System.Drawing.Size(220, 244);
			this.panelClickEvent.TabIndex = 0;
			// 
			// labelEventType
			// 
			this.labelEventType.AutoSize = true;
			this.labelEventType.Location = new System.Drawing.Point(12, 9);
			this.labelEventType.Name = "labelEventType";
			this.labelEventType.Size = new System.Drawing.Size(65, 13);
			this.labelEventType.TabIndex = 7;
			this.labelEventType.Text = "Event Type:";
			// 
			// comboBoxEventType
			// 
			this.comboBoxEventType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxEventType.FormattingEnabled = true;
			this.comboBoxEventType.Items.AddRange(new object[] {
            "Mouse Click",
            "Mouse Move",
            "Wait",
            "Image Validation"});
			this.comboBoxEventType.Location = new System.Drawing.Point(83, 6);
			this.comboBoxEventType.Name = "comboBoxEventType";
			this.comboBoxEventType.Size = new System.Drawing.Size(121, 21);
			this.comboBoxEventType.TabIndex = 8;
			this.comboBoxEventType.SelectedIndexChanged += new System.EventHandler(this.comboBoxEventType_SelectedIndexChanged);
			// 
			// buttonSave
			// 
			this.buttonSave.Location = new System.Drawing.Point(174, 286);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(46, 23);
			this.buttonSave.TabIndex = 9;
			this.buttonSave.Text = "Save";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// panelImageValidation
			// 
			this.panelImageValidation.Controls.Add(this.labelImageInfo);
			this.panelImageValidation.Controls.Add(this.labelImageAreaSize);
			this.panelImageValidation.Controls.Add(this.textBoxCheckAreaHeight);
			this.panelImageValidation.Controls.Add(this.labelCheckAreaHeight);
			this.panelImageValidation.Controls.Add(this.textBoxCheckAreaWidth);
			this.panelImageValidation.Controls.Add(this.labelCheckAreaWidth);
			this.panelImageValidation.Controls.Add(this.labelImageLocation);
			this.panelImageValidation.Controls.Add(this.textBoxImageLocY);
			this.panelImageValidation.Controls.Add(this.labelY);
			this.panelImageValidation.Controls.Add(this.textBoxImageLocX);
			this.panelImageValidation.Controls.Add(this.labelX);
			this.panelImageValidation.Controls.Add(this.buttonChooseImage);
			this.panelImageValidation.Controls.Add(this.pictureBoxImage);
			this.panelImageValidation.Controls.Add(this.labelImageValidation);
			this.panelImageValidation.Location = new System.Drawing.Point(678, 32);
			this.panelImageValidation.Name = "panelImageValidation";
			this.panelImageValidation.Size = new System.Drawing.Size(220, 247);
			this.panelImageValidation.TabIndex = 7;
			// 
			// labelImageAreaSize
			// 
			this.labelImageAreaSize.AutoSize = true;
			this.labelImageAreaSize.Location = new System.Drawing.Point(6, 208);
			this.labelImageAreaSize.Name = "labelImageAreaSize";
			this.labelImageAreaSize.Size = new System.Drawing.Size(98, 13);
			this.labelImageAreaSize.TabIndex = 12;
			this.labelImageAreaSize.Text = "Area to check size:";
			// 
			// textBoxCheckAreaHeight
			// 
			this.textBoxCheckAreaHeight.Location = new System.Drawing.Point(158, 224);
			this.textBoxCheckAreaHeight.Name = "textBoxCheckAreaHeight";
			this.textBoxCheckAreaHeight.Size = new System.Drawing.Size(59, 20);
			this.textBoxCheckAreaHeight.TabIndex = 16;
			this.textBoxCheckAreaHeight.Text = "0";
			// 
			// labelCheckAreaHeight
			// 
			this.labelCheckAreaHeight.AutoSize = true;
			this.labelCheckAreaHeight.Location = new System.Drawing.Point(111, 227);
			this.labelCheckAreaHeight.Name = "labelCheckAreaHeight";
			this.labelCheckAreaHeight.Size = new System.Drawing.Size(41, 13);
			this.labelCheckAreaHeight.TabIndex = 15;
			this.labelCheckAreaHeight.Text = "Height:";
			// 
			// textBoxCheckAreaWidth
			// 
			this.textBoxCheckAreaWidth.Location = new System.Drawing.Point(50, 224);
			this.textBoxCheckAreaWidth.Name = "textBoxCheckAreaWidth";
			this.textBoxCheckAreaWidth.Size = new System.Drawing.Size(59, 20);
			this.textBoxCheckAreaWidth.TabIndex = 14;
			this.textBoxCheckAreaWidth.Text = "0";
			// 
			// labelCheckAreaWidth
			// 
			this.labelCheckAreaWidth.AutoSize = true;
			this.labelCheckAreaWidth.Location = new System.Drawing.Point(6, 227);
			this.labelCheckAreaWidth.Name = "labelCheckAreaWidth";
			this.labelCheckAreaWidth.Size = new System.Drawing.Size(38, 13);
			this.labelCheckAreaWidth.TabIndex = 13;
			this.labelCheckAreaWidth.Text = "Width:";
			// 
			// labelImageLocation
			// 
			this.labelImageLocation.AutoSize = true;
			this.labelImageLocation.Location = new System.Drawing.Point(6, 165);
			this.labelImageLocation.Name = "labelImageLocation";
			this.labelImageLocation.Size = new System.Drawing.Size(92, 13);
			this.labelImageLocation.TabIndex = 7;
			this.labelImageLocation.Text = "Location (top left):";
			// 
			// textBoxImageLocY
			// 
			this.textBoxImageLocY.Location = new System.Drawing.Point(117, 181);
			this.textBoxImageLocY.Name = "textBoxImageLocY";
			this.textBoxImageLocY.Size = new System.Drawing.Size(59, 20);
			this.textBoxImageLocY.TabIndex = 11;
			this.textBoxImageLocY.Text = "0";
			// 
			// labelY
			// 
			this.labelY.AutoSize = true;
			this.labelY.Location = new System.Drawing.Point(94, 184);
			this.labelY.Name = "labelY";
			this.labelY.Size = new System.Drawing.Size(17, 13);
			this.labelY.TabIndex = 10;
			this.labelY.Text = "Y:";
			// 
			// textBoxImageLocX
			// 
			this.textBoxImageLocX.Location = new System.Drawing.Point(29, 181);
			this.textBoxImageLocX.Name = "textBoxImageLocX";
			this.textBoxImageLocX.Size = new System.Drawing.Size(59, 20);
			this.textBoxImageLocX.TabIndex = 9;
			this.textBoxImageLocX.Text = "0";
			// 
			// labelX
			// 
			this.labelX.AutoSize = true;
			this.labelX.Location = new System.Drawing.Point(6, 184);
			this.labelX.Name = "labelX";
			this.labelX.Size = new System.Drawing.Size(17, 13);
			this.labelX.TabIndex = 8;
			this.labelX.Text = "X:";
			// 
			// buttonChooseImage
			// 
			this.buttonChooseImage.Location = new System.Drawing.Point(164, 29);
			this.buttonChooseImage.Name = "buttonChooseImage";
			this.buttonChooseImage.Size = new System.Drawing.Size(53, 39);
			this.buttonChooseImage.TabIndex = 3;
			this.buttonChooseImage.Text = "Choose\r\nImage";
			this.buttonChooseImage.UseVisualStyleBackColor = true;
			this.buttonChooseImage.Click += new System.EventHandler(this.buttonChooseImage_Click);
			// 
			// pictureBoxImage
			// 
			this.pictureBoxImage.Location = new System.Drawing.Point(6, 29);
			this.pictureBoxImage.Name = "pictureBoxImage";
			this.pictureBoxImage.Size = new System.Drawing.Size(125, 125);
			this.pictureBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxImage.TabIndex = 2;
			this.pictureBoxImage.TabStop = false;
			// 
			// labelImageValidation
			// 
			this.labelImageValidation.AutoSize = true;
			this.labelImageValidation.Location = new System.Drawing.Point(3, 7);
			this.labelImageValidation.Name = "labelImageValidation";
			this.labelImageValidation.Size = new System.Drawing.Size(85, 13);
			this.labelImageValidation.TabIndex = 1;
			this.labelImageValidation.Text = "Image Validation";
			// 
			// labelImageInfo
			// 
			this.labelImageInfo.Location = new System.Drawing.Point(137, 71);
			this.labelImageInfo.Name = "labelImageInfo";
			this.labelImageInfo.Size = new System.Drawing.Size(80, 59);
			this.labelImageInfo.TabIndex = 17;
			this.labelImageInfo.Text = "Width:\r\n\r\nHeight:";
			// 
			// locationPickerStartLocation
			// 
			impreciseLocation1.CoordinateSystem = AutoClicker.Objects.CoordinateSystem.Absolute;
			impreciseLocation1.X = 0;
			impreciseLocation1.Y = 0;
			this.locationPickerStartLocation.ChosenLocation = impreciseLocation1;
			this.locationPickerStartLocation.CoordinateSystem = AutoClicker.Objects.CoordinateSystem.Absolute;
			this.locationPickerStartLocation.Location = new System.Drawing.Point(5, 7);
			this.locationPickerStartLocation.Name = "locationPickerStartLocation";
			this.locationPickerStartLocation.Size = new System.Drawing.Size(102, 236);
			this.locationPickerStartLocation.TabIndex = 5;
			this.locationPickerStartLocation.Title = "Start location";
			this.locationPickerStartLocation.X = 0;
			this.locationPickerStartLocation.XVariance = 0;
			this.locationPickerStartLocation.Y = 0;
			this.locationPickerStartLocation.YVariance = 0;
			// 
			// locationPickerEndLocation
			// 
			impreciseLocation2.CoordinateSystem = AutoClicker.Objects.CoordinateSystem.Absolute;
			impreciseLocation2.X = 0;
			impreciseLocation2.Y = 0;
			this.locationPickerEndLocation.ChosenLocation = impreciseLocation2;
			this.locationPickerEndLocation.CoordinateSystem = AutoClicker.Objects.CoordinateSystem.Absolute;
			this.locationPickerEndLocation.Location = new System.Drawing.Point(113, 7);
			this.locationPickerEndLocation.Name = "locationPickerEndLocation";
			this.locationPickerEndLocation.Size = new System.Drawing.Size(102, 236);
			this.locationPickerEndLocation.TabIndex = 4;
			this.locationPickerEndLocation.Title = "End location";
			this.locationPickerEndLocation.X = 0;
			this.locationPickerEndLocation.XVariance = 0;
			this.locationPickerEndLocation.Y = 0;
			this.locationPickerEndLocation.YVariance = 0;
			// 
			// locationPickerClickEvent
			// 
			impreciseLocation3.CoordinateSystem = AutoClicker.Objects.CoordinateSystem.Absolute;
			impreciseLocation3.X = 0;
			impreciseLocation3.Y = 0;
			this.locationPickerClickEvent.ChosenLocation = impreciseLocation3;
			this.locationPickerClickEvent.CoordinateSystem = AutoClicker.Objects.CoordinateSystem.Absolute;
			this.locationPickerClickEvent.Location = new System.Drawing.Point(113, 7);
			this.locationPickerClickEvent.Name = "locationPickerClickEvent";
			this.locationPickerClickEvent.Size = new System.Drawing.Size(102, 238);
			this.locationPickerClickEvent.TabIndex = 4;
			this.locationPickerClickEvent.Title = "Location";
			this.locationPickerClickEvent.X = 0;
			this.locationPickerClickEvent.XVariance = 0;
			this.locationPickerClickEvent.Y = 0;
			this.locationPickerClickEvent.YVariance = 0;
			// 
			// AddEditEventDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(979, 311);
			this.Controls.Add(this.panelImageValidation);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.comboBoxEventType);
			this.Controls.Add(this.labelEventType);
			this.Controls.Add(this.panelWaitEvent);
			this.Controls.Add(this.panelMouseMoveEvent);
			this.Controls.Add(this.panelClickEvent);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AddEditEventDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add or Edit Event";
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownDurationMs)).EndInit();
			this.panelMouseMoveEvent.ResumeLayout(false);
			this.panelWaitEvent.ResumeLayout(false);
			this.panelWaitEvent.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownVarMs)).EndInit();
			this.panelClickEvent.ResumeLayout(false);
			this.panelClickEvent.PerformLayout();
			this.panelImageValidation.ResumeLayout(false);
			this.panelImageValidation.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelDuration;
        private System.Windows.Forms.NumericUpDown numericUpDownDurationMs;
        private System.Windows.Forms.Label labelMs;
        private System.Windows.Forms.Panel panelMouseMoveEvent;
        private LocationPicker locationPickerStartLocation;
        private LocationPicker locationPickerEndLocation;
        private System.Windows.Forms.Panel panelWaitEvent;
        private System.Windows.Forms.ComboBox comboBoxMouseButton;
        private System.Windows.Forms.Label labelMouseButton;
        private LocationPicker locationPickerClickEvent;
        private System.Windows.Forms.Panel panelClickEvent;
        private System.Windows.Forms.Label labelEventType;
        private System.Windows.Forms.ComboBox comboBoxEventType;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.NumericUpDown numericUpDownVarMs;
        private System.Windows.Forms.Label labelVarMs;
        private System.Windows.Forms.Label labelVar;
		private System.Windows.Forms.Panel panelImageValidation;
		private System.Windows.Forms.Label labelImageValidation;
		private System.Windows.Forms.PictureBox pictureBoxImage;
		private System.Windows.Forms.Button buttonChooseImage;
		private System.Windows.Forms.TextBox textBoxImageLocY;
		private System.Windows.Forms.Label labelY;
		private System.Windows.Forms.TextBox textBoxImageLocX;
		private System.Windows.Forms.Label labelX;
		private System.Windows.Forms.Label labelImageAreaSize;
		private System.Windows.Forms.TextBox textBoxCheckAreaHeight;
		private System.Windows.Forms.Label labelCheckAreaHeight;
		private System.Windows.Forms.TextBox textBoxCheckAreaWidth;
		private System.Windows.Forms.Label labelCheckAreaWidth;
		private System.Windows.Forms.Label labelImageLocation;
		private System.Windows.Forms.Label labelImageInfo;
	}
}