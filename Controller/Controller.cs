using ModelLibrary;
using ViewLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// COMP3304 Assessment Final Milestone - by Ben Rose
/// </summary>
namespace ControllerLibrary
{
    /// <summary>
    /// Controller - A high level class used to instantiate all main classes.
    /// </summary>
    public class Controller
    {
        // DECLARE an instance of the IModel interface, call it '_model':
        private IModel _model;

        // DECLARE an instance of the IServiceLocator interface, call it '_factoryLocator':
        private IServiceLocator _factoryLocator;

        // DECLARE an instance of the IImageViewer interface, call it '_viewer':
        private IImageViewer _viewer;

        public Controller()
        {
            // INSTANTIATE '_model', with a new instance of Model:
            _model = new Model();

            // INSTANTIATE '_factoryLocator', with a new instance of FactoryLocator:
            _factoryLocator = new FactoryLocator();

            // INSTANTIATE '_viewer', with a new instance of ImageViewer
            _viewer = (_factoryLocator.Get<IImageViewer>() as IFactory<IImageViewer>).Create<ImageViewer>();
            // Initialise '_viewer', setting image key to 0 (as default) and passing delegates:
            _viewer.Initialise(0, ExecuteCommand, RequestImage, _model.FlipImage, _model.RotateImage, _model.ScaleImage, _model.SaveImage);

            // Subscribe '_viewer' as a listener to the OnDisplayImage event:
            (_model as IDisplayImageEventPublisher).Subscribe((_viewer as IDisplayImageEventListener).OnDisplayImage);

            // DECLARE & INSTANTIATE 'collectionViewer', pass delegates:
            CollectionView collectionViewer = new CollectionView(ExecuteCommand, _model.Load, DisplayImage);
            // Subscribe 'collectionViewer' as a listener to the OnNewImages event:
            (_model as INewImagesEventPublisher).Subscribe((collectionViewer as INewImagesEventListener).OnNewImages);

            // Run the application, passing collectionViewer as the main form:
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

        /// <summary>
        /// Implementation of DisplayImageDelegate
        /// </summary>
        /// <param name="key">The key of image to be displayed</param>
        public void DisplayImage(int key)
        {
            // Check if the ImageViewer form has been disposed (user exited window)
            if ((_viewer as Form).IsDisposed)
            {
                // Update '_viewer's image key
                _viewer.UpdateKey(key);
                // Show the '_viewer' form
                (_viewer as Form).Show();
            }
            // Call IImageViewer's 'UpdateKey' method to pass a new image key
            _viewer.UpdateKey(key);
            Console.WriteLine(key);
            // Call ImageViewer's form Show method to display the form
            (_viewer as Form).Show();
        }

        /// <summary>
        /// Implementation of RequestImageDelegate
        /// </summary>
        /// <param name="key">The key of image being requested</param>
        /// <param name="size">Size image should be (width & height)</param>
        public void RequestImage(int key, Size size)
        {
            // Call Model's GetImage method, pass the image key and requested image size
            _model.GetImage(key, size);
        }

    }
}
