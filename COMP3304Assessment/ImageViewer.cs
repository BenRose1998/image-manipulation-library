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
    /// 
    /// </summary>
    // was public maybe fucked up
    partial class ImageViewer : Form
    {
        // ---------
        // Variables
        // ---------
        private IFilePathAdder _filePathHandler;

        private IImageHandler _imageHandler;

        // ------------
        // Constructor
        // ------------
        public ImageViewer(IFilePathAdder filePathHandler, IImageHandler imageHandler)
        {
            // Base method call
            InitializeComponent();

            // Initiate the local 'filePathHandler', with the passed 'filePathHandler'
            this._filePathHandler = filePathHandler;

            // Initiate the local 'imageHandler', with the passed 'imageHandler'
            this._imageHandler = imageHandler;

            // Passed the 'PictureBox' to the 'imageHandler'
            imageHandler.SetImageDisplay(imageBox);

            // Calls on the ImageHandler instance to Display the Current Image
            imageHandler.DisplayImage();
        }

        // -------------------------------------------------------------------------------------
        // Load Image Click - Event used to open a File Dialog popup to select an image to load
        // -------------------------------------------------------------------------------------
        private void loadImageButton_Click(object sender, EventArgs e)
        {
            // Open file explorer dialog and store the result in a DialogResult, call it 'result':
            DialogResult result = openFileDialog.ShowDialog();

            // Check if the result is OK
            if(result == DialogResult.OK)
            {
                // Store the name of the file that has been selected, call it 'fileName':
                string fileName = openFileDialog.FileName;

                // Calls the add method on the 'filePathHandler', passing the 'fileName'
                _filePathHandler.Add(fileName);

                // Calls on the ImageHandler instance to Display the Next Image
                _imageHandler.NextImage();
            }
        }


        // -----------------------------------------------------------------------------------------
        // Next Button Click - Event used to Display the next image by method call on 'imageHandler'
        // -----------------------------------------------------------------------------------------
        private void nextButton_Click(object sender, EventArgs e)
        {
            // Calls on the ImageHandler instance to Display the Next Image
            _imageHandler.NextImage();
        }


        // -------------------------------------------------------------------------------------------------
        // Previous Button Click - Event used to Display the previous image by method call on 'imageHandler'
        // -------------------------------------------------------------------------------------------------
        private void previousButton_Click(object sender, EventArgs e)
        {
            // Calls on the ImageHandler instance to Display the Previous Image
            _imageHandler.PreviousImage();
        }
    }
}
