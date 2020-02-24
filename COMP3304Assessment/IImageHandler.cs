using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMP3304Assessment
{
    interface IImageHandler
    {
        void addPictureBox(PictureBox pictureBox);

        void displayImage();

        void nextImage();

        void previousImage();
    }
}
