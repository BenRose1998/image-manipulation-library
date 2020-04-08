using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageManipulationLibrary;

/// <summary>
/// COMP3304 Assessment - by Ben Rose & Luke Mitchell
/// </summary>
namespace COMP3304Assessment
{
    /// <summary>
    /// Model Class - The purpose of this class is to store all Image objects in a container & call the ImageManipulator's method to
    /// modify these images.
    /// </summary>
    public class Model : IModel, IEventPublisher
    {
        // DECLARE an IDictionary interface for a Dictionary to store Image objects, call it '_images':
        private IDictionary<int, Image> _images;
        // DECLARE an IImageManipulator interface for the ImageManipulator object, call it '_manipulator':
        private IImageManipulator _manipulator;
        // DECLARE an IImageFactory interface for the ImageFactory object, call it '_imageFactory':
        private IImageFactory _imageFactory;

        // DECLARE an event to store image event handlers, call it '_imageEvent':
        private event EventHandler<ImageEventArgs> _imageEvent;

        public Model()
        {
            // INSTANTIATE '_images' as a new Dictionary to store a key and an Image object:
            _images = new Dictionary<int, Image>();
            // INSTANTIATE '_manipulator' as an instance of ImageManipulator:
            _manipulator = new ImageManipulator();
            // INSTANTIATE '_imageFactory' as an instance of ImageFactory:
            _imageFactory = new ImageFactory();
        }

        /// <summary>
        /// Load the media items pointed to by 'pathfilenames' into the 'Model'
        /// </summary>
        /// <param name="pathfilenames">a vector of strings; each string containing path/filename for an image file to be loaded</param>
        /// <returns>the unique identifiers of the images that have been loaded</returns>
        public IList<int> load(IList<String> pathfilenames)
        {
            Random rand = new System.Random();
            // Loop through all path file names
            foreach (string path in pathfilenames)
            {
                int key = rand.Next(0, int.MaxValue);

                if (!_images.ContainsKey(key))
                {
                    // Call ImageFactory's Create method to create an image from it's path and add it to the '_images' dictionary
                    _images.Add(key, _imageFactory.Create(path));
                    OnNewImage(_manipulator.Flip(_manipulator.Resize(_images[key], 130, 130)), key);
                }
            }
            
            // Return all image keys
            return GetKeys();
        }

        /// <summary>
        /// Return a copy of the image specified by 'key', scaled according to the dimentsions of the visual container (ie frame) it will be viewed in.
        /// </summary>
        /// <param name="key">the unique identifier for the image to be returned</param>
        /// <param name="frameWidth">the width (in pixels) of the 'frame' it is to occupy</param>
        /// <param name="frameHeight">the height (in pixles) of the 'frame' it is to occupy</param>
        /// <returns>the Image pointed identified by key</returns>
        public void getImage(int key, int frameWidth, int frameHeight)
        {
            // Call ImageManipulator's Resize method, pass the requested image, width and height and return it
            OnDisplayImage(_manipulator.Flip(_manipulator.Resize(_images[key], frameWidth, frameHeight)));
        }


        /// <summary>
        /// Called when new image is recieved
        /// </summary>
        /// <param name="data">The image</param>
        private void OnNewImage(Image img, int key)
        {
            ImageEventArgs imageArgs = new ImageEventArgs(img, key);
            _imageEvent(this, imageArgs);
        }

        #region Implements Event Publisher
        /// <summary>
        /// Subscribe a listener to image events
        /// </summary>
        /// <param name="listener">references the listener method</param>
        public void Subscribe(EventHandler<ImageEventArgs> listener)
        {
            _imageEvent += listener;
        }

        /// <summary>
        /// Unsubscribe a listener to image events
        /// </summary>
        /// <param name="listener">references the listener method</param>
        public void Unsubscribe(EventHandler<ImageEventArgs> listener)
        {
            _imageEvent -= listener;
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
