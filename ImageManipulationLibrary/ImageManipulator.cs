using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using ImageProcessor;

namespace ImageManipulationLibrary
{
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
        /// 
        /// </summary>
        /// <param name="image"></param>
        /// <param name="frameWidth"></param>
        /// <param name="frameHeight"></param>
        /// <returns></returns>
        public Image Resize(Image image, int frameWidth, int frameHeight)
        {
            // Create a Size object to store the desired width and height values, call it 'size'
            Size size = new Size(frameWidth, frameHeight);

            // DECLARE & INSTANTIATE a Stream, call it 'stream'. Make it a new MemoryStream to store the image sent from the ImageFactory when saved:
            Stream stream = new MemoryStream();

            // Load the image into the ImageFactory, resize it by passing the size object and save it to the stream object
            _imageFactory.Load(image).Resize(size).Save(stream);

            // Convert the stream back to an Image object
            Image img = Image.FromStream(stream);

            // Return the image
            return img;
        }

    }
}
