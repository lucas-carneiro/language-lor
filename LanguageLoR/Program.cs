using System;
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
            string lorInstallPath = "";
            
            try
            {
                string lorRegistryKey = "Software\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\Riot Game bacon.live";
                using (RegistryKey lorKey = Registry.CurrentUser.OpenSubKey(lorRegistryKey))
                {
                    if (lorKey != null)
                    {
                        Object installPathObject = lorKey.GetValue("InstallLocation");
                        lorInstallPath = installPathObject as string ?? lorInstallPath;
                        Console.WriteLine($"LoR Install Path: {lorInstallPath}");
                    }
                    else
                    {
                        Console.WriteLine("Registry key not found! LoR is probably not installed.");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow(lorInstallPath));
        }
    }
}