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
    /// 
    /// </summary>
    class ImageHandler : IImageHandler
    {
        // ---------
        // Variables
        // ---------

        private PictureBox _pictureBox;

        private IFilePathGetter _filePathHandler;

        private int _imgIndex;

        private getImage _getImageDel;

        // ------------
        // Constructor
        // ------------
        public ImageHandler(IFilePathGetter filePathHandler, getImage getImage)
        {
            // Initiate the local 'filePathHandler'
            this._filePathHandler = filePathHandler;

            // Initiate the local 'imgIndex'
            _imgIndex = 0;

            _getImageDel = getImage;
        }

        /// <summary>
        /// Used to get a reference to ImageViewer's PictureBox form object in which the image will be displayed
        /// </summary>
        /// <param name="pictureBox">The PictureBox form object that images will be displayed in</param>
        public void SetImageDisplay(PictureBox pictureBox)
        {
            // Initiate the local 'pictureBox'
            this._pictureBox = pictureBox;
        }

        /// <summary>
        /// Retreive file path from FilePathHandler using '_imgIndex' and apply that image to the PictureBox
        /// </summary>
        public void DisplayImage()
        {
            string filePath = _filePathHandler.GetFilePath(_imgIndex);

            if (filePath != null)
            {
                _pictureBox.Image = _getImageDel(filePath, _pictureBox.Width, _pictureBox.Height);
            }
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
                newImage = _getImageDel(filePath, _pictureBox.Width, _pictureBox.Height);
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
