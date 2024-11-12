using System;
using System.Windows.Forms;

namespace BreakoutGame
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Ensure the startup form is set to Form1
            Application.Run(new Form1());
        }
    }
}
