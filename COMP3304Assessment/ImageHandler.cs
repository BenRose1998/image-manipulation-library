using System;
using System.Collections.Generic;
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
    /// Responsible for retreiving the current image and setting the Form's PictureBox Image property to that image.
    /// </summary>
    class ImageHandler : IImageDisplaySetter, IImageSetter
    {
        // DECLARE a PictureBox to store a reference to Form's PictureBox which will display the image, call it '_pictureBox':
        private PictureBox _pictureBox;
        // DECLARE an IFilePathGetter interface to store a reference to the FilePathHandler instance, call it '_filePathHandler':
        private IFilePathGetter _filePathHandler;
        // DECLARE an int to keep track of which image to display, call it '_imgIndex':
        private int _imgIndex;
        // DECLARE an IModel interface to store a reference to the Model instance, call it '_model':
        private IModel _model;

        // ------------
        // Constructor
        // ------------
        public ImageHandler(IFilePathGetter filePathHandler, IModel model)
        {
            // INSTANTIATE the local '_filePathHandler' with the passed reference
            _filePathHandler = filePathHandler;

            // INSTANTIATE the local 'imgIndex' to 0
            _imgIndex = 0;

            // INSTANTIATE the local '_model' with the passed reference
            _model = model;
        }

        /// <summary>
        /// Used to get a reference to ImageViewer's PictureBox form object in which the image will be displayed
        /// </summary>
        /// <param name="pictureBox">The PictureBox form object that images will be displayed in</param>
        public void SetImageDisplay(PictureBox pictureBox)
        {
            // INSTANTIATE the local '_pictureBox' with the passed reference
            _pictureBox = pictureBox;

            GetImage();
        }

        /// <summary>
        /// Increment '_imgIndex' value and call GetImage method to get the new image and apply it to the PictureBox
        /// </summary>
        public void NextImage()
        {
            // Increment the 'imgIndex' value 
            _imgIndex++;

            // Call the local 'getImage' method
            GetImage();
        }

        /// <summary>
        /// Decrement '_imgIndex' value and call GetImage method to get the new image and apply it to the PictureBox
        /// </summary>
        public void PreviousImage()
        {
            // Decrement the 'imgIndex' value 
            _imgIndex--;

            // Call the local 'getImage' method
            GetImage();
        }

        /// <summary>
        /// Retrieve file path from FilePathHandler by an index, using that file path retrieve an Image from model then set '_pictureBoxes' image to it.
        /// </summary>
        private void GetImage()
        {
            // DECLARE & INSTANIATE an temporary Image variable to null. Call it 'newImage':
            Image newImage = null;

            // DECLARE & INSTANIATE a temporary string variable. Give it the file path returned from the GetFilePath method after passing current _imgIndex. Call it 'filePath':
            string filePath = _filePathHandler.GetFilePath(_imgIndex);

            // Check if a filePath was found for that index
            if (filePath != null)
            {
                // Call getImage method, passing filePath and _pictureBox's width and height properties, save result in 'newImage'
                newImage = _model.getImage(filePath, _pictureBox.Width, _pictureBox.Height);
            }

            // If the 'newImage' value is not null an image was found
            if (newImage != null)
            {
                // Apply 'newImage' to '_pictureBox's Image property
                _pictureBox.Image = newImage;
            }
            else if (_imgIndex < 0)
            {
                // Set index to 0 to prevent index going out of bounds
                _imgIndex = 0;
            }
            else
            {
                // Decrement the 'imgIndex' value to prevent index going out of bounds
                _imgIndex--;
            }
        }

    }
}
