using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP3304Assessment
{
    public class ImageEventArgs : EventArgs
    {
        /// <summary>
        /// Property stores updated image
        /// </summary>
        public int key { get; }
        public Image image { get; }

        public ImageEventArgs(Image img, int k)
        {
            image = img;
            key = k;
        }
    }
}
