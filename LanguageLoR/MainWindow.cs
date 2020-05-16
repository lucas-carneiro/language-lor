using System;
using System.Windows.Forms;

namespace LanguageLoR
{
    public partial class MainWindow : Form
    {
        private const string LorPathNotFoundErrorMessage = "Path not found! LoR is probably not installed.";
        public MainWindow()
        {
            InitializeComponent();
            lorInstallPathTextField.Text = FileService.LorInstallPath ?? LorPathNotFoundErrorMessage;
            
            languageDefaultPicker.Items.AddRange(LanguageService.VoiceLanguages);
            languageTextPicker.Items.AddRange(LanguageService.TextLanguages);
            languageVoicePicker.Items.AddRange(LanguageService.VoiceLanguages);

            languageDefaultPicker.SelectedItem = LanguageService.DefaultLanguage;
        }

        private void ChangeLanguageButtonClick(object sender, EventArgs e)
        {
            if (languageDefaultPicker.SelectedIndex != languageTextPicker.SelectedIndex)
            {
                loadingLabel.Text = "Replacing language...";
                FileService.UpdateLanguage(
                    languageDefaultPicker.SelectedIndex,
                    languageTextPicker.SelectedIndex,
                    languageVoicePicker.SelectedIndex
                );
                loadingLabel.Text = "Language successfully replaced!";
            }
        }
        
        private void SelectLanguageDefaultPicker(object sender, EventArgs e)
        {
            languageTextPicker.SelectedItem = languageDefaultPicker.SelectedItem;
            languageVoicePicker.SelectedItem = languageDefaultPicker.SelectedItem;
        }
    }
}