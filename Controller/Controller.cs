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

        // DECLARE an instance of the IDisplayView interface, call it '_viewer':
        private IDisplayView _viewer;

        public Controller()
        {
            // INSTANTIATE '_model', with a new instance of Model:
            _model = new Model();

            // INSTANTIATE '_factoryLocator', with a new instance of FactoryLocator:
            _factoryLocator = new FactoryLocator();

            // INSTANTIATE '_viewer', with a new instance of DisplayView
            _viewer = (_factoryLocator.Get<IDisplayView>() as IFactory<IDisplayView>).Create<DisplayView>();
            // Initialise '_viewer', setting image key to 0 (as default) and passing delegates:
            _viewer.Initialise(0, ExecuteCommand, _model.GetImage, _model.FlipImage, _model.RotateImage, _model.ScaleImage, _model.SaveImage);

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
        /// Implementation of DisplayImageDelegate (Strategy Pattern)
        /// </summary>
        /// <param name="key">The key of image to be displayed</param>
        public void DisplayImage(int key)
        {
            // Check if the '_viewer' has been disposed (user exited window)
            if ((_viewer as Form).IsDisposed)
            {
                // RE-INSTANTIATE '_viewer', with a new instance of DisplayView
                _viewer = (_factoryLocator.Get<IDisplayView>() as IFactory<IDisplayView>).Create<DisplayView>();
                // Initialise '_viewer', setting image key to the key parameter and passing delegates:
                _viewer.Initialise(key, ExecuteCommand, _model.GetImage, _model.FlipImage, _model.RotateImage, _model.ScaleImage, _model.SaveImage);
                // Subscribe '_viewer' as a listener to the OnDisplayImage event:
                (_model as IDisplayImageEventPublisher).Subscribe((_viewer as IDisplayImageEventListener).OnDisplayImage);
            }
            // Call IDisplayView's 'UpdateKey' method to pass a new image key
            _viewer.UpdateKey(key);
            // Call DisplayView's form Show method to display the form
            (_viewer as Form).Show();
        }
    }
}
