using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMP3304Assessment
{
    class ImageHandler
    {
        // ---------
        // Variables
        // ---------

        private PictureBox _pictureBox;

        private FilePathHandler _filePathHandler;

        private int _imgIndex;


        // ------------
        // Constructor
        // ------------
        public ImageHandler(FilePathHandler filePathHandler)
        {
            // Initiate the local 'filePathHandler'
            this._filePathHandler = filePathHandler;

            // Initiate the local 'imgIndex'
            _imgIndex = 0;
        }


        // -------------------------------------------------------------------------------------
        // Add PictureBox Method - Used to store the PictureBox for access to its Image property 
        // -------------------------------------------------------------------------------------
        public void addPictureBox(PictureBox pictureBox)
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
            _pictureBox.Image = _filePathHandler.getImage(_imgIndex);
        }


        // ------------------------------------------------------------------------------------------
        // Get Image Method - Used to retreive the next / previous image, actioned from button clicks
        // ------------------------------------------------------------------------------------------
        private void getImage()
        {
            // Store the next image in the local 'nextImage' value
            Image nextImage = _filePathHandler.getImage(_imgIndex);

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
    }
}
