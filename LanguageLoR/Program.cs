using System;
using System.Windows.Forms;

namespace LanguageLoR
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            RegistryService.Init();
            FileService.Init(RegistryService.LorGamePathRegistryValue);
            LanguageService.Init();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }
}