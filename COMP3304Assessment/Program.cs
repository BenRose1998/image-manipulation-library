using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// COMP3304 Assessment - by Ben Rose & Luke Mitchell
/// </summary>
namespace COMP3304Assessment
{
    /// <summary>
    /// Progam - This is where the program starts when executed.
    /// </summary>
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // DECLARE & INSTANIATE a Controller set it to a new instance of Controller, call it 'controller':
            // This class will start the application
            Controller controller = new Controller();
        }
    }
}
