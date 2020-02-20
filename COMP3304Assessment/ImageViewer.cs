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
    // was public maybe fucked up
    partial class ImageViewer : Form
    {
        // ---------
        // Variables
        // ---------

        private FilePathHandler _handler;

        private ImageHandler imageHandler;


        // ------------
        // Constructor
        // ------------
        public ImageViewer(FilePathHandler handler, ImageHandler imageHandler)
        {
            InitializeComponent();
            _handler = handler;

            //
            this.imageHandler = imageHandler;

            // Passed the 'PictureBox' to the 'imageHandler'
            imageHandler.addPictureBox(imageBox);

            // Calls on the FilePathHandler to Display the Current Image
            imageHandler.currentImage();
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
                _handler.add(fileName);

                // Calls on the FilePathHandler to Display the Next Image
                imageHandler.nextImage();
            }
        }


        // -----------------------------------------------------------------------------------------
        // Next Button Click - Event used to Display the next image by method call on 'imageHandler'
        // -----------------------------------------------------------------------------------------
        private void nextButton_Click(object sender, EventArgs e)
        {
            // Calls on the FilePathHandler to Display the Next Image
            imageHandler.nextImage();
        }


        // -------------------------------------------------------------------------------------------------
        // Previous Button Click - Event used to Display the previous image by method call on 'imageHandler'
        // -------------------------------------------------------------------------------------------------
        private void previousButton_Click(object sender, EventArgs e)
        {
            // Calls on the FilePathHandler to Display the Previous Image
            imageHandler.previousImage();
        }
    }
}
