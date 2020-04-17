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
namespace ImageManipulationLibrary
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
        /// <param name="image"></param>
        /// <param name="frameWidth"></param>
        /// <param name="frameHeight"></param>
        /// <returns>Returns resized Image</returns>
        public Image Resize(Image image, int frameWidth, int frameHeight, Boolean stretch = false)
        {
            // Create a Size object to store the desired width and height values, call it 'size'
            Size size = new Size(frameWidth, frameHeight);

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
