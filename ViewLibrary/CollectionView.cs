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
    /// CollectionView - The Form responsible for rendering a Form for uploading and displaying images
    /// </summary>
    public partial class CollectionView : Form, INewImagesEventListener
    {
        // DECLARE a ExecuteDelegate to store the delegate to be called to issue a command:
        private ExecuteDelegate _execute;
        // DECLARE an Action to store the passed Action used to add images, call it '_addImagesAction':
        private Action<IList<String>> _addImagesAction;
        // DECLARE an Action to store the passed Action used to display an image, call it '_displayImageAction':
        private Action<int> _displayImageAction;

        // DECLARE an IDictionary to store references to PictureBoxes currently displaying images, call it '_pictureBoxes':
        private IDictionary<int, PictureBox> _pictureBoxes;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="execute">ExecuteDelegate</param>
        /// <param name="addImages">AddImageDelegate</param>
        /// <param name="displayImage">DisplayImageDelegate</param>
        public CollectionView(ExecuteDelegate execute, Action<IList<String>> addImages, Action<int> displayImage)
        {
            // Base method call
            InitializeComponent();

            // INSTANTIATE '_execute' to execute:
            _execute = execute;

            // INSTANTIATE '_addImagesAction' to addImages:
            _addImagesAction += addImages;

            // INSTANTIATE '_displayImageAction' to displayImage:
            _displayImageAction += displayImage;

            // INSTANTIATE '_pictureBoxes' as a new Dictionary storing a key and PictureBoxes:
            _pictureBoxes = new Dictionary<int, PictureBox>();
        }

        /// <summary>
        /// OnNewImages Event Listener - Recieves image(s) to be displayed, if an image is already being displayed it is updated, new images are added.
        /// </summary>
        /// <param name="source">Object that raised event</param>
        /// <param name="args">Event data (images)</param>
        public void OnNewImages(object source, NewImagesEventArgs args)
        {
            // Check for the new image data
            if (args.images != null)
            {
                // Loop through all KeyValuePairs in arg's images Dictionary
                foreach(KeyValuePair<int, Image> img in args.images)
                {
                    // DECLARE a boolean, default it to true, call it 'isNew':
                    Boolean isNew = true;

                    // If an image with the same key as an existing image has been sent, update it
                    // Loop through all KeyValuePairs in the '_pictureBoxes' Dictionary
                    foreach (KeyValuePair<int, PictureBox> pictureBox in _pictureBoxes)
                    {
                        // Check if the PictureBox image's key matches current image key (in outer loop)
                        if(pictureBox.Key == img.Key)
                        {
                            // This image is not new
                            isNew = false;
                            // Update the image
                            pictureBox.Value.Image = img.Value;
                        }
                    }

                    // Only try to add the image to an empty PictureBox if the image is not already being displayed (isNew is set to true still)
                    if (isNew)
                    {
                        // Loop through all picture boxes on form
                        foreach (PictureBox pb in this.Controls.OfType<PictureBox>())
                        {
                            // If PictureBox doesn't currently have an image
                            if (pb.Image == null)
                            {
                                // Add this PictureBox to the '_pictureBoxes' dictionary
                                _pictureBoxes.Add(img.Key, pb);
                                // Set this PictureBox's image to this new image
                                _pictureBoxes[img.Key].Image = img.Value;
                                // Break from the loop
                                break;
                            }
                        }
                    }

                }

            }
        }

        /// <summary>
        /// Called when 'loadImageButton' button is clicked. Event used to open a File Dialog popup to select an image to load
        /// </summary>
        /// <param name="sender">Object that raised event</param>
        /// <param name="e">Event data</param>
        private void LoadImageButton_Click(object sender, EventArgs e)
        {
            // Enable multi-select so that user can upload multiple images at once
            openFileDialog.Multiselect = true;
            // Open file explorer dialog and store the result in a DialogResult, call it 'result':
            DialogResult result = openFileDialog.ShowDialog();

            // Check if the result is OK
            if (result == DialogResult.OK)
            {
                // Execute the add images action, pass all uploaded filenames
                ICommand addImages = new GenericCommand<IList<String>>(_addImagesAction, openFileDialog.FileNames);
                _execute(addImages);
            }
        }

        /// <summary>
        /// Called when one of the PictureBoxes is clicked. The display image action is executed, PictureBox's key is passed.
        /// </summary>
        /// <param name="sender">Object that raised event</param>
        /// <param name="e">Event data</param>
        private void PictureBox_DoubleClick(object sender, EventArgs e)
        {
            // Find the key of the PictureBox that was clicked in the '_pictureBoxes' dictionary (this is the image's key):
            int key = _pictureBoxes.FirstOrDefault(x => x.Value == sender).Key;
            // Execute display image command, pass key:
            ICommand displayImage = new GenericCommand<int>(_displayImageAction, key);
            _execute(displayImage);
        }
    }
}
