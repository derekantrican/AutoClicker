namespace AutoClicker.Windows
{
    partial class LocationPicker
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.buttonPick = new System.Windows.Forms.Button();
            this.textBoxY = new System.Windows.Forms.TextBox();
            this.labelY = new System.Windows.Forms.Label();
            this.textBoxX = new System.Windows.Forms.TextBox();
            this.labelX = new System.Windows.Forms.Label();
            this.textBoxVarY = new System.Windows.Forms.TextBox();
            this.labelVarY = new System.Windows.Forms.Label();
            this.textBoxVarX = new System.Windows.Forms.TextBox();
            this.labelVarX = new System.Windows.Forms.Label();
            this.comboBoxCoordinateSystem = new System.Windows.Forms.ComboBox();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.comboBoxCoordinateSystem);
            this.groupBox.Controls.Add(this.textBoxVarY);
            this.groupBox.Controls.Add(this.labelVarY);
            this.groupBox.Controls.Add(this.textBoxVarX);
            this.groupBox.Controls.Add(this.labelVarX);
            this.groupBox.Controls.Add(this.buttonPick);
            this.groupBox.Controls.Add(this.textBoxY);
            this.groupBox.Controls.Add(this.labelY);
            this.groupBox.Controls.Add(this.textBoxX);
            this.groupBox.Controls.Add(this.labelX);
            this.groupBox.Location = new System.Drawing.Point(3, 3);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(94, 230);
            this.groupBox.TabIndex = 6;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "GroupBox";
            // 
            // buttonPick
            // 
            this.buttonPick.Location = new System.Drawing.Point(5, 95);
            this.buttonPick.Name = "buttonPick";
            this.buttonPick.Size = new System.Drawing.Size(75, 23);
            this.buttonPick.TabIndex = 8;
            this.buttonPick.Text = "Pick";
            this.buttonPick.UseVisualStyleBackColor = true;
            this.buttonPick.Click += new System.EventHandler(this.buttonPick_Click);
            // 
            // textBoxY
            // 
            this.textBoxY.Location = new System.Drawing.Point(28, 69);
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.Size = new System.Drawing.Size(59, 20);
            this.textBoxY.TabIndex = 7;
            this.textBoxY.Text = "0";
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(5, 72);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(17, 13);
            this.labelY.TabIndex = 6;
            this.labelY.Text = "Y:";
            // 
            // textBoxX
            // 
            this.textBoxX.Location = new System.Drawing.Point(28, 43);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(59, 20);
            this.textBoxX.TabIndex = 5;
            this.textBoxX.Text = "0";
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(5, 46);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(17, 13);
            this.labelX.TabIndex = 4;
            this.labelX.Text = "X:";
            // 
            // textBoxVarY
            // 
            this.textBoxVarY.Location = new System.Drawing.Point(28, 203);
            this.textBoxVarY.Name = "textBoxVarY";
            this.textBoxVarY.Size = new System.Drawing.Size(59, 20);
            this.textBoxVarY.TabIndex = 12;
            this.textBoxVarY.Text = "0";
            // 
            // labelVarY
            // 
            this.labelVarY.AutoSize = true;
            this.labelVarY.Location = new System.Drawing.Point(5, 186);
            this.labelVarY.Name = "labelVarY";
            this.labelVarY.Size = new System.Drawing.Size(49, 26);
            this.labelVarY.TabIndex = 11;
            this.labelVarY.Text = "Variance\r\nY:";
            // 
            // textBoxVarX
            // 
            this.textBoxVarX.Location = new System.Drawing.Point(28, 157);
            this.textBoxVarX.Name = "textBoxVarX";
            this.textBoxVarX.Size = new System.Drawing.Size(59, 20);
            this.textBoxVarX.TabIndex = 10;
            this.textBoxVarX.Text = "0";
            // 
            // labelVarX
            // 
            this.labelVarX.AutoSize = true;
            this.labelVarX.Location = new System.Drawing.Point(5, 141);
            this.labelVarX.Name = "labelVarX";
            this.labelVarX.Size = new System.Drawing.Size(49, 26);
            this.labelVarX.TabIndex = 9;
            this.labelVarX.Text = "Variance\r\nX:";
            // 
            // comboBoxCoordinateSystem
            // 
            this.comboBoxCoordinateSystem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCoordinateSystem.FormattingEnabled = true;
            this.comboBoxCoordinateSystem.Items.AddRange(new object[] {
            "Absolute",
            "Relative"});
            this.comboBoxCoordinateSystem.Location = new System.Drawing.Point(3, 16);
            this.comboBoxCoordinateSystem.Name = "comboBoxCoordinateSystem";
            this.comboBoxCoordinateSystem.Size = new System.Drawing.Size(84, 21);
            this.comboBoxCoordinateSystem.TabIndex = 13;
            // 
            // LocationPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox);
            this.Name = "LocationPicker";
            this.Size = new System.Drawing.Size(102, 238);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.TextBox textBoxY;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.TextBox textBoxX;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Button buttonPick;
        private System.Windows.Forms.TextBox textBoxVarY;
        private System.Windows.Forms.Label labelVarY;
        private System.Windows.Forms.TextBox textBoxVarX;
        private System.Windows.Forms.Label labelVarX;
        private System.Windows.Forms.ComboBox comboBoxCoordinateSystem;
    }
}
