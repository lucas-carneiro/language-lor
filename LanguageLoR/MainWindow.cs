using System;
using System.Windows.Forms;

namespace LanguageLoR
{
    public partial class MainWindow : Form
    {
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
            loadingLabel.Text = "Replacing language...";
            FileService.UpdateLanguage(
                languageDefaultPicker.SelectedIndex,
                languageTextPicker.SelectedIndex,
                languageVoicePicker.SelectedIndex
            );
            loadingLabel.Text = "Language successfully replaced!";
        }
        
        private void SelectLanguageDefaultPicker(object sender, EventArgs e)
        {
            languageTextPicker.SelectedIndex = languageDefaultPicker.SelectedIndex;
            languageVoicePicker.SelectedIndex = languageDefaultPicker.SelectedIndex;
        }
    }
}