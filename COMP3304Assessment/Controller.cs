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
        // DECLARE an IModel interface for an instance of Model to be stored in, call it '_model':
        //private IModel _model;
        // DECLARE an IFilePathAdder interface for an instance of FilePathHandler to be stored in, call it '_fileHandler':
        //private IFilePathAdder _fileHandler;
        // DECLARE an IImageDisplaySetter interface for an instance of ImageHandler to be stored in, call it '_imageHandler':
        //private IImageDisplaySetter _imageHandler;

        public Controller()
        {
            // DECLARE & INSTANTIATE '_model', with a new instance of Model
            IModel _model = new Model();
            // DECLARE & INSTANTIATE '_fileHandler', with a new instance of FilePathHandler, pass it a reference to '_model'
            IFilePathAdder _fileHandler = new FilePathHandler(_model);
            // DECLARE & INSTANTIATE '_imageHandler', with a new instance of ImageHandler, pass it a reference to '_fileHandler' & '_model'
            IImageDisplaySetter _imageHandler = new ImageHandler(_fileHandler as IFilePathGetter, _model);

            /* 
             * Run the application and pass it a reference to a new ImageViewer form. 
             * Pass this ImageViewer a reference to the FilePathHandler & ImageHandler instances.
            */
            Application.Run(new ImageViewer(_fileHandler, _imageHandler));
        }
    }
}
