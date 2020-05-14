using System.IO;

namespace LanguageLoR
{
    public static class FileService
    {
        private const string LorFolderName = "LoR";
        private const string GamePlayDataPath = "/live/PatcherData/PatchableFiles/GamePlayData";
        private const string LocalesPath = "/live/Game/LoR_Data/Plugins/locales";
        private const string EmbeddedGamePlayDataPath = "/live/Game/LoR_Data/StreamingAssets/EmbeddedGamePlayData";
        public static string LorInstallPath { get; private set; }
        public static string[] LanguageFiles { get; private set; }

        public static void Init(string lorInstallPath)
        {
            LorInstallPath = lorInstallPath.Substring(0, lorInstallPath.IndexOf(LorFolderName) + LorFolderName.Length);
            LanguageFiles = Directory.GetFiles($"{LorInstallPath}{LocalesPath}", "*.pak");
        }

        public static void UpdateLanguage(string languageDefault, string languageText, string languageVoice)
        {
            throw new System.NotImplementedException();
        }
    }
}