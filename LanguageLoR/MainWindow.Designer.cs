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
            this.changeLanguageButton = new System.Windows.Forms.Button();
            this.languageTextPicker = new System.Windows.Forms.ComboBox();
            this.languageVoicePicker = new System.Windows.Forms.ComboBox();
            this.languageTextLabel = new System.Windows.Forms.Label();
            this.languageVoiceLabel = new System.Windows.Forms.Label();
            this.lorInstallPathTextField = new System.Windows.Forms.TextBox();
            this.lorInstallPathLabel = new System.Windows.Forms.Label();
            this.languageDefaultLabel = new System.Windows.Forms.Label();
            this.loadingLabel = new System.Windows.Forms.Label();
            this.languageDefaultTextField = new System.Windows.Forms.TextBox();
            this.aboutLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // changeLanguageButton
            // 
            this.changeLanguageButton.Location = new System.Drawing.Point(153, 265);
            this.changeLanguageButton.Name = "changeLanguageButton";
            this.changeLanguageButton.Size = new System.Drawing.Size(140, 31);
            this.changeLanguageButton.TabIndex = 0;
            this.changeLanguageButton.Text = "Change Language";
            this.changeLanguageButton.UseVisualStyleBackColor = true;
            this.changeLanguageButton.Click += new System.EventHandler(this.ChangeLanguageButtonClick);
            // 
            // languageTextPicker
            // 
            this.languageTextPicker.FormattingEnabled = true;
            this.languageTextPicker.Location = new System.Drawing.Point(42, 213);
            this.languageTextPicker.Name = "languageTextPicker";
            this.languageTextPicker.Size = new System.Drawing.Size(174, 23);
            this.languageTextPicker.TabIndex = 1;
            // 
            // languageVoicePicker
            // 
            this.languageVoicePicker.FormattingEnabled = true;
            this.languageVoicePicker.Location = new System.Drawing.Point(234, 213);
            this.languageVoicePicker.Name = "languageVoicePicker";
            this.languageVoicePicker.Size = new System.Drawing.Size(174, 23);
            this.languageVoicePicker.TabIndex = 2;
            // 
            // languageTextLabel
            // 
            this.languageTextLabel.Location = new System.Drawing.Point(42, 188);
            this.languageTextLabel.Name = "languageTextLabel";
            this.languageTextLabel.Size = new System.Drawing.Size(174, 23);
            this.languageTextLabel.TabIndex = 3;
            this.languageTextLabel.Text = "Text Language";
            this.languageTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // languageVoiceLabel
            // 
            this.languageVoiceLabel.Location = new System.Drawing.Point(234, 188);
            this.languageVoiceLabel.Name = "languageVoiceLabel";
            this.languageVoiceLabel.Size = new System.Drawing.Size(174, 23);
            this.languageVoiceLabel.TabIndex = 4;
            this.languageVoiceLabel.Text = "Voice Language";
            this.languageVoiceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lorInstallPathTextField
            // 
            this.lorInstallPathTextField.Enabled = false;
            this.lorInstallPathTextField.Location = new System.Drawing.Point(90, 73);
            this.lorInstallPathTextField.Name = "lorInstallPathTextField";
            this.lorInstallPathTextField.Size = new System.Drawing.Size(275, 23);
            this.lorInstallPathTextField.TabIndex = 5;
            // 
            // lorInstallPathLabel
            // 
            this.lorInstallPathLabel.Location = new System.Drawing.Point(90, 48);
            this.lorInstallPathLabel.Name = "lorInstallPathLabel";
            this.lorInstallPathLabel.Size = new System.Drawing.Size(275, 23);
            this.lorInstallPathLabel.TabIndex = 6;
            this.lorInstallPathLabel.Text = "Legends of Runeterra Path";
            this.lorInstallPathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // languageDefaultLabel
            // 
            this.languageDefaultLabel.Location = new System.Drawing.Point(136, 114);
            this.languageDefaultLabel.Name = "languageDefaultLabel";
            this.languageDefaultLabel.Size = new System.Drawing.Size(174, 23);
            this.languageDefaultLabel.TabIndex = 8;
            this.languageDefaultLabel.Text = "Default Language";
            this.languageDefaultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // loadingLabel
            // 
            this.loadingLabel.Location = new System.Drawing.Point(42, 299);
            this.loadingLabel.Name = "loadingLabel";
            this.loadingLabel.Size = new System.Drawing.Size(366, 23);
            this.loadingLabel.TabIndex = 9;
            this.loadingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // languageDefaultTextField
            // 
            this.languageDefaultTextField.Enabled = false;
            this.languageDefaultTextField.Location = new System.Drawing.Point(136, 140);
            this.languageDefaultTextField.Name = "languageDefaultTextField";
            this.languageDefaultTextField.Size = new System.Drawing.Size(174, 23);
            this.languageDefaultTextField.TabIndex = 10;
            // 
            // aboutLabel
            // 
            this.aboutLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.aboutLabel.Location = new System.Drawing.Point(406, 312);
            this.aboutLabel.Name = "aboutLabel";
            this.aboutLabel.Size = new System.Drawing.Size(44, 23);
            this.aboutLabel.TabIndex = 11;
            this.aboutLabel.Text = "About";
            this.aboutLabel.Click += new System.EventHandler(this.AboutButtonClick);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 343);
            this.Controls.Add(this.aboutLabel);
            this.Controls.Add(this.languageDefaultTextField);
            this.Controls.Add(this.loadingLabel);
            this.Controls.Add(this.languageDefaultLabel);
            this.Controls.Add(this.lorInstallPathLabel);
            this.Controls.Add(this.lorInstallPathTextField);
            this.Controls.Add(this.languageVoiceLabel);
            this.Controls.Add(this.languageTextLabel);
            this.Controls.Add(this.languageVoicePicker);
            this.Controls.Add(this.languageTextPicker);
            this.Controls.Add(this.changeLanguageButton);
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.ShowIcon = false;
            this.Text = "Language LoR";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox languageTextPicker;
        private System.Windows.Forms.ComboBox languageVoicePicker;
        private System.Windows.Forms.Label languageTextLabel;
        private System.Windows.Forms.Label languageVoiceLabel;
        private System.Windows.Forms.Label lorInstallPathLabel;
        private System.Windows.Forms.TextBox lorInstallPathTextField;
        private System.Windows.Forms.Label languageDefaultLabel;
        private System.Windows.Forms.Button changeLanguageButton;
        private System.Windows.Forms.Label loadingLabel;
        private System.Windows.Forms.TextBox languageDefaultTextField;
        private System.Windows.Forms.Label aboutLabel;
    }
}