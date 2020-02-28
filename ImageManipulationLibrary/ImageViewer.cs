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
    public partial class ImageViewer : Form
    {
        // DECLARE an IFilePathAdder interface to store a reference to the FilePathHandler instance, call it '_filePathHandler':
        private IFilePathAdder _filePathHandler;
        // DECLARE an IImageDisplaySetter interface to store a reference to the ImageHandler instance, call it '_imageHandler':
        private IImageDisplaySetter _imageHandler;

        public ImageViewer(IFilePathAdder filePathHandler, IImageDisplaySetter imageHandler)
        {
            // Base method call
            InitializeComponent();

            // Initiate the local '_filePathHandler', with the passed 'filePathHandler'
            _filePathHandler = filePathHandler;

            // Initiate the local '_imageHandler', with the passed 'imageHandler'
            _imageHandler = imageHandler;

            // Passed the 'PictureBox' to the 'imageHandler'
            _imageHandler.SetImageDisplay(imageBox);
        }

        /// <summary>
        /// Called when 'loadImageButton' button is clicked. Event used to open a File Dialog popup to select an image to load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadImageButton_Click(object sender, EventArgs e)
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
                (_imageHandler as IImageSetter).NextImage();
            }
        }

        /// <summary>
        /// Called when 'nextButton' button is clicked. Event used to display the next image by calling '_imageHandler''s method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextButton_Click(object sender, EventArgs e)
        {
            // Calls on the ImageHandler instance to Display the Next Image
            (_imageHandler as IImageSetter).NextImage();
        }

        /// <summary>
        /// Called when 'previousButton' button is clicked. Event used to display the previous image by calling '_imageHandler''s method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviousButton_Click(object sender, EventArgs e)
        {
            // Calls on the ImageHandler instance to Display the Previous Image
            (_imageHandler as IImageSetter).PreviousImage();
        }
    }
}
