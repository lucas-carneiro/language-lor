using System;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace LanguageLoR
{
    public partial class MainWindow : Form
    {
        public MainWindow(string lorInstallPath, string[] languageFiles)
        {
            InitializeComponent();
            lorInstallPathTextField.Text = lorInstallPath;
            foreach (string languageFile in languageFiles)
            {
                string languageFileName = Path.GetFileNameWithoutExtension(languageFile);
                if (languageFileName != null)
                {
                    string languageName = new CultureInfo(languageFileName).EnglishName;
                    languageDefaultPicker.Items.Add(languageName);
                    languageTextPicker.Items.Add(languageName);
                    languageVoicePicker.Items.Add(languageName);
                }
            }
        }

        private void ChangeLanguageButtonClick(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
        private void SelectLanguageDefaultPicker(object sender, EventArgs e)
        {
            languageTextPicker.SelectedIndex = languageDefaultPicker.SelectedIndex;
            languageVoicePicker.SelectedIndex = languageDefaultPicker.SelectedIndex;
        }
    }
}