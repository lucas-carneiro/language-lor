using System.Globalization;
using System.IO;

namespace LanguageLoR
{
    public static class LanguageService
    {
        public static string[] Languages { get; private set; }
        public const string NoLocalizedLanguage = "no_TX";

        public static void Init()
        {
            Languages = new string[FileService.LanguageFiles.Length];
            for (int i = 0; i < Languages.Length; i++)
            {
                string languageFileName = Path.GetFileNameWithoutExtension(FileService.LanguageFiles[i]);
                if (languageFileName != null)
                {
                    languageFileName = languageFileName.Substring(FileService.LocalizedLanguageFileName.Length);
                    Languages[i] = new CultureInfo(languageFileName).EnglishName;
                }
            }
        }

        public static string LocalizedLanguage(string language)
        {
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
            
            return language.Replace('-', '_').ToLower();
        }

        public static string LocaleLanguage(string language)
        {
            switch (language)
            {
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