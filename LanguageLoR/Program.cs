using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;

namespace LanguageLoR
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string lorInstallPath = "Path not found! LoR is probably not installed.";
            
            try
            {
                string lorRegistryKey = "Software\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\Riot Game bacon.live";
                using (RegistryKey lorKey = Registry.CurrentUser.OpenSubKey(lorRegistryKey))
                {
                    if (lorKey != null)
                    {
                        Object installPathObject = lorKey.GetValue("InstallLocation");
                        lorInstallPath = installPathObject as string ?? lorInstallPath;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            string[] languageFiles = Directory.GetFiles($"{lorInstallPath}/LoR_Data/Plugins/locales", "*.pak");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow(lorInstallPath, languageFiles));
        }
    }
}