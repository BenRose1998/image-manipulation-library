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

        private RequestImageDelegate _requestImageCommand;

        private FlipImageDelegate _flipImageCommand;

        private RotateImageDelegate _rotateImageCommand;

        private ScaleImageDelegate _scaleImageCommand;

        private SaveImageDelegate _saveImageCommand;

        public ImageViewer(int imageKey, ExecuteDelegate execute, RequestImageDelegate requestImage, FlipImageDelegate flipImage, 
                            RotateImageDelegate rotateImage, ScaleImageDelegate scaleImage, SaveImageDelegate saveImage)
        {
            // Base method call
            InitializeComponent();

            // INSTANTIATE '_key' with the passed image key:
            _key = imageKey;

            // INSTANTIATE '_execute' to execute:
            _execute += execute;

            // INSTANTIATE '_requestImageCommand' to requestImage:
            _requestImageCommand += requestImage;

            // INSTANTIATE '_flipImageCommand' to flipImage:
            _flipImageCommand += flipImage;

            // INSTANTIATE '_rotateImageCommand' to rotateImage:
            _rotateImageCommand += rotateImage;

            // INSTANTIATE '_scaleImageCommand' to scaleImage:
            _scaleImageCommand += scaleImage;

            // INSTANTIATE '_saveImageCommand' to saveImage:
            _saveImageCommand += saveImage;
        }

        public void UpdateKey(int key)
        {
            // Set '_key' to the updated key passed as a parameter
            _key = key;
            //
            ICommand requestImage = new RequestImageCommand(_requestImageCommand, _key, pictureBox.Size);
            _execute(requestImage);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FlipHorizontalButton_Click(object sender, EventArgs e)
        {
            ICommand flip = new FlipCommand(_flipImageCommand, _key, false);
            _execute(flip);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FlipVerticallyButton_Click(object sender, EventArgs e)
        {
            ICommand flip = new FlipCommand(_flipImageCommand, _key, true);
            _execute(flip);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RotateNegative90Button_Click(object sender, EventArgs e)
        {
            ICommand rotate = new RotateCommand(_rotateImageCommand, _key, -90);
            _execute(rotate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RotatePositive90Button_Click(object sender, EventArgs e)
        {
            ICommand rotate = new RotateCommand(_rotateImageCommand, _key, 90);
            _execute(rotate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScaleButton_Click(object sender, EventArgs e)
        {
            Size size = new Size
            {
                Width = Int32.Parse(textBoxScaleWidth.Text),
                Height = Int32.Parse(textBoxScaleHeight.Text)
            };

            ICommand scale = new ScaleCommand(_scaleImageCommand, _key, size);
            _execute(scale);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Open save file explorer dialog and store the result in a DialogResult, call it 'result':
            DialogResult result = saveFileDialog1.ShowDialog();

            // Check if the result is OK
            if (result == DialogResult.OK)
            {
                ICommand save = new SaveImageCommand(_saveImageCommand, _key, saveFileDialog1.FileName);
                _execute(save);
            }
        }

        /// <summary>
        /// When form is resized - retrieve the image again with new image box size to rescale
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageViewer_ResizeEnd(object sender, EventArgs e)
        {
            // Execute the retrieve image command
            ICommand requestImage = new RequestImageCommand(_requestImageCommand, _key, pictureBox.Size);
            _execute(requestImage);
        }

    }
}
