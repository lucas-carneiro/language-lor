namespace LanguageLoR
{
    partial class MainWindow
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
            this.ChangeButton = new System.Windows.Forms.Button();
            this.languageTextPicker = new System.Windows.Forms.ComboBox();
            this.languageVoicePicker = new System.Windows.Forms.ComboBox();
            this.languageTextLabel = new System.Windows.Forms.Label();
            this.languageVoiceLabel = new System.Windows.Forms.Label();
            this.lorDirectoryDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // ChangeButton
            // 
            this.ChangeButton.Location = new System.Drawing.Point(190, 188);
            this.ChangeButton.Name = "ChangeButton";
            this.ChangeButton.Size = new System.Drawing.Size(75, 23);
            this.ChangeButton.TabIndex = 0;
            this.ChangeButton.Text = "Change";
            this.ChangeButton.UseVisualStyleBackColor = true;
            this.ChangeButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // languageTextPicker
            // 
            this.languageTextPicker.FormattingEnabled = true;
            this.languageTextPicker.Location = new System.Drawing.Point(88, 140);
            this.languageTextPicker.Name = "languageTextPicker";
            this.languageTextPicker.Size = new System.Drawing.Size(121, 23);
            this.languageTextPicker.TabIndex = 1;
            // 
            // languageVoicePicker
            // 
            this.languageVoicePicker.FormattingEnabled = true;
            this.languageVoicePicker.Location = new System.Drawing.Point(241, 140);
            this.languageVoicePicker.Name = "languageVoicePicker";
            this.languageVoicePicker.Size = new System.Drawing.Size(121, 23);
            this.languageVoicePicker.TabIndex = 2;
            // 
            // languageTextLabel
            // 
            this.languageTextLabel.Location = new System.Drawing.Point(98, 114);
            this.languageTextLabel.Name = "languageTextLabel";
            this.languageTextLabel.Size = new System.Drawing.Size(100, 23);
            this.languageTextLabel.TabIndex = 3;
            this.languageTextLabel.Text = "Text Language";
            this.languageTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.languageTextLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // languageVoiceLabel
            // 
            this.languageVoiceLabel.Location = new System.Drawing.Point(250, 114);
            this.languageVoiceLabel.Name = "languageVoiceLabel";
            this.languageVoiceLabel.Size = new System.Drawing.Size(100, 23);
            this.languageVoiceLabel.TabIndex = 4;
            this.languageVoiceLabel.Text = "Voice Language";
            this.languageVoiceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lorDirectoryDialog
            // 
            this.lorDirectoryDialog.FileName = "openFileDialog1";
            this.lorDirectoryDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 279);
            this.Controls.Add(this.languageVoiceLabel);
            this.Controls.Add(this.languageTextLabel);
            this.Controls.Add(this.languageVoicePicker);
            this.Controls.Add(this.languageTextPicker);
            this.Controls.Add(this.ChangeButton);
            this.Name = "MainWindow";
            this.Text = "Language Picker LoR";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button ChangeButton;
        private System.Windows.Forms.ComboBox languageTextPicker;
        private System.Windows.Forms.ComboBox languageVoicePicker;
        private System.Windows.Forms.Label languageTextLabel;
        private System.Windows.Forms.Label languageVoiceLabel;
        private System.Windows.Forms.OpenFileDialog lorDirectoryDialog;
    }
}