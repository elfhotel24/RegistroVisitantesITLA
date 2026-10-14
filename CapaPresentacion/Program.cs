using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Iniciar la aplicación con el formulario de login
            Application.Run(new Form1());
        }
    }
}
