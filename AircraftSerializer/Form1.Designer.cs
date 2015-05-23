namespace AircraftSerializer
{
    partial class Form1
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
            this.createGroupBox = new System.Windows.Forms.GroupBox();
            this.createRotorcraftButton = new System.Windows.Forms.Button();
            this.createGliderButton = new System.Windows.Forms.Button();
            this.createTetheredBalloonButton = new System.Windows.Forms.Button();
            this.createFreeFloatingBalloonButton = new System.Windows.Forms.Button();
            this.createAirshipButton = new System.Windows.Forms.Button();
            this.createAirplaneButton = new System.Windows.Forms.Button();
            this.modifyButton = new System.Windows.Forms.Button();
            this.openButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.aircraftListBox = new System.Windows.Forms.ListBox();
            this.infoLabel = new System.Windows.Forms.Label();
            this.removeButton = new System.Windows.Forms.Button();
            this.createGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // createGroupBox
            // 
            this.createGroupBox.Controls.Add(this.createRotorcraftButton);
            this.createGroupBox.Controls.Add(this.createGliderButton);
            this.createGroupBox.Controls.Add(this.createTetheredBalloonButton);
            this.createGroupBox.Controls.Add(this.createFreeFloatingBalloonButton);
            this.createGroupBox.Controls.Add(this.createAirshipButton);
            this.createGroupBox.Controls.Add(this.createAirplaneButton);
            this.createGroupBox.Location = new System.Drawing.Point(9, 226);
            this.createGroupBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.createGroupBox.Name = "createGroupBox";
            this.createGroupBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.createGroupBox.Size = new System.Drawing.Size(166, 125);
            this.createGroupBox.TabIndex = 1;
            this.createGroupBox.TabStop = false;
            this.createGroupBox.Text = "Create";
            // 
            // createRotorcraftButton
            // 
            this.createRotorcraftButton.Location = new System.Drawing.Point(85, 93);
            this.createRotorcraftButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.createRotorcraftButton.Name = "createRotorcraftButton";
            this.createRotorcraftButton.Size = new System.Drawing.Size(75, 24);
            this.createRotorcraftButton.TabIndex = 5;
            this.createRotorcraftButton.Text = "Rotorcraft";
            this.createRotorcraftButton.UseVisualStyleBackColor = true;
            this.createRotorcraftButton.Click += new System.EventHandler(this.createRotorcraftButton_Click);
            // 
            // createGliderButton
            // 
            this.createGliderButton.Location = new System.Drawing.Point(5, 93);
            this.createGliderButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.createGliderButton.Name = "createGliderButton";
            this.createGliderButton.Size = new System.Drawing.Size(75, 24);
            this.createGliderButton.TabIndex = 4;
            this.createGliderButton.Text = "Glider";
            this.createGliderButton.UseVisualStyleBackColor = true;
            this.createGliderButton.Click += new System.EventHandler(this.createGliderButton_Click);
            // 
            // createTetheredBalloonButton
            // 
            this.createTetheredBalloonButton.Location = new System.Drawing.Point(85, 47);
            this.createTetheredBalloonButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.createTetheredBalloonButton.Name = "createTetheredBalloonButton";
            this.createTetheredBalloonButton.Size = new System.Drawing.Size(75, 41);
            this.createTetheredBalloonButton.TabIndex = 3;
            this.createTetheredBalloonButton.Text = "Tethered balloon";
            this.createTetheredBalloonButton.UseVisualStyleBackColor = true;
            this.createTetheredBalloonButton.Click += new System.EventHandler(this.createTetheredBalloonButton_Click);
            // 
            // createFreeFloatingBalloonButton
            // 
            this.createFreeFloatingBalloonButton.Location = new System.Drawing.Point(5, 47);
            this.createFreeFloatingBalloonButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.createFreeFloatingBalloonButton.Name = "createFreeFloatingBalloonButton";
            this.createFreeFloatingBalloonButton.Size = new System.Drawing.Size(75, 41);
            this.createFreeFloatingBalloonButton.TabIndex = 2;
            this.createFreeFloatingBalloonButton.Text = "Free-floating balloon";
            this.createFreeFloatingBalloonButton.UseVisualStyleBackColor = true;
            this.createFreeFloatingBalloonButton.Click += new System.EventHandler(this.createFreeFloatingBalloonButton_Click);
            // 
            // createAirshipButton
            // 
            this.createAirshipButton.Location = new System.Drawing.Point(85, 18);
            this.createAirshipButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.createAirshipButton.Name = "createAirshipButton";
            this.createAirshipButton.Size = new System.Drawing.Size(75, 24);
            this.createAirshipButton.TabIndex = 1;
            this.createAirshipButton.Text = "Airship";
            this.createAirshipButton.UseVisualStyleBackColor = true;
            this.createAirshipButton.Click += new System.EventHandler(this.createAirshipButton_Click);
            // 
            // createAirplaneButton
            // 
            this.createAirplaneButton.Location = new System.Drawing.Point(5, 18);
            this.createAirplaneButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.createAirplaneButton.Name = "createAirplaneButton";
            this.createAirplaneButton.Size = new System.Drawing.Size(75, 24);
            this.createAirplaneButton.TabIndex = 0;
            this.createAirplaneButton.Text = "Airplane";
            this.createAirplaneButton.UseVisualStyleBackColor = true;
            this.createAirplaneButton.Click += new System.EventHandler(this.createAirplaneButton_Click);
            // 
            // modifyButton
            // 
            this.modifyButton.Location = new System.Drawing.Point(9, 167);
            this.modifyButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.modifyButton.Name = "modifyButton";
            this.modifyButton.Size = new System.Drawing.Size(75, 24);
            this.modifyButton.TabIndex = 2;
            this.modifyButton.Text = "Modify";
            this.modifyButton.UseVisualStyleBackColor = true;
            this.modifyButton.Click += new System.EventHandler(this.modifyButton_Click);
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(10, 197);
            this.openButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(75, 24);
            this.openButton.TabIndex = 3;
            this.openButton.Text = "Open";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(89, 197);
            this.saveButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(74, 24);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // aircraftListBox
            // 
            this.aircraftListBox.FormattingEnabled = true;
            this.aircraftListBox.Location = new System.Drawing.Point(9, 10);
            this.aircraftListBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.aircraftListBox.Name = "aircraftListBox";
            this.aircraftListBox.Size = new System.Drawing.Size(376, 147);
            this.aircraftListBox.TabIndex = 5;
            this.aircraftListBox.SelectedIndexChanged += new System.EventHandler(this.aircraftListBox_SelectedIndexChanged);
            // 
            // infoLabel
            // 
            this.infoLabel.AutoEllipsis = true;
            this.infoLabel.Location = new System.Drawing.Point(180, 167);
            this.infoLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(204, 184);
            this.infoLabel.TabIndex = 6;
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(89, 167);
            this.removeButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(74, 24);
            this.removeButton.TabIndex = 7;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 358);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.aircraftListBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.modifyButton);
            this.Controls.Add(this.createGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Aircraft Serializer";
            this.createGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox createGroupBox;
        private System.Windows.Forms.Button createRotorcraftButton;
        private System.Windows.Forms.Button createGliderButton;
        private System.Windows.Forms.Button createTetheredBalloonButton;
        private System.Windows.Forms.Button createFreeFloatingBalloonButton;
        private System.Windows.Forms.Button createAirshipButton;
        private System.Windows.Forms.Button createAirplaneButton;
        private System.Windows.Forms.Button modifyButton;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.ListBox aircraftListBox;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.Button removeButton;
    }
}

