using System.IO;

namespace LanguageLoR
{
    public static class FileService
    {
        private const string LorFolderName = "LoR";
        private const string LocalesPath = "/live/Game/LoR_Data/Plugins/locales/";
        private const string GamePlayDataPath = "/live/PatcherData/PatchableFiles/GamePlayData/";
        private const string EmbeddedGamePlayDataPath = "/live/Game/LoR_Data/StreamingAssets/EmbeddedGamePlayData/";
        
        private static readonly string[] LocalesLanguageExtensions = { ".pak", ".pak.info" };
        private const string LocalizedLanguageExtension = ".bin";
        private const string BackupExtension = ".bkp";

        public static string LorInstallPath { get; private set; }
        public static string[] LanguageFiles { get; private set; }

        public static void Init(string lorInstallPath)
        {
            LorInstallPath = lorInstallPath.Substring(0, lorInstallPath.IndexOf(LorFolderName) + LorFolderName.Length);
            LanguageFiles = Directory.GetFiles($"{LorInstallPath}{LocalesPath}", $"*{LocalesLanguageExtensions[0]}");
        }

        public static void UpdateLanguage(int languageDefaultIndex, int languageTextIndex, int languageVoiceIndex)
        {
            UpdateLocalesLanguage(languageDefaultIndex, languageTextIndex);
            UpdateGamePlayDataLanguage(languageDefaultIndex, languageTextIndex);
            UpdateEmbeddedGamePlayDataLanguage(languageDefaultIndex, languageTextIndex);
        }

        private static void UpdateEmbeddedGamePlayDataLanguage(int languageDefaultIndex, int languageTextIndex)
        {
            UpdateGamePlayDataLanguage(languageDefaultIndex, languageTextIndex, true);
        }

        private static void UpdateGamePlayDataLanguage(int languageDefaultIndex, int languageTextIndex, bool isEmbedded = false)
        {
            string languageDefault = Path.GetFileNameWithoutExtension(LanguageFiles[languageDefaultIndex]);
            string languageText = Path.GetFileNameWithoutExtension(LanguageFiles[languageTextIndex]);
            
            if (languageDefault == languageText) return;

            string localizedLanguageDefault = LanguageService.LocalizeLanguage(languageDefault);
            string localizedLanguageText = LanguageService.LocalizeLanguage(languageText);

            string defaultLanguagePath = LocalizedLanguageToFile(localizedLanguageDefault, isEmbedded);
            string newLanguagePath = LocalizedLanguageToFile(localizedLanguageText, isEmbedded);
            
            if (defaultLanguagePath == newLanguagePath) return;
            
            ReplaceLanguageFile(newLanguagePath, defaultLanguagePath);
        }

        private static string LocalizedLanguageToFile(string localizedLanguage, bool isEmbedded)
        {
            string languagePath = isEmbedded ? EmbeddedGamePlayDataPath : GamePlayDataPath;
            string file = $"{LorInstallPath}{languagePath}LocalizedText_{localizedLanguage}{LocalizedLanguageExtension}";
            return File.Exists(file) ? file : file.Replace(localizedLanguage, LanguageService.NoLocalizedLanguage);
        }

        private static void UpdateLocalesLanguage(int languageDefaultIndex, int languageTextIndex)
        {
            string languageDefault = Path.GetFileNameWithoutExtension(LanguageFiles[languageDefaultIndex]);
            string languageText = Path.GetFileNameWithoutExtension(LanguageFiles[languageTextIndex]);

            if (languageDefault == languageText) return;
            
            foreach (string languageExtension in LocalesLanguageExtensions)
            {
                string defaultLanguagePath = $"{LorInstallPath}{LocalesPath}{languageDefault}{languageExtension}";
                string newLanguagePath = $"{LorInstallPath}{LocalesPath}{languageText}{languageExtension}";
                ReplaceLanguageFile(newLanguagePath, defaultLanguagePath);
            }
        }

        private static void ReplaceLanguageFile(string newLanguagePath, string defaultLanguagePath)
        {
            string backupPath = $"{defaultLanguagePath}{BackupExtension}";
            
            if (File.Exists(backupPath))
            {
                File.Delete(defaultLanguagePath);
            }
            else
            {
                File.Move(defaultLanguagePath, backupPath);   
            }
            
            File.Copy(newLanguagePath, defaultLanguagePath);
        }
    }
}