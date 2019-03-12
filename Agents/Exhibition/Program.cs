

namespace Exhibition
{
    using Exhibition.Core.Configuration;
    using System;
    using System.Windows.Forms;
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ExhibitionConfiguration.HostOperationSerivceViaConfiguration();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmConsole());
        }
    }
}
