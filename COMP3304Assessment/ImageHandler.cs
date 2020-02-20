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
        public void currentImage()
        {
            // Apply the returned 'filePathHandler' image to the local 'PictureBox.Image'
            pictureBox.Image = filePathHandler.getImage(imgIndex);
        }


        // ---------------------------------------------------------------------------------------------------------------
        // Next Image Method - Used to retreive the next image in the 'Model.cs' and apply the returned 'PictureBox.Image'
        // ---------------------------------------------------------------------------------------------------------------
        public void nextImage()
        {
            // Increment the 'imgIndex' value 
            imgIndex++;

            // Store the next image in the local 'nextImage' value
            Image nextImage = filePathHandler.getImage(imgIndex);

            // If the 'nextImage' value is not Null
            if (nextImage != null)
            {
                // Call 'currentImage' method
                currentImage();
            }
            else
            {
                // Decrement the 'imgIndex' value
                imgIndex--;
            }
        }


        // -----------------------------------------------------------------------------------------------------------------------
        // Previous Image Method - Used to retreive the previous image in the 'Model.cs' and apply the returned 'PictureBox.Image'
        // -----------------------------------------------------------------------------------------------------------------------
        public void previousImage()
        {
            // Decrement the 'imgIndex' value 
            imgIndex--;

            // Store the previous image in the local 'nextImage' value
            Image previousImage = filePathHandler.getImage(imgIndex);

            // If the 'previousImage' value is not Null
            if (previousImage != null)
            {
                // Call 'currentImage' method
                currentImage();
            }
            else
            {
                // Increment the 'imgIndex' value
                imgIndex++;
            }
        }
    }
}
