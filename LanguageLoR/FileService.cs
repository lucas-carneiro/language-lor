using System;
using System.IO;
using System.Linq;
using System.Text;
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

            string lorSettingsYaml = File.ReadAllText($"{_lorProgramDataPath}{LorSettingsFilename}");
            IDeserializer deserializer = new DeserializerBuilder()
                .WithNamingConvention(UnderscoredNamingConvention.Instance)
                .Build();
            LorSettings = deserializer.Deserialize<ProductSettingsModel>(lorSettingsYaml);
        }

        public static void UpdateLanguage(int languageTextIndex, int languageVoiceIndex)
        {
            UpdateVoiceLanguage(languageVoiceIndex);
            UpdateLocalesLanguage(languageTextIndex);
            UpdateGamePlayDataLanguage(languageTextIndex);
            UpdateEmbeddedGamePlayDataLanguage(languageTextIndex);
        }

        private static void UpdateVoiceLanguage(int languageVoiceIndex)
        {
            string languageVoice = LorSettings.LocaleData.AvailableLocales[languageVoiceIndex];
            if (LorSettings.Settings.Locale == languageVoice) return;
            LorSettings.Settings.Locale = languageVoice;
            
            ISerializer serializer = new SerializerBuilder()
                .WithNamingConvention(UnderscoredNamingConvention.Instance)
                .Build();
            string lorSettingsYaml = serializer.Serialize(LorSettings);
            
            byte[] lorSettingsByte = new UTF8Encoding(true).GetBytes(lorSettingsYaml);
            File.WriteAllBytes($"{_lorProgramDataPath}{LorSettingsFilename}", lorSettingsByte);
        }

        private static void UpdateEmbeddedGamePlayDataLanguage(int languageTextIndex)
        {
            UpdateGamePlayDataLanguage(languageTextIndex, true);
        }

        private static void UpdateGamePlayDataLanguage(int languageTextIndex, bool isEmbedded = false)
        {
            string languageDefault = LorSettings.Settings.Locale;
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

        private static void UpdateLocalesLanguage(int languageTextIndex)
        {
            string languageTextFileName = Path.GetFileNameWithoutExtension(LanguageFiles[languageTextIndex]);

            string languageDefault = LorSettings.Settings.Locale;
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