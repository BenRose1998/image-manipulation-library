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
        // Move this code to a new class
        private IModel _model;

        private FilePathHandler _fileHandler;

        public Controller()
        {
            
            //pathfilenames.add("../../assets/JavaFish.png");

            _model = new Model();

            _fileHandler = new FilePathHandler(_model);

            //

            

            //Image img = _model.getImage(keys[0], 480, 320);

            Application.Run(new ImageViewer(_fileHandler));
        }
    }
}
