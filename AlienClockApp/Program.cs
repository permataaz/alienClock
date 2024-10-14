using AlienClockApp;
using System;
using System.Windows.Forms;

namespace AlienClockApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Configures the application to use Windows visual styles
            Application.EnableVisualStyles();

            // Ensures that the application uses default text rendering
            Application.SetCompatibleTextRenderingDefault(false);

            // Starts the application and opens the main form (Form1)
            Application.Run(new AlienClockForm());
        }
    }
}
