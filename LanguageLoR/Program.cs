using System;
using System.Windows.Forms;
using Microsoft.Win32;

namespace LanguageLoR
{
    static class Program
    {
        private const string LorRegistryKey = "Software\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\Riot Game bacon.live";
        private const string LorRegistryName = "InstallLocation";

        [STAThread]
        static void Main()
        {
            string lorRegistryValue = "Path not found! LoR is probably not installed.";
            
            try
            {
                using (RegistryKey lorKey = Registry.CurrentUser.OpenSubKey(LorRegistryKey))
                {
                    if (lorKey != null)
                    {
                        Object installPathObject = lorKey.GetValue(LorRegistryName);
                        lorRegistryValue = installPathObject as string ?? lorRegistryValue;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            FileService.Init(lorRegistryValue);
            LanguageService.Init();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }
}