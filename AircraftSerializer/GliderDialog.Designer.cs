namespace AircraftSerializer
{
    partial class GliderDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.maxLoadTextBox = new System.Windows.Forms.TextBox();
            this.massTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.wingspanTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.launchTypeComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Max load:";
            // 
            // maxLoadTextBox
            // 
            this.maxLoadTextBox.Location = new System.Drawing.Point(88, 10);
            this.maxLoadTextBox.Name = "maxLoadTextBox";
            this.maxLoadTextBox.Size = new System.Drawing.Size(80, 20);
            this.maxLoadTextBox.TabIndex = 1;
            // 
            // massTextBox
            // 
            this.massTextBox.Location = new System.Drawing.Point(88, 36);
            this.massTextBox.Name = "massTextBox";
            this.massTextBox.Size = new System.Drawing.Size(80, 20);
            this.massTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mass:";
            // 
            // wingspanTextBox
            // 
            this.wingspanTextBox.Location = new System.Drawing.Point(88, 62);
            this.wingspanTextBox.Name = "wingspanTextBox";
            this.wingspanTextBox.Size = new System.Drawing.Size(80, 20);
            this.wingspanTextBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Wingspan:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Launch type:";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(16, 119);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(152, 23);
            this.okButton.TabIndex = 8;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // launchTypeComboBox
            // 
            this.launchTypeComboBox.FormattingEnabled = true;
            this.launchTypeComboBox.Items.AddRange(new object[] {
            "Tow-launched",
            "Motorized",
            "Foot-launched"});
            this.launchTypeComboBox.Location = new System.Drawing.Point(88, 88);
            this.launchTypeComboBox.Name = "launchTypeComboBox";
            this.launchTypeComboBox.Size = new System.Drawing.Size(80, 21);
            this.launchTypeComboBox.TabIndex = 9;
            // 
            // GliderDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(180, 154);
            this.ControlBox = false;
            this.Controls.Add(this.launchTypeComboBox);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.wingspanTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.massTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.maxLoadTextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GliderDialog";
            this.Text = "Glider";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox maxLoadTextBox;
        private System.Windows.Forms.TextBox massTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox wingspanTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.ComboBox launchTypeComboBox;
    }
}