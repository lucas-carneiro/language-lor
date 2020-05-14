using System.IO;

namespace LanguageLoR
{
    public static class FileService
    {
        private const string LocalesPath = "/LoR_Data/Plugins/locales";
        public static string LorInstallPath { get; private set; }
        public static string[] LanguageFiles { get; private set; }

        public static void Init(string lorInstallPath)
        {
            LorInstallPath = lorInstallPath;
            LanguageFiles = Directory.GetFiles($"{LorInstallPath}{LocalesPath}", "*.pak");
        }

        public static void UpdateLanguage(string languageDefault, string languageText, string languageVoice)
        {
            throw new System.NotImplementedException();
        }
    }
}