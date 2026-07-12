using System;
using System.Windows.Forms;

namespace Parcial2
{
    internal static class ProgramForms
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new CFormPrincipal());
        }
    }
}
