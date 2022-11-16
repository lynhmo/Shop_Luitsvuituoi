using System;
using System.Windows.Forms;


namespace Shop_Luitsvuituoi
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
            //Application.Run(new Login());
            //Application.Run(new KhachHang());
        }
    }
}
