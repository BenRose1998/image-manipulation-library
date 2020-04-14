using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageManipulationLibrary;

/// <summary>
/// COMP3304 Assessment Final Milestone - by Ben Rose
/// </summary>
namespace ImageManipulationLibrary
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
        /// <param name="pathfilenames">a vector of strings; each string containing path/filename for an image file to be loaded</param>
        public void Load(IList<String> pathfilenames)
        {
            Random rand = new System.Random();

            IDictionary<int, Image> newImages = new Dictionary<int, Image>();

            // Loop through all path file names
            foreach (string path in pathfilenames)
            {
                int key = rand.Next(0, int.MaxValue);

                // 
                if (!_images.ContainsKey(key))
                {
                    // Call ImageFactory's Create method to create an image from it's path and add it to the '_images' dictionary
                    _images.Add(key, _imageFactory.Create(path));
                    newImages.Add(key, _manipulator.Resize(_images[key], 130, 130));
                }
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

        public void FlipVertical(int key)
        {
            _images[key] = _manipulator.Flip(_images[key], true);
        }

        public void FlipHorizontal(int key)
        {
            _images[key] = _manipulator.Flip(_images[key], false);
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
        /// <summary>
        /// Subscribe a listener to image events
        /// </summary>
        /// <param name="listener">references the listener method</param>
        public void Subscribe(EventHandler<NewImagesEventArgs> listener)
        {
            _newImagesEvent += listener;
        }

        /// <summary>
        /// Unsubscribe a listener to image events
        /// </summary>
        /// <param name="listener">references the listener method</param>
        public void Unsubscribe(EventHandler<NewImagesEventArgs> listener)
        {
            _newImagesEvent -= listener;
        }

        /// <summary>
        /// Subscribe a listener to image events
        /// </summary>
        /// <param name="listener">references the listener method</param>
        public void Subscribe(EventHandler<DisplayImageEventArgs> listener)
        {
            _displayImageEvent += listener;
        }

        /// <summary>
        /// Unsubscribe a listener to image events
        /// </summary>
        /// <param name="listener">references the listener method</param>
        public void Unsubscribe(EventHandler<DisplayImageEventArgs> listener)
        {
            _displayImageEvent -= listener;
        }
        #endregion


        /// <summary>
        /// Loops through '_images' container and adds each key to a list of strings, returns this list (returned all image keys)
        /// </summary>
        /// <returns>A string list of all image keys</returns>
        private IList<int> GetKeys()
        {
            // DECLARE & INSTANTIATE an IList container call it 'keys' and make it a List of type string
            IList<int> keys = new List<int>();

            // Loop through all image's keys
            foreach (int key in _images.Keys)
            {
                // Add each key to the 'keys' container
                keys.Add(key);
            }

            // Return all image keys
            return keys;
        }
    }
}
