using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Security.Principal;
using Microsoft.Win32;
using System.Diagnostics;

namespace GetPCStat
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Set run at Window startup
            RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            
            if (rkApp != null)
            {
                // Add the value in the registry so that the application runs at startup
                rkApp.SetValue("GetPCStat", Application.ExecutablePath.ToString());
            }

            Application.Run(new FormMain());
        }
    }
}
