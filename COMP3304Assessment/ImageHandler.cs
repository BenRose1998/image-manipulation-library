using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMP3304Assessment
{
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
        /// Used to pass a reference to ImageViewer's PictureBox form object that displays the image
        /// </summary>
        /// <param name="pictureBox"></param>
        public void Initialise(PictureBox pictureBox)
        {
            // Initiate the local 'pictureBox'
            this._pictureBox = pictureBox;
        }


        // ---------------------------------------------------------------------------------------------------------------------
        // Current Image Method - Used to retreive the current image in the 'Model.cs' and apply the returned 'PictureBox.Image'
        // ---------------------------------------------------------------------------------------------------------------------
 
        public void displayImage()
        {
            // Apply the returned 'filePathHandler' image to the local 'PictureBox.Image'
            //_pictureBox.Image = _filePathHandler.getImage(_imgIndex);

            string filepath = _filePathHandler.getFilePath(_imgIndex);

            if(filepath != null)
            {
                _pictureBox.Image = _getImageDel(filepath, _pictureBox.Width, _pictureBox.Height);
            }
        }

        // ---------------------------------------------------------------------------------------------------------------
        // Next Image Method - Used to retreive the next image in the 'Model.cs' and apply the returned 'PictureBox.Image'
        // ---------------------------------------------------------------------------------------------------------------
        public void nextImage()
        {
            // Increment the 'imgIndex' value 
            _imgIndex++;

            // Call the local 'getImage' method
            getImage();
        }


        // -----------------------------------------------------------------------------------------------------------------------
        // Previous Image Method - Used to retreive the previous image in the 'Model.cs' and apply the returned 'PictureBox.Image'
        // -----------------------------------------------------------------------------------------------------------------------
        public void previousImage()
        {
            // Decrement the 'imgIndex' value 
            _imgIndex--;

            // Call the local 'getImage' method
            getImage();
        }

        // ------------------------------------------------------------------------------------------
        // Get Image Method - Used to retreive the next / previous image, actioned from button clicks
        // ------------------------------------------------------------------------------------------
        private void getImage()
        {
            // Store the next image in the local 'nextImage' value
            //Image nextImage = _getImageDel(_filePathHandler.getFilePath(_imgIndex), _pictureBox.Width, _pictureBox.Height);

            // Default to null
            Image nextImage = null;

            string filepath = _filePathHandler.getFilePath(_imgIndex);

            if (filepath != null)
            {
                nextImage = _getImageDel(filepath, _pictureBox.Width, _pictureBox.Height);
            }

            // If the 'nextImage' value is not Null
            if (nextImage != null)
            {
                // Call the local 'displayImage' method
                displayImage();
            }
            else if (_imgIndex < 0)
            {
                // Increment the 'imgIndex' value
                _imgIndex++;
            }
            else
            {
                // Decrement the 'imgIndex' value 
                _imgIndex--;
            }
        }

    }
}
