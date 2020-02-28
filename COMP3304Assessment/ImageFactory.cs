using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// COMP3304 Assessment - by Ben Rose & Luke Mitchell
/// </summary>
namespace COMP3304Assessment
{
    /// <summary>
    /// Used to create an instance of Image from a file
    /// </summary>
    class ImageFactory : IImageFactory
    {
        public ImageFactory()
        {
            // Do nothing
        }

        /// <summary>
        /// Instantiates an instance of Image using FromFile method
        /// </summary>
        /// <param name="path">Image file path name</param>
        /// <returns>A System.Drawing Image instance</returns>
        public Image Create(string path)
        {
            // Return an Image object populated by the image file
            return Image.FromFile(path);
        }
    }
}
