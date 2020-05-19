using System.Globalization;
using System.IO;

namespace LanguageLoR
{
    public static class LanguageService
    {
        public const string NoLocalizedLanguage = "no_TX";
        
        public static string[] TextLanguages { get; private set; }
        public static string[] VoiceLanguages { get; private set; }
        public static string DefaultLanguage { get; private set; }
        public static bool InitFailed { get; private set; }

        public static void Init()
        {
            if (FileService.InitFailed)
            {
                InitFailed = true;
                return;
            }
            
            TextLanguages = new string[FileService.LanguageFiles.Length];
            for (int i = 0; i < TextLanguages.Length; i++)
            {
                string languageFileName = Path.GetFileNameWithoutExtension(FileService.LanguageFiles[i]);
                if (languageFileName != null)
                {
                    languageFileName = languageFileName.Substring(FileService.LocalizedLanguageFileName.Length);
                    TextLanguages[i] = new CultureInfo(languageFileName).EnglishName;
                }
            }
            
            VoiceLanguages = new string[FileService.LorSettings.LocaleData.AvailableLocales.Length];
            for (int i = 0; i < VoiceLanguages.Length; i++)
            {
                string languageName = FileService.LorSettings.LocaleData.AvailableLocales[i];
                VoiceLanguages[i] = new CultureInfo(languageName).EnglishName;
            }

            DefaultLanguage = new CultureInfo(FileService.LorSettings.Settings.Locale).EnglishName;
        }

        public static string LocalizedLanguage(string language)
        {
            language = language.ToLower();
            
            if (language.Length == 2)
            {
                switch (language)
                {
                    case "ja":
                        return "ja_jp";
                    case "ko":
                        return "ko_kr";
                    case "vi":
                        return "vi_vn";
                    default:
                        return $"{language}_{language}"; 
                }
            }

            if (language == "es-419") return "es_mx";
            
            return language.Replace('-', '_');
        }

        public static string LocaleLanguage(string language)
        {
            language = language.ToLower();
            
            switch (language)
            {
                case "es_mx":
                    return "es-419";
                case "ja_jp":
                    return "ja";
                case "ko_kr":
                    return "ko";
                case "vi_vn":
                    return "vi";
                default:
                    string[] splitLanguage = language.Split('_');
                    bool isLocalized = splitLanguage[0] != splitLanguage[1];
                    return isLocalized ? $"{splitLanguage[0]}-{splitLanguage[1].ToUpper()}" : splitLanguage[0];
            }
        }
    }
}