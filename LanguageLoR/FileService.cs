using System;
using System.IO;
using System.Linq;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace LanguageLoR
{
    public static class FileService
    {
        private const string LorFolderName = "LoR";
        private static string _localesPath = "/live/Game/LoR_Data/Plugins/locales/";
        private static string _gamePlayDataPath = "/live/PatcherData/PatchableFiles/GamePlayData/";
        private static string _embeddedGamePlayDataPath = "/live/Game/LoR_Data/StreamingAssets/EmbeddedGamePlayData/";
        private static string _lorProgramDataPath;
        
        private static readonly string[] LocalesLanguageExtensions = { ".pak", ".pak.info" };
        public const string LocalizedLanguageFileName = "LocalizedText_";
        private const string LocalizedLanguageExtension = ".bin";
        private const string BackupExtension = ".bkp";
        private const string LorSettingsFilename = "bacon.live.product_settings.yaml";

        public static string LorInstallPath { get; private set; }
        public static string[] LanguageFiles { get; private set; }
        public static ProductSettingsModel LorSettings { get; private set; }

        public static void Init()
        {
            LorInstallPath = RegistryService.LorInstallPathRegistryValue?
                .Substring(0, RegistryService.LorInstallPathRegistryValue.IndexOf(LorFolderName, StringComparison.Ordinal) + LorFolderName.Length);
            _lorProgramDataPath = RegistryService.LorProgramDataPathRegistryValue?
                .Substring(0, RegistryService.LorProgramDataPathRegistryValue.LastIndexOf('/') + 1);
            
            _localesPath = $"{LorInstallPath}{_localesPath}";
            _gamePlayDataPath = $"{LorInstallPath}{_gamePlayDataPath}";
            _embeddedGamePlayDataPath = $"{LorInstallPath}{_embeddedGamePlayDataPath}";
            
            LanguageFiles = Directory.GetFiles(_gamePlayDataPath, $"{LocalizedLanguageFileName}*{LocalizedLanguageExtension}")
                .Where(s => !s.Contains(LanguageService.NoLocalizedLanguage)).ToArray();

            StreamReader lorSettingsStream = File.OpenText($"{_lorProgramDataPath}{LorSettingsFilename}");
            IDeserializer deserializer = new DeserializerBuilder()
                .WithNamingConvention(UnderscoredNamingConvention.Instance)
                .Build();
            LorSettings = deserializer.Deserialize<ProductSettingsModel>(lorSettingsStream);
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
            string languageDefault = LorSettings.LocaleData.AvailableLocales[languageDefaultIndex];
            string languageText = LanguageFiles[languageTextIndex];

            string languageDefaultFileName = $"{LocalizedLanguageFileName}{languageDefault.ToLower()}{LocalizedLanguageExtension}";
            string languageTextFileName = Path.GetFileName(languageText);

            string defaultLanguagePath = LocalizedLanguageToFile(languageDefaultFileName, isEmbedded);
            string newLanguagePath = LocalizedLanguageToFile(languageTextFileName, isEmbedded);
            
            ReplaceLanguageFile(newLanguagePath, defaultLanguagePath);
        }

        private static string LocalizedLanguageToFile(string localizedLanguage, bool isEmbedded)
        {
            string languagePath = isEmbedded ? _embeddedGamePlayDataPath : _gamePlayDataPath;
            return $"{languagePath}{localizedLanguage}";
        }

        private static void UpdateLocalesLanguage(int languageDefaultIndex, int languageTextIndex)
        {
            string languageTextFileName = Path.GetFileNameWithoutExtension(LanguageFiles[languageTextIndex]);

            string languageDefault = LorSettings.LocaleData.AvailableLocales[languageDefaultIndex];
            string languageText = languageTextFileName?.Substring(LocalizedLanguageFileName.Length);

            string localeLanguageDefault = LanguageService.LocaleLanguage(languageDefault);
            string localeLanguageText = LanguageService.LocaleLanguage(languageText);

            foreach (string languageExtension in LocalesLanguageExtensions)
            {
                string defaultLanguagePath = $"{_localesPath}{localeLanguageDefault}{languageExtension}";
                string newLanguagePath = $"{_localesPath}{localeLanguageText}{languageExtension}";
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