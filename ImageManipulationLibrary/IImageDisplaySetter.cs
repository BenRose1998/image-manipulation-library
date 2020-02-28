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
    /// <summary>
    /// IImageDisplaySetter - Used to give ImageHandler a reference to the PictureBox in which an image will be displayed, then Display an image
    /// </summary>
    public interface IImageDisplaySetter
    {
        /// <summary>
        /// Used to recieve a reference to ImageViewer's PictureBox form object in which the image will be displayed
        /// </summary>
        /// <param name="pictureBox">The PictureBox form object that images will be displayed in</param>
        void SetImageDisplay(PictureBox pictureBox);
    }
}
