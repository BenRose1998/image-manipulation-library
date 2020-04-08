using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMP3304Assessment
{
    public partial class CollectionView : Form, IEventListener
    {
        // DECLARE a ExecuteDelegate to store the delegate to be called to issue a command:
        private ExecuteDelegate _execute;

        // DECLARE an AddImageDelegate to store the delegate that requests the next image, call it '_addImageAction':
        private AddImageDelegate _addImage;

        private IDictionary<int, PictureBox> _pictureBoxes;

        public CollectionView(ExecuteDelegate execute, AddImageDelegate addImage)
        {
            // Base method call
            InitializeComponent();

            // INSTANTIATE '_execute' with the passed delegate:
            _execute = execute;

            // INSTANTIATE '_addImage' with the passed delegate:
            _addImage = addImage;

            _pictureBoxes = new Dictionary<int, PictureBox>();

            foreach (PictureBox pb in this.Controls.OfType<PictureBox>())
            {
                _pictureBoxes.Add(0, pb);
            }

            Console.WriteLine(_pictureBoxes.Count);
        }

        // Event Listener
        public void OnNewImage(object source, ImageEventArgs args)
        {
            // Check for the new image data
            if (args.image != null)
            {
                // Loop through all picture boxes
                foreach (PictureBox pb in this.Controls.OfType<PictureBox>())
                {
                    // If picture doesn't currently have an image
                    if (pb.Image == null)
                    {
                        _pictureBoxes.Add(args.key, pb);
                        // Set it to this image and break from loop
                        _pictureBoxes[args.key].Image = args.image;
                        break;
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
                // Loop through all filenames
                foreach (String filename in openFileDialog.FileNames)
                {
                    // Execute the add image command
                    _addImage(filename, _pictureBoxes[0].Size);
                }
            }
        }


        private void PictureBox_Click(object sender, EventArgs e)
        {
            
        }
    }
}
