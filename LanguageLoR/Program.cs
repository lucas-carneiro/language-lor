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
            string lorInstallPath = "Path not found! LoR is probably not installed.";
            
            try
            {
                using (RegistryKey lorKey = Registry.CurrentUser.OpenSubKey(LorRegistryKey))
                {
                    if (lorKey != null)
                    {
                        Object installPathObject = lorKey.GetValue(LorRegistryName);
                        lorInstallPath = installPathObject as string ?? lorInstallPath;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            FileService.Init(lorInstallPath);
            LanguageService.Init();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }
}