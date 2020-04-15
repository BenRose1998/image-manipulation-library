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
    public partial class CollectionView : Form, INewImagesEventListener
    {
        // DECLARE a ExecuteDelegate to store the delegate to be called to issue a command:
        private ExecuteDelegate _execute;

        // DECLARE an AddImageDelegate to store the delegate that requests the next image, call it '_addImageAction':
        private Action<IList<String>> _addImagesAction;

        //
        private Action<int> _displayImageAction;

        //
        private IDictionary<int, PictureBox> _pictureBoxes;

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

            // 
            _pictureBoxes = new Dictionary<int, PictureBox>();
        }

        // Event Listener
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void OnNewImages(object source, NewImagesEventArgs args)
        {
            // Check for the new image data
            if (args.images != null)
            {
                foreach(KeyValuePair<int, Image> img in args.images)
                {
                    Boolean isNew = true;

                    // If an image with the same key as an existing image has been sent, update it
                    foreach(KeyValuePair<int, PictureBox> pictureBox in _pictureBoxes)
                    {
                        // Check if any PictureBox image keys match this image key
                        if(pictureBox.Key == img.Key)
                        {
                            // This image is not new
                            isNew = false;
                            // Update the image
                            pictureBox.Value.Image = img.Value;
                        }
                    }

                    // Only try to add the image to an empty PictureBox if the image is not already being displayed
                    if (isNew)
                    {
                        // Loop through all picture boxes
                        foreach (PictureBox pb in this.Controls.OfType<PictureBox>())
                        {
                            // If picture doesn't currently have an image
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox_DoubleClick(object sender, EventArgs e)
        {
            // Find the key of the PictureBox that was clicked in the '_pictureBoxes' dictionary
            int key = _pictureBoxes.FirstOrDefault(x => x.Value == sender).Key;
            // Execute display image command
            ICommand addImages = new GenericCommand<int>(_displayImageAction, key);
            _execute(addImages);
        }
    }
}
