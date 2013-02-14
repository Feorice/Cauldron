using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Cauldron
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            CauldronMainForm form = new CauldronMainForm();
            form.Show();
            BGame game = new BGame(form);
            game.Run();
        }
    }
}
