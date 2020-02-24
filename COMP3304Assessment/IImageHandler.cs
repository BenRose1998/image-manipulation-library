using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// COMP3304 Assessment - by Ben Rose & Luke Mitchell
/// </summary>
namespace COMP3304Assessment
{
    interface IImageHandler
    {
        /// <summary>
        /// Used to get a reference to ImageViewer's PictureBox form object in which the image will be displayed
        /// </summary>
        /// <param name="pictureBox">The PictureBox form object that images will be displayed in</param>
        void SetImageDisplay(PictureBox pictureBox);

        /// <summary>
        /// Retreive file path from FilePathHandler using '_imgIndex' and apply that image to the PictureBox
        /// </summary>
        void DisplayImage();

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
