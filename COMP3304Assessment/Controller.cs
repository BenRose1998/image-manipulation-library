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

        private IList<String> _fileNames;

        private IModel _model;

        

        public Controller()
        {
            // DECLARE & INSTANTIATE '_model', with a new instance of Model
            _model = new Model();
            // DECLARE & INSTANTIATE '_fileHandler', with a new instance of FilePathHandler, pass it a reference to '_model'
            //IFilePathAdder _fileHandler = new FilePathHandler(_model);
            // DECLARE & INSTANTIATE '_imageHandler', with a new instance of ImageHandler, pass it a reference to '_fileHandler' & '_model'
            //IImageGetter _imageHandler = new ImageHandler(_fileHandler as IFilePathGetter, _model);

            _fileNames = new List<String>();

            /* 
             * Run the application and pass it a reference to a new ImageViewer form. 
             * Pass this ImageViewer a reference to the FilePathHandler & ImageHandler instances.
            */

            //ImageViewer viewer = new ImageViewer(ExecuteCommand, _fileHandler.Add, _imageHandler.RetrieveImage, (_imageHandler as IImageSetter).NextImage, (_imageHandler as IImageSetter).PreviousImage);

            // Subscribe Viewer form's OnNewImage method to the ImageHandler event
            //(_imageHandler as IEventPublisher).Subscribe((viewer as IEventListener).OnNewImage);

            CollectionView collectionViewer = new CollectionView(ExecuteCommand, AddImage);
            (_model as IEventPublisher).Subscribe((collectionViewer as IEventListener).OnNewImage);
            Application.Run(collectionViewer);
        }

        /// <summary>
        /// Implementation of ExecuteDelegate (Command pattern)
        /// </summary>
        /// <param name="command">The command</param>
        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
        }


        public void AddImage(String file, Size size)
        {
            //_fileNames.Add(file);

            _model.load(new List<String> { file });

            //_model.getImage(key, size.Width, size.Height);
        }

        public void DisplayImage(int key)
        {
            new ImageViewer()
            _model.getImage(key, 400, 400);
        }

    }
}
