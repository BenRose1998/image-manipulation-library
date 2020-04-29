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
    /// 
    /// </summary>
    public interface IModelEditor
    {
        /// <summary>
        /// Flip image based on specified orientation
        /// </summary>
        /// <param name="key">the unique identifier for the image</param>
        /// <param name="flipVertical">Whether to flip vertically (or horizontally)</param>
        void FlipImage(int key, Boolean flipVertical);

        /// <summary>
        /// Rotate image based on specified amount in degrees
        /// </summary>
        /// <param name="key">the unique identifier for the image</param>
        /// <param name="degrees">Amount of rotation in degrees</param>
        void RotateImage(int key, int degrees);

        /// <summary>
        /// Scale image based on specified values of Size object
        /// </summary>
        /// <param name="key">the unique identifier for the image</param>
        /// <param name="size">Scaling values as Size object</param>
        void ScaleImage(int key, Size size);
    }
}
