using ModelLibrary;
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
namespace ViewLibrary
{
    /// <summary>
    /// DisplayView - The Windows Form class responsible for rendering a Form for displaying and editting an image (rotate, flip, scale, save image)
    /// </summary>
    public partial class DisplayView : Form, IDisplayView, IDisplayViewUpdater, IDisplayImageEventListener
    {
        // DECLARE an int to store the unique idenifier of the image to be displayed, call it '_key':
        private int _key;

        // DECLARE a ExecuteDelegate to store the delegate to be called to execute a command, call it '_execute':
        private ExecuteDelegate _execute;
        // DECLARE a RequestImageDelegate to store the action of the RequestImageCommand, call it '_requestImageCommand':
        private RequestImageDelegate _requestImageCommand;
        // DECLARE a FlipImageDelegate to store the action of the FlipImageCommand, call it '_flipImageCommand':
        private FlipImageDelegate _flipImageCommand;
        // DECLARE a RotateImageDelegate to store the action of the RotateImageCommand, call it '_rotateImageCommand':
        private RotateImageDelegate _rotateImageCommand;
        // DECLARE a ScaleImageDelegate to store the action of the ScaleImageCommand, call it '_scaleImageCommand':
        private ScaleImageDelegate _scaleImageCommand;
        // DECLARE a SaveImageDelegate to store the action of the SaveImageCommand, call it '_saveImageCommand':
        private SaveImageDelegate _saveImageCommand;

        /// <summary>
        /// Used to image identifier key and all required delegates after instantiation (So that a generic factory can be used)
        /// </summary>
        /// <param name="imageKey">unique identifier for image</param>
        /// <param name="execute">Delegate for executing commands</param>
        /// <param name="requestImage">Action for RequestImageCommand</param>
        /// <param name="flipImage">Action for FlipImageCommand</param>
        /// <param name="rotateImage">Action for RotateImageCommand</param>
        /// <param name="scaleImage">Action for ScaleImageCommand</param>
        /// <param name="saveImage">Action for SaveImageCommand</param>
        public void Initialise(int imageKey, ExecuteDelegate execute, RequestImageDelegate requestImage, FlipImageDelegate flipImage, 
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

        /// <summary>
        /// Used to update '_key', the unique identifier of the image to be displayed. Image is the requested.
        /// </summary>
        /// <param name="key">the unique identifier of the image</param>
        public void UpdateKey(int key)
        {
            // Set '_key' to the updated key passed as a parameter
            _key = key;
            // Execute the RequestImageCommand, pass the key and current picture box size:
            ICommand requestImage = new RequestImageCommand(_requestImageCommand, _key, pictureBox.Size);
            _execute(requestImage);
        }

        // Event Listener
        /// <summary>
        /// Event Listener for DisplayImage event, an image is received to be displayed
        /// </summary>
        /// <param name="source">Object that raised event</param>
        /// <param name="args">image to be displayed</param>
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
        /// When the horizontal flip button is clicked - FlipImageCommand executed to flip the image horizontally
        /// </summary>
        /// <param name="sender">Object that raised event</param>
        /// <param name="e">Event data</param>
        private void FlipHorizontalButton_Click(object sender, EventArgs e)
        {
            // Execute the FlipImageCommand, pass the key and whether or not to rotate vertically (false):
            ICommand flip = new FlipImageCommand(_flipImageCommand, _key, false);
            _execute(flip);
        }

        /// <summary>
        /// When the vertical flip button is clicked - FlipImageCommand executed to flip the image vertically
        /// </summary>
        /// <param name="sender">Object that raised event</param>
        /// <param name="e">Event data</param>
        private void FlipVerticallyButton_Click(object sender, EventArgs e)
        {
            // Execute the FlipImageCommand, pass the key and whether or not to rotate vertically (true):
            ICommand flip = new FlipImageCommand(_flipImageCommand, _key, true);
            _execute(flip);
        }

        /// <summary>
        /// When the rotate -90 degrees button is clicked - RotateImageCommand executed to rotate the image -90
        /// </summary>
        /// <param name="sender">Object that raised event</param>
        /// <param name="e">Event data</param>
        private void RotateNegative90Button_Click(object sender, EventArgs e)
        {
            // Execute the RotateImageCommand, pass the key and amount of rotation (in degrees):
            ICommand rotate = new RotateImageCommand(_rotateImageCommand, _key, -90);
            _execute(rotate);
        }

        /// <summary>
        /// When the rotate 90 degrees button is clicked - RotateImageCommand executed to rotate the image 90
        /// </summary>
        /// <param name="sender">Object that raised event</param>
        /// <param name="e">Event data</param>
        private void RotatePositive90Button_Click(object sender, EventArgs e)
        {
            // Execute the RotateImageCommand, pass the key and amount of rotation (in degrees):
            ICommand rotate = new RotateImageCommand(_rotateImageCommand, _key, 90);
            _execute(rotate);
        }

        /// <summary>
        /// When the scale button is clicked - ScaleImageCommand executed to scale the image
        /// </summary>
        /// <param name="sender">Object that raised event</param>
        /// <param name="e">Event data</param>
        private void ScaleButton_Click(object sender, EventArgs e)
        {
            // DECLARE a Size object to store the width & height values inputted by the user
            Size size = new Size
            {
                // Parse to input strings to integers
                Width = Int32.Parse(textBoxScaleWidth.Text),
                Height = Int32.Parse(textBoxScaleHeight.Text)
            };
            // Execute the ScaleImageCommand, pass the key and size (in pixels):
            ICommand scale = new ScaleImageCommand(_scaleImageCommand, _key, size);
            _execute(scale);
        }

        /// <summary>
        /// When the save image button is clicked - SaveImageCommand executed to save the image
        /// </summary>
        /// <param name="sender">Object that raised event</param>
        /// <param name="e">Event data</param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Open save file explorer dialog and store the result in a DialogResult, call it 'result':
            DialogResult result = saveFileDialog1.ShowDialog();

            // Check if the result is OK
            if (result == DialogResult.OK)
            {
                // Execute the SaveImageCommand, pass the key and directory to save file in:
                ICommand save = new SaveImageCommand(_saveImageCommand, _key, saveFileDialog1.FileName);
                _execute(save);
            }
        }

        /// <summary>
        /// When form is resized - request the image again with new image box size to rescale it
        /// </summary>
        /// <param name="sender">Object that raised event</param>
        /// <param name="e">Event data</param>
        private void DisplayView_ResizeEnd(object sender, EventArgs e)
        {
            // Execute the RequestImageCommand, pass the key and current size of the picture box:
            ICommand requestImage = new RequestImageCommand(_requestImageCommand, _key, pictureBox.Size);
            _execute(requestImage);
        }
    }
}
