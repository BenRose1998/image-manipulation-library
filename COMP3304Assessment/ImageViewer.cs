using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    /// ImageViewer - The Windows Form class responsible for rendering a Form displaying Images and taking inputs (next image, previous image, upload image)
    /// </summary>
    partial class ImageViewer : Form, IEventListener
    {
        // DECLARE a ExecuteDelegate to store the delegate to be called to issue a command:
        private ExecuteDelegate _execute;

        public ImageViewer(Image img, ExecuteDelegate execute)
        {
            // Base method call
            InitializeComponent();

            // INSTANTIATE '_execute' with the passed delegate:
            _execute = execute;
        }

        // Event Listener
        public void OnDisplayImage(object source, ImageEventArgs args)
        {
            // Check for the new image data
            if (args.image != null)
            {
                // Set form's image box to that image
                imageBox.Image = args.image;
            }
        }

        /// <summary>
        /// When form is resized - retrieve the image again with new image box size to rescale
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void ImageViewer_ResizeEnd(object sender, EventArgs e)
        //{
        //    // Execute the retrieve image command
        //    ICommand retImage = new Command<Size>(_retrieveImageAction, imageBox.Size);
        //    _execute(retImage);
        //}
    }
}
