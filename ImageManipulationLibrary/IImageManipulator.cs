using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

/// <summary>
/// COMP3304 Assessment Final Milestone - by Ben Rose
/// </summary>
namespace ModelLibrary
{
    /// <summary>
    /// IImageManipulator - Interface for an ImageManipulator, receives images, edits them and returns
    /// </summary>
    public interface IImageManipulator
    {
        /// <summary>
        /// Receives an Image and a desired width and height, uses ImageProcessor library to resize the image and it is returned
        /// </summary>
        /// <param name="image">The image</param>
        /// <param name="size">Width and height values stored in Size object</param>
        /// <param name="stretch">Whether or not to stretch the image or maintain aspect ratio (defaulted to false)</param>
        /// <returns>The editted image</returns>
        Image Resize(Image image, Size size, Boolean stretch = false);

        /// <summary>
        /// Receives an Image and a boolean, uses ImageProcessor library to flip the image and it is returned
        /// </summary>
        /// <param name="image">The image</param>
        /// <param name="flipVertical">Whether or not to vertically flip the image (or flip horizontally)</param>
        /// <returns>The editted image</returns>
        Image Flip(Image image, Boolean flipVertical);

        /// <summary>
        /// Receives an Image and an int (degrees), uses ImageProcessor library to rotate the image and it is returned
        /// </summary>
        /// <param name="image">The image</param>
        /// <param name="degrees">The amount of rotation in degrees</param>
        /// <returns>The editted image</returns>
        Image Rotate(Image image, int degrees);
    }
}
