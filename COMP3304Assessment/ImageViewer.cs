using ImageManipulationLibrary;
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
/// COMP3304 Assessment Final Milestone - by Ben Rose
/// </summary>
namespace COMP3304Assessment
{
    /// <summary>
    /// ImageViewer - The Windows Form class responsible for rendering a Form displaying Images and taking inputs (next image, previous image, upload image)
    /// </summary>
    partial class ImageViewer : Form, IImageViewer, IDisplayImageEventListener
    {
        // DECLARE
        private int _key;

        // DECLARE a ExecuteDelegate to store the delegate to be called to issue a command:
        private ExecuteDelegate _execute;

        private RequestImageDelegate _requestImage;

        private FlipImageDelegate _flipImageCommand;

        public ImageViewer(int imageKey, ExecuteDelegate execute, RequestImageDelegate requestImage, FlipImageDelegate flipImage)
        {
            // Base method call
            InitializeComponent();

            // INSTANTIATE '_key' with the passed image key:
            _key = imageKey;

            // INSTANTIATE '_execute' with the passed delegate:
            _execute = execute;

            // INSTANTIATE '_requestImage' with the passed delegate:
            _requestImage = requestImage;

            _flipImageCommand += flipImage;
        }

        public void UpdateKey(int key)
        {
            // Set '_key' to the updated key passed as a parameter
            _key = key;
            //
            _requestImage(_key, pictureBox.Size);
        }

        // Event Listener
        public void OnDisplayImage(object source, DisplayImageEventArgs args)
        {
            // Check for the new image data
            if (args.image != null)
            {
                // Set form's image box to that image
                this.pictureBox.Image = args.image;
            }
        }

        private void FlipHorizontalButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine(_key);
            ICommand flip = new FlipCommand(_flipImageCommand, _key, this.pictureBox.Image.Size, false);
            _execute(flip);
        }

        private void FlipVerticallyButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine(_key);
            ICommand flip = new FlipCommand(_flipImageCommand, _key, this.pictureBox.Image.Size, true);
            _execute(flip);
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
