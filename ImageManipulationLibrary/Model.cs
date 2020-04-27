using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// COMP3304 Assessment Final Milestone - by Ben Rose
/// </summary>
namespace ModelLibrary
{
    /// <summary>
    /// Model Class - The purpose of this class is to store all Image objects in a container & call the ImageManipulator's methods to
    /// modify the images. Events are triggered to pass images to the Views.
    /// </summary>
    public class Model : IModelLoader, IModelRetriever, IModelEditor, INewImagesEventPublisher, IDisplayImageEventPublisher
    {
        // DECLARE an IDictionary interface for a Dictionary to store Image objects, call it '_images':
        private IDictionary<int, Image> _images;
        // DECLARE an IImageManipulator interface for the ImageManipulator object, call it '_manipulator':
        private IImageManipulator _manipulator;
        // DECLARE an IServiceLocator for the FactoryLocator, call it '_factoryLocator':
        private IServiceLocator _factoryLocator;

        // DECLARE an event to store the new images event handler, call it '_newImagesEvent':
        private event EventHandler<NewImagesEventArgs> _newImagesEvent;
        // DECLARE an event to store the display image event handler, call it '_displayImageEvent':
        private event EventHandler<DisplayImageEventArgs> _displayImageEvent;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="factoryLocator">Used to access factories for object creation</param>
        public Model(IServiceLocator factoryLocator)
        {
            // INSTANTIATE '_images' as a new Dictionary to store a key and an Image object:
            _images = new Dictionary<int, Image>();
            // INSTANTIATE '_manipulator' as an instance of ImageManipulator:
            _manipulator = new ImageManipulator();
            // INSTANTIATE '_factoryLocator' with passed IServiceLocator
            _factoryLocator = factoryLocator;
        }

        /// <summary>
        /// Load the media items pointed to by 'pathfilenames' into the 'Model'
        /// </summary>
        /// <param name="pathfilenames">a list of strings; each string containing path/filename for an image file to be loaded</param>
        public void Load(IList<String> pathfilenames)
        {
            // DECLARE & INSTANTIATE an a Random object, call it 'rand':
            Random rand = new System.Random();

            // DECLARE & INSTANTIATE an IDictionary with a new Dictionary to store a key (int) and an Image, call it 'newImages':
            IDictionary<int, Image> newImages = new Dictionary<int, Image>();

            // Loop through all path file names
            foreach (string path in pathfilenames)
            {
                // DECLARE an integer call it 'key', unique identifier for each image
                int key;

                // Do While Loop - generate a random number, generate a new one if it already exists in the '_images' dictionary:
                do
                {
                    // Generate a random number between 0 and max integer value
                    key = rand.Next(1, int.MaxValue);
                }
                while (_images.ContainsKey(key));

                // Get Image factory using '_factoryLocator', call ImageFactory's Create method to create an image from it's path
                // and add it to the '_images' dictionary (with generated key):
                _images.Add(key, (_factoryLocator.Get<Image>() as IImgFactory).Create(path));

                // Add the image (resized to low-res) to the 'newImages' array:
                newImages.Add(key, _manipulator.Resize(_images[key], new Size(100, 100)));
            }
            // Call 'OnNewImages' event method, pass newImages dictionary
            OnNewImages(newImages);
        }

        /// <summary>
        /// Trigger OnDisplayImage event passing the image defined by 'key', scaled to the Size object passed
        /// </summary>
        /// <param name="key">the unique identifier for the image</param>
        /// <param name="size">size object, holds width & height of image</param>
        public void GetImage(int key, Size size)
        {
            // Call ImageManipulator's Resize method, pass the requested image and size
            // Call the OnDisplayImage event method, pass the editted image
            OnDisplayImage(_manipulator.Resize(_images[key], size));
        }

        /// <summary>
        /// Flip image based on specified orientation
        /// </summary>
        /// <param name="key">the unique identifier for the image</param>
        /// <param name="flipVertical">Whether to flip vertically (or horizontally)</param>
        public void FlipImage(int key, Boolean flipVertical)
        {
            // Call ImageManipulator's Flip method, pass the requested image, and flipVertical
            _images[key] = _manipulator.Flip(_images[key], flipVertical);
            // Call ImageUpdated, pass the key, this will trigger events to update the image on the forms
            ImageUpdated(key);
        }

