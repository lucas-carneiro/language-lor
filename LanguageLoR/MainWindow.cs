using System;
using System.Windows.Forms;

namespace LanguageLoR
{
    public partial class MainWindow : Form
    {
        private string[] languageFiles;
        public MainWindow()
        {
            InitializeComponent();
            lorInstallPathTextField.Text = FileService.LorInstallPath;
            languageDefaultPicker.Items.AddRange(LanguageService.Languages);
            languageTextPicker.Items.AddRange(LanguageService.Languages);
            languageVoicePicker.Items.AddRange(LanguageService.Languages);
        }

        private void ChangeLanguageButtonClick(object sender, EventArgs e)
        {
            FileService.UpdateLanguage(
                languageFiles[languageDefaultPicker.SelectedIndex],
                languageFiles[languageTextPicker.SelectedIndex],
                languageFiles[languageVoicePicker.SelectedIndex]
            );
        }
        
        private void SelectLanguageDefaultPicker(object sender, EventArgs e)
        {
            languageTextPicker.SelectedIndex = languageDefaultPicker.SelectedIndex;
            languageVoicePicker.SelectedIndex = languageDefaultPicker.SelectedIndex;
        }
    }
}