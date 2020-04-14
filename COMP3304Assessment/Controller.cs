using ImageManipulationLibrary;
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
namespace COMP3304Assessment
{
    /// <summary>
    /// Controller - A high level class used to instantiate all main classes.
    /// </summary>
    class Controller
    {
        // DECLARE an instance of the IModel interface, call it '_model':
        private IModel _model;
        // DECLARE an instance of the IImageViewer interface, call it '_viewer':
        private IImageViewer _viewer;

        public Controller()
        {
            // DECLARE & INSTANTIATE '_model', with a new instance of Model:
            _model = new Model();

            // DECLARE & INSTANTIATE '_viewer', with a new instance of ImageViewer, set image key to default of 0, pass delegates:
            _viewer = new ImageViewer(0, ExecuteCommand, RequestImage, _model.FlipImage);
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
                // Re-instantiate '_viewer' as a new viewer
                _viewer = new ImageViewer(key, ExecuteCommand, RequestImage, _model.FlipImage);
                // Re-subscribe '_viewer' as an listener to the OnDisplayImage event
                (_model as IDisplayImageEventPublisher).Subscribe((_viewer as IDisplayImageEventListener).OnDisplayImage);
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
