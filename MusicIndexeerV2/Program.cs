using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autofac;
using MusicIndexeerV2.Autofac;

namespace MusicIndexeerV2
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (var scope = AutofacScope.Scope)
            {
                Application.Run(scope.Resolve<FormMain>());
            }
        }
    }
}
