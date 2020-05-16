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
            for (int i = 0; i < FileService.LanguageFiles.Length; i++)
            {
                string languageFileName = Path.GetFileNameWithoutExtension(FileService.LanguageFiles[i]);
                if (languageFileName != null)
                {
                    Languages[i] = new CultureInfo(languageFileName).EnglishName;
                }
            }
        }

        public static string LocalizeLanguage(string language)
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
    }
}