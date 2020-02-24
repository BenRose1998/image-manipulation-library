using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// COMP3304 Assessment - by Ben Rose & Luke Mitchell
/// </summary>
namespace COMP3304Assessment
{
    /// <summary>
    /// Controller - A high level class used to instantiate all main classes.
    /// </summary>
    class Controller
    {
        // ---------
        // Variables
        // ---------

        // Move this code to a new class

        private IModel _model;

        private IFilePathAdder _fileHandler;

        private IImageHandler ImageHandler;


        // ------------
        // Constructor
        // ------------
        public Controller()
        {
            //
            _model = new Model();

            //
            _fileHandler = new FilePathHandler(_model);

            // 
            ImageHandler = new ImageHandler(_fileHandler as IFilePathGetter, _model.getImage);

            //
            Application.Run(new ImageViewer(_fileHandler, ImageHandler));
        }
    }
}
