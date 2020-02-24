using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMP3304Assessment
{
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