        /// <summary>
        /// Rotate image based on specified amount in degrees
        /// </summary>
        /// <param name="key">the unique identifier for the image</param>
        /// <param name="degrees">Amount of rotation in degrees</param>
        public void RotateImage(int key, int degrees)
        {
            // Call ImageManipulator's Rotate method, pass the requested image, and degrees
            _images[key] = _manipulator.Rotate(_images[key], degrees);
            // Call ImageUpdated, pass the key, this will trigger events to update the image on the forms
            ImageUpdated(key);
        }

        /// <summary>
        /// Scale image based on specified values of Size object
        /// </summary>
        /// <param name="key">the unique identifier for the image</param>
        /// <param name="size">Scaling values as Size object</param>
        public void ScaleImage(int key, Size size)
        {
            // Call ImageManipulator's Resize method, pass the requested image, size
            // Pass a value of true for the stretch parameter so that the image's aspect ratio is not maintained
            _images[key] = _manipulator.Resize(_images[key], size, true);
            // Call ImageUpdated, pass the key, this will trigger events to update the image on the forms
            ImageUpdated(key);
        }

        /// <summary>
        /// Save an Image to a file
        /// </summary>
        /// <param name="key">the unique identifier for the image</param>
        /// <param name="filePath">the directory path and file name in which to save the image</param>
        public void SaveImage(int key, String filePath)
        {
            // Create an ImageFormat variable call it 'format', default it to a Jpeg format:
            ImageFormat format = ImageFormat.Jpeg;

            // Extract file path extension
            string extension = System.IO.Path.GetExtension(filePath);

            // Check if the extension is '.png':
            if (extension == ".png")
            {
                // Set format to Png format:
                format = ImageFormat.Png;
            }

            // Save image to file
            _images[key].Save(filePath, format);
        }

        /// <summary>
        /// Calls OnDisplayImage and OnNewImages methods, triggering events (and passing the image) so that each form's image can be updated
        /// </summary>
        /// <param name="key">the unique identifier for the image</param>
        private void ImageUpdated(int key)
        {
            // Call OnDisplayImage event method, pass image of specified key
            OnDisplayImage(_images[key]);
            // Call OnNewImages event method, pass an Dictionary of images populated with the image of the specified key, pass as an IDictionary
            OnNewImages(new Dictionary<int, Image>() { { key, _images[key] } } as IDictionary<int, Image>);
        }

        /// <summary>
        /// Called when new images are loaded or images are editted
        /// </summary>
        /// <param name="imgs">The images</param>
        private void OnNewImages(IDictionary<int, Image> imgs)
        {
            // DECLARE & INSTANTIATE a NewImageEventArgs, pass in 'imgs':
            NewImagesEventArgs imageArgs = new NewImagesEventArgs(imgs);
            // Trigger the event passing this (sender) and the 'imageArgs':
            _newImagesEvent(this, imageArgs);
        }

        /// <summary>
        /// Called when image is to be displayed
        /// </summary>
        /// <param name="img">The image</param>
        private void OnDisplayImage(Image img)
        {
            // DECLARE & INSTANTIATE a DisplayImageEventArgs, pass in 'img':
            DisplayImageEventArgs imageArgs = new DisplayImageEventArgs(img);
            // Trigger the event passing this (sender) and the 'imageArgs':
            _displayImageEvent(this, imageArgs);
        }

        #region Implements Event Publishers & Listeners
        // -----------------------------------------------------------------------------------
        // NewImagesEvent

        /// <summary>
        /// Subscribe a listener to NewImagesEvent
        /// </summary>
        /// <param name="listener">references the listener method</param>
        public void Subscribe(EventHandler<NewImagesEventArgs> listener)
        {
            _newImagesEvent += listener;
        }

        /// <summary>
        /// Unsubscribe a listener to NewImagesEvent
        /// </summary>
        /// <param name="listener">references the listener method</param>
        public void Unsubscribe(EventHandler<NewImagesEventArgs> listener)
        {
            _newImagesEvent -= listener;
        }

        // -----------------------------------------------------------------------------------
        // DisplayImageEvent

        /// <summary>
        /// Subscribe a listener to DisplayImageEvent
        /// </summary>
        /// <param name="listener">references the listener method</param>
        public void Subscribe(EventHandler<DisplayImageEventArgs> listener)
        {
            _displayImageEvent += listener;
        }

        /// <summary>
        /// Unsubscribe a listener to DisplayImageEvent
        /// </summary>
        /// <param name="listener">references the listener method</param>
        public void Unsubscribe(EventHandler<DisplayImageEventArgs> listener)
        {
            _displayImageEvent -= listener;
        }
        #endregion

    }
}
