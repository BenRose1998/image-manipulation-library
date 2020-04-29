using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// COMP3304 Assessment Final Milestone - by Ben Rose
/// </summary>
namespace ModelLibrary
{
    /// <summary>
    /// ImageHandler - Stores images in a container, images can be loaded, retrieved or updated.
    /// </summary>
    class ImageHandler : IImageLoader, IImageRetriever, IImageUpdater
    {
        // DECLARE an IDictionary interface for a Dictionary to store Image objects, call it '_images':
        private IDictionary<int, Image> _images;

        // DECLARE an IServiceLocator for the FactoryLocator, call it '_factoryLocator':
        private IServiceLocator _factoryLocator;

        public ImageHandler(IServiceLocator factoryLocator)
        {
            // INSTANTIATE '_images' as a new Dictionary to store a key and an Image object:
            _images = new Dictionary<int, Image>();

            // INSTANTIATE '_factoryLocator' with passed IServiceLocator
            _factoryLocator = factoryLocator;
        }

        /// <summary>
        /// Load the images pointed to by 'pathfilenames' into '_images' container
        /// </summary>
        /// <param name="pathfilenames">a list of strings; each string containing path/filename for an image file to be loaded</param>
        /// <returns>a Dictionary of loaded images, indexed by their key</returns>
        public IDictionary<int, Image> Load(IList<String> pathfilenames)
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

                // Add the image to the 'newImages' array:
                newImages.Add(key, _images[key]);
            }
            // Return the 'newImages' Dictionary
            return newImages;
        }

        /// <summary>
        /// Return an image specified by a key
        /// </summary>
        /// <param name="key">the unique identifier for the image</param>
        /// <returns>the images being requested</returns>
        public Image Get(int key)
        {
            // Return the requested image (specified by key)
            return _images[key];
        }

        /// <summary>
        /// Update an image (specified by key) to the image passed
        /// </summary>
        /// <param name="key">the unique identifier for the image</param>
        /// <param name="image">the image to update to</param>
        public void Update(int key, Image image)
        {
            // Update the image
            _images[key] = image;
        }
    }
}
