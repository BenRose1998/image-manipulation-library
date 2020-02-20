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

        private PictureBox pictureBox;

        private FilePathHandler filePathHandler;

        private int imgIndex;


        // ------------
        // Constructor
        // ------------
        public ImageHandler(FilePathHandler filePathHandler)
        {
            // Initiate the local 'filePathHandler'
            this.filePathHandler = filePathHandler;

            // Initiate the local 'imgIndex'
            imgIndex = 0;
        }


        // -------------------------------------------------------------------------------------
        // Add PictureBox Method - Used to store the PictureBox for access to its Image property 
        // -------------------------------------------------------------------------------------
        public void addPictureBox(PictureBox pictureBox)
        {
            // Initiate the local 'pictureBox'
            this.pictureBox = pictureBox;
        }


        // ---------------------------------------------------------------------------------------------------------------------
        // Current Image Method - Used to retreive the current image in the 'Model.cs' and apply the returned 'PictureBox.Image'
        // ---------------------------------------------------------------------------------------------------------------------
        public void displayImage()
        {
            // Apply the returned 'filePathHandler' image to the local 'PictureBox.Image'
            pictureBox.Image = filePathHandler.getImage(imgIndex);
        }


        // ------------------------------------------------------------------------------------------
        // Get Image Method - Used to retreive the next / previous image, actioned from button clicks
        // ------------------------------------------------------------------------------------------
        private void getImage()
        {
            // Store the next image in the local 'nextImage' value
            Image nextImage = filePathHandler.getImage(imgIndex);

            // If the 'nextImage' value is not Null
            if (nextImage != null)
            {
                // Call the local 'displayImage' method
                displayImage();
            }
            else if (imgIndex < 0)
            {
                // Increment the 'imgIndex' value
                imgIndex++;
            }
            else
            {
                // Decrement the 'imgIndex' value 
                imgIndex--;
            }
        }


        // ---------------------------------------------------------------------------------------------------------------
        // Next Image Method - Used to retreive the next image in the 'Model.cs' and apply the returned 'PictureBox.Image'
        // ---------------------------------------------------------------------------------------------------------------
        public void nextImage()
        {
            // Increment the 'imgIndex' value 
            imgIndex++;

            // Call the local 'getImage' method
            getImage();
        }


        // -----------------------------------------------------------------------------------------------------------------------
        // Previous Image Method - Used to retreive the previous image in the 'Model.cs' and apply the returned 'PictureBox.Image'
        // -----------------------------------------------------------------------------------------------------------------------
        public void previousImage()
        {
            // Decrement the 'imgIndex' value 
            imgIndex--;

            // Call the local 'getImage' method
            getImage();
        }
    }
}
