using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using ImageProcessor;
using ImageProcessor.Imaging;

/// <summary>
/// COMP3304 Assessment Final Milestone - by Ben Rose
/// </summary>
namespace ModelLibrary
{
    /// <summary>
    /// Image Manipulator - This class works as a wrapper or API around the ImageProcessor library.
    /// </summary>
    public class ImageManipulator : IImageManipulator
    {
        // DECLARE an variable of type ImageFactory to hold a reference to the ImageProcessor's ImageFactory class, call it '_imageFactory':
        private ImageFactory _imageFactory;

        public ImageManipulator()
        {
            // INSTANTIATE '_imageFactory' as an instance of ImageFactory
            _imageFactory = new ImageFactory();
        }

        /// <summary>
        /// Receives an Image and a desired width and height, uses ImageProcessor library to resize the image and it is returned
        /// </summary>
        /// <param name="image">The image</param>
        /// <param name="size">Width and height values stored in Size object</param>
        /// <param name="stretch">Whether or not to stretch the image or maintain aspect ratio (defaulted to false)</param>
        /// <returns>The editted image</returns>
        public Image Resize(Image image, Size size, Boolean stretch = false)
        {
            // DECLARE & INSTANTIATE a Stream, call it 'stream'. Make it a new MemoryStream to store the image sent from the ImageFactory when saved:
            Stream stream = new MemoryStream();

            // DECLARE & INSTANTIATE a ResizeLayer, call it 'resizeLayer'. 
            // Pass 'size', set to ResizeMode to 'Stretch' if 'stretch' parameter was set to true, else set to 'Pad':
            ResizeLayer resizeLayer = new ResizeLayer(size, stretch ? ResizeMode.Stretch : ResizeMode.Pad);

            // Load the image into the ImageFactory, resize it by passing the size object and save it to the stream object
            _imageFactory.Load(image).Resize(resizeLayer).Save(stream);

            // Convert the stream back to an Image object
            Image img = Image.FromStream(stream);

            // Return the image
            return img;
        }

        /// <summary>
        /// Receives an Image and a boolean, uses ImageProcessor library to flip the image and it is returned
        /// </summary>
        /// <param name="image">The image</param>
        /// <param name="flipVertical">Whether or not to vertically flip the image (or flip horizontally)</param>
        /// <returns>The editted image</returns>
        public Image Flip(Image image, Boolean flipVertical)
        {
            // DECLARE & INSTANTIATE a Stream, call it 'stream'. Make it a new MemoryStream to store the image sent from the ImageFactory when saved:
            Stream stream = new MemoryStream();

            // Load the image into the ImageFactory, resize it by passing the size object and save it to the stream object
            _imageFactory.Load(image).Flip(flipVertical).Save(stream);

            // Convert the stream back to an Image object
            Image img = Image.FromStream(stream);

            // Return the image
            return img;
        }

        /// <summary>
        /// Receives an Image and an int (degrees), uses ImageProcessor library to rotate the image and it is returned
        /// </summary>
        /// <param name="image">The image</param>
        /// <param name="degrees">The amount of rotation in degrees</param>
        /// <returns>The editted image</returns>
        public Image Rotate(Image image, int degrees)
        {
            // DECLARE & INSTANTIATE a Stream, call it 'stream'. Make it a new MemoryStream to store the image sent from the ImageFactory when saved:
            Stream stream = new MemoryStream();

            // Load the image into the ImageFactory, resize it by passing the size object and save it to the stream object
            _imageFactory.Load(image).Rotate(degrees).Save(stream);

            // Convert the stream back to an Image object
            Image img = Image.FromStream(stream);

            // Return the image
            return img;
        }

    }
}
