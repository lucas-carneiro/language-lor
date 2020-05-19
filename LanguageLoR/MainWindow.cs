using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace LanguageLoR
{
    public partial class MainWindow : Form
    {
        private const string LorPathNotFoundErrorMessage = "Path not found! LoR is probably not installed.";
        private const string LoadingMessage = "Replacing language...";
        private const string FinishedMessage = "Language successfully replaced!";
        private const string InstructionsLink = "https://github.com/lucas-carneiro/language-lor#instructions";
        public MainWindow()
        {
            InitializeComponent();

            if (LanguageService.InitFailed)
            {
                lorInstallPathTextField.Text = LorPathNotFoundErrorMessage;
                languageTextPicker.Enabled = false;
                languageVoicePicker.Enabled = false;
                changeLanguageButton.Enabled = false;
                return;
            }
            
            lorInstallPathTextField.Text = FileService.LorInstallPath;
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

        private void AboutButtonClick(object sender, EventArgs e)
        {
            new AboutWindow().Show();
        }

        private void InstructionsButtonClick(object sender, EventArgs e)
        {
            Process.Start(InstructionsLink);
        }
    }
}