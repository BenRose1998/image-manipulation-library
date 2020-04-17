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
    /// Model Class - The purpose of this class is to store all Image objects in a container & call the ImageManipulator's method to
    /// modify these images.
    /// </summary>
    public class Model : IModel, INewImagesEventPublisher, IDisplayImageEventPublisher
    {
        // DECLARE an IDictionary interface for a Dictionary to store Image objects, call it '_images':
        private IDictionary<int, Image> _images;
        // DECLARE an IImageManipulator interface for the ImageManipulator object, call it '_manipulator':
        private IImageManipulator _manipulator;
        // DECLARE an IImageFactory interface for the ImageFactory object, call it '_imageFactory':
        private IImgFactory _imageFactory;

        // DECLARE an event to store the new images event handler, call it '_newImagesEvent':
        private event EventHandler<NewImagesEventArgs> _newImagesEvent;

        // DECLARE an event to store the display image event handler, call it '_displayImageEvent':
        private event EventHandler<DisplayImageEventArgs> _displayImageEvent;

        public Model()
        {
            // INSTANTIATE '_images' as a new Dictionary to store a key and an Image object:
            _images = new Dictionary<int, Image>();
            // INSTANTIATE '_manipulator' as an instance of ImageManipulator:
            _manipulator = new ImageManipulator();
            // INSTANTIATE '_imageFactory' as an instance of ImageFactory:
            _imageFactory = new ImgFactory();
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

                // Loop - generate a random number, generate a new one if it already exists in the '_images' dictionary:
                do
                {
                    // Generate a random number between 0 - max integer value
                    key = rand.Next(1, int.MaxValue);
                }
                while (_images.ContainsKey(key));

                // Call ImageFactory's Create method to create an image from it's path and add it to the '_images' dictionary (with generated key):
                _images.Add(key, _imageFactory.Create(path));
                // Add the image (resized) to the 'newImages' array:
                newImages.Add(key, _manipulator.Resize(_images[key], 130, 130));
            }
            // Call 'OnNewImages' event, pass newImages dictionary
            OnNewImages(newImages);
        }

        /// <summary>
        /// Return a copy of the image specified by 'key', scaled according to the dimentsions of the visual container (ie frame) it will be viewed in.
        /// </summary>
        /// <param name="key">the unique identifier for the image to be returned</param>
        /// <param name="size">size object, holds width & height of image</param>
        /// <returns>the Image pointed identified by key</returns>
        public void GetImage(int key, Size size)
        {
            // Call ImageManipulator's Resize method, pass the requested image, width and height and return it
            OnDisplayImage(_manipulator.Resize(_images[key], size.Width, size.Height));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="image"></param>
        /// <param name="size"></param>
        /// <param name="flipVertical"></param>
        public void FlipImage(int key, Boolean flipVertical)
        {
            _images[key] = _manipulator.Flip(_images[key], flipVertical);
            ImageUpdated(key);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="degrees"></param>
        public void RotateImage(int key, int degrees)
        {
            _images[key] = _manipulator.Rotate(_images[key], degrees);
            ImageUpdated(key);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="size"></param>
        public void ScaleImage(int key, Size size)
        {
            _images[key] = _manipulator.Resize(_images[key], size.Width, size.Height, true);
            ImageUpdated(key);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="filePath"></param>
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
        /// Calls OnDisplayImage and OnNewImages methods, triggering events (and passing the image) so that form image can be updated
        /// </summary>
        /// <param name="key">unique identifier of image</param>
        private void ImageUpdated(int key)
        {
            OnDisplayImage(_images[key]);
            OnNewImages(new Dictionary<int, Image>() { { key, _images[key] } });
        }

        /// <summary>
        /// Called when new images are loaded
        /// </summary>
        /// <param name="data">The image</param>
        private void OnNewImages(IDictionary<int, Image> imgs)
        {
            NewImagesEventArgs imageArgs = new NewImagesEventArgs(imgs);
            _newImagesEvent(this, imageArgs);
        }

        /// <summary>
        /// Called when image is to be displayed
        /// </summary>
        /// <param name="data">The image</param>
        private void OnDisplayImage(Image img)
        {
            DisplayImageEventArgs imageArgs = new DisplayImageEventArgs(img);
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
