using System;
using System.Collections.Generic;
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
            // Call Image on 'pictureBox' display the next image
            pictureBox.Image = filePathHandler.getImage(imgIndex);
        }


        // ---------------------------------------------------------------------------------------------------------------
        // Next Image Method - Used to retreive the next image in the 'Model.cs' and apply the returned 'PictureBox.Image'
        // ---------------------------------------------------------------------------------------------------------------
        public void nextImage()
        {
            // Increment the 'imgIndex' value 
            imgIndex++;

            // Call xxx to display the next image
            pictureBox.Image = filePathHandler.getImage(imgIndex);
        }


        // -----------------------------------------------------------------------------------------------------------------------
        // Previous Image Method - Used to retreive the previous image in the 'Model.cs' and apply the returned 'PictureBox.Image'
        // -----------------------------------------------------------------------------------------------------------------------
        public void previousImage()
        {
            // Increment the 'imgIndex' value 
            imgIndex--;

            // Call xxx to display the next image
            pictureBox.Image = filePathHandler.getImage(imgIndex);
        }
    }
}
