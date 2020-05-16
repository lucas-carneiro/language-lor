using System;
using System.IO;
using System.Linq;

namespace LanguageLoR
{
    public static class FileService
    {
        private const string LorFolderName = "LoR";
        private const string LocalesPath = "/live/Game/LoR_Data/Plugins/locales/";
        private const string GamePlayDataPath = "/live/PatcherData/PatchableFiles/GamePlayData/";
        private const string EmbeddedGamePlayDataPath = "/live/Game/LoR_Data/StreamingAssets/EmbeddedGamePlayData/";
        
        private static readonly string[] LocalesLanguageExtensions = { ".pak", ".pak.info" };
        public const string LocalizedLanguageFileName = "LocalizedText_";
        private const string LocalizedLanguageExtension = ".bin";
        private const string BackupExtension = ".bkp";

        public static string LorInstallPath { get; private set; }
        public static string LorProgramDataPath { get; private set; }
        public static string[] LanguageFiles { get; private set; }

        public static void Init(string lorInstallPath, string lorProgramDataPath)
        {
            LorInstallPath = lorInstallPath?.Substring(0, lorInstallPath.IndexOf(LorFolderName, StringComparison.Ordinal) + LorFolderName.Length);
            LorProgramDataPath = lorProgramDataPath?.Substring(0, lorProgramDataPath.LastIndexOf('/'));
            LanguageFiles = Directory.GetFiles($"{LorInstallPath}{GamePlayDataPath}", $"{LocalizedLanguageFileName}*{LocalizedLanguageExtension}")
                .Where(s => !s.Contains(LanguageService.NoLocalizedLanguage)).ToArray();
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
            string languageDefault = Path.GetFileName(LanguageFiles[languageDefaultIndex]);
            string languageText = Path.GetFileName(LanguageFiles[languageTextIndex]);

            string defaultLanguagePath = LocalizedLanguageToFile(languageDefault, isEmbedded);
            string newLanguagePath = LocalizedLanguageToFile(languageText, isEmbedded);
            
            ReplaceLanguageFile(newLanguagePath, defaultLanguagePath);
        }

        private static string LocalizedLanguageToFile(string localizedLanguage, bool isEmbedded)
        {
            string languagePath = isEmbedded ? EmbeddedGamePlayDataPath : GamePlayDataPath;
            return $"{LorInstallPath}{languagePath}{localizedLanguage}";
        }

        private static void UpdateLocalesLanguage(int languageDefaultIndex, int languageTextIndex)
        {
            string languageDefaultFileName = Path.GetFileNameWithoutExtension(LanguageFiles[languageDefaultIndex]);
            string languageTextFileName = Path.GetFileNameWithoutExtension(LanguageFiles[languageTextIndex]);

            string languageDefault = languageDefaultFileName?.Substring(LocalizedLanguageFileName.Length);
            string languageText = languageTextFileName?.Substring(LocalizedLanguageFileName.Length);

            string localeLanguageDefault = LanguageService.LocaleLanguage(languageDefault);
            string localeLanguageText = LanguageService.LocaleLanguage(languageText);

            foreach (string languageExtension in LocalesLanguageExtensions)
            {
                string defaultLanguagePath = $"{LorInstallPath}{LocalesPath}{localeLanguageDefault}{languageExtension}";
                string newLanguagePath = $"{LorInstallPath}{LocalesPath}{localeLanguageText}{languageExtension}";
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