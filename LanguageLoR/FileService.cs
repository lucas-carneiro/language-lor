using System.IO;

namespace LanguageLoR
{
    public static class FileService
    {
        private const string LorFolderName = "LoR";
        private const string GamePlayDataPath = "/live/PatcherData/PatchableFiles/GamePlayData/";
        private const string LocalesPath = "/live/Game/LoR_Data/Plugins/locales/";
        private const string EmbeddedGamePlayDataPath = "/live/Game/LoR_Data/StreamingAssets/EmbeddedGamePlayData/";
        private const string BackupExtension = ".bkp";
        private static readonly string[] LanguageExtensions = { ".pak", ".pak.info" };
        public static string LorInstallPath { get; private set; }
        public static string[] LanguageFiles { get; private set; }

        public static void Init(string lorInstallPath)
        {
            LorInstallPath = lorInstallPath.Substring(0, lorInstallPath.IndexOf(LorFolderName) + LorFolderName.Length);
            LanguageFiles = Directory.GetFiles($"{LorInstallPath}{LocalesPath}", $"*{LanguageExtensions[0]}");
        }

        public static void UpdateLanguage(int languageDefaultIndex, int languageTextIndex, int languageVoiceIndex)
        {
            string languageDefault = Path.GetFileNameWithoutExtension(LanguageFiles[languageDefaultIndex]);
            string languageText = Path.GetFileNameWithoutExtension(LanguageFiles[languageTextIndex]);
            string languageVoice = Path.GetFileNameWithoutExtension(LanguageFiles[languageVoiceIndex]);
            
            foreach (string languageExtension in LanguageExtensions)
            {
                string defaultLanguagePath = $"{LorInstallPath}{LocalesPath}{languageDefault}{languageExtension}";
                string newLanguagePath = $"{LorInstallPath}{LocalesPath}{languageText}{languageExtension}";
                string backupPath = $"{defaultLanguagePath}{BackupExtension}";
                File.Replace(
                    newLanguagePath,
                    defaultLanguagePath,
                    File.Exists(backupPath) ? null : backupPath);
            }
        }
    }
}