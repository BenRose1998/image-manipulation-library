using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// COMP3304 Assessment - by Ben Rose & Luke Mitchell
/// </summary>
namespace COMP3304Assessment
{
    /// <summary>
    /// Used to increment or decrement the image index, doing this will display the previous or next image
    /// </summary>
    public interface IImageSetter
    {
        /// <summary>
        /// Increment '_imgIndex' value and call GetImage method to get the new image and apply it to the PictureBox
        /// </summary>
        void NextImage();

        /// <summary>
        /// Decrement '_imgIndex' value and call GetImage method to get the new image and apply it to the PictureBox
        /// </summary>
        void PreviousImage();
    }
}
