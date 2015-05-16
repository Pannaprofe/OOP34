namespace EncryptionPlugin
{
    partial class EncryptionSettingsDialog
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
            this.algoComboBox = new System.Windows.Forms.ComboBox();
            this.selectFileButton = new System.Windows.Forms.Button();
            this.applyButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Encryption algorithm:";
            // 
            // algoComboBox
            // 
            this.algoComboBox.FormattingEnabled = true;
            this.algoComboBox.Items.AddRange(new object[] {
            "AES",
            "Triple DES"});
            this.algoComboBox.Location = new System.Drawing.Point(159, 47);
            this.algoComboBox.Name = "algoComboBox";
            this.algoComboBox.Size = new System.Drawing.Size(111, 24);
            this.algoComboBox.TabIndex = 1;
            // 
            // selectFileButton
            // 
            this.selectFileButton.Location = new System.Drawing.Point(15, 12);
            this.selectFileButton.Name = "selectFileButton";
            this.selectFileButton.Size = new System.Drawing.Size(255, 27);
            this.selectFileButton.TabIndex = 2;
            this.selectFileButton.Text = "Select key file";
            this.selectFileButton.UseVisualStyleBackColor = true;
            this.selectFileButton.Click += new System.EventHandler(this.selectFileButton_Click);
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(15, 89);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(255, 27);
            this.applyButton.TabIndex = 3;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // EncryptionSettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 128);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.selectFileButton);
            this.Controls.Add(this.algoComboBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EncryptionSettingsDialog";
            this.ShowIcon = false;
            this.Text = "Encryption";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox algoComboBox;
        private System.Windows.Forms.Button selectFileButton;
        private System.Windows.Forms.Button applyButton;
    }
}