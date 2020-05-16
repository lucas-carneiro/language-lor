namespace LanguageLoR
{
    public class ProductSettingsModel
    {
        public bool AutoPatchingEnabledByPlayer { get; set; }
        public object Dependencies { get; set; }
        public LocaleDataModel LocaleData { get; set; }
        public string PatchingPolicy { get; set; } 
        public string PatchlinePatchingAskPolicy { get; set; } 
        public string ProductInstallFullPath { get; set; } 
        public string ProductInstallRoot { get; set; } 
        public SettingsModel Settings { get; set; }
        public string ShortcutName { get; set; } 
        public bool ShouldRepair { get; set; } 
        
        public class LocaleDataModel
        {
            public string[] AvailableLocales { get; set; } 
            public string DefaultLocale { get; set; }
        }
        
        public class SettingsModel
        {
            public bool CreateShortcut { get; set; } 
            public bool CreateUninstallKey { get; set; } 
            public string Locale { get; set; } 
        }
    }
}