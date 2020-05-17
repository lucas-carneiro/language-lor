using System;
using System.Windows.Forms;

namespace LanguageLoR
{
    public partial class MainWindow : Form
    {
        private const string LorPathNotFoundErrorMessage = "Path not found! LoR is probably not installed.";
        private const string LoadingMessage = "Replacing language...";
        private const string FinishedMessage = "Language successfully replaced!";
        public MainWindow()
        {
            InitializeComponent();
            lorInstallPathTextField.Text = FileService.LorInstallPath ?? LorPathNotFoundErrorMessage;
            languageDefaultTextField.Text = LanguageService.DefaultLanguage;
            
            languageTextPicker.Items.AddRange(LanguageService.TextLanguages);
            languageVoicePicker.Items.AddRange(LanguageService.VoiceLanguages);

            languageTextPicker.SelectedItem = LanguageService.DefaultLanguage;
            languageVoicePicker.SelectedItem = LanguageService.DefaultLanguage;
        }

        private void ChangeLanguageButtonClick(object sender, EventArgs e)
        {
            loadingLabel.Text = LoadingMessage;
            FileService.UpdateLanguage(
                languageTextPicker.SelectedIndex,
                languageVoicePicker.SelectedIndex
            );
            loadingLabel.Text = FinishedMessage;
        }
    }
}