using System.Globalization;
using System.IO;

namespace LanguageLoR
{
    public static class LanguageService
    {
        public static string[] Languages { get; private set; }

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
    }
}