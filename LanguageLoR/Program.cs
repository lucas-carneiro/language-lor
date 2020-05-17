using System;
using System.Windows.Forms;

namespace LanguageLoR
{
    static class Program
    {
        public const string Version = "1.0.0";
        [STAThread]
        static void Main()
        {
            RegistryService.Init();
            FileService.Init();
            LanguageService.Init();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }
}