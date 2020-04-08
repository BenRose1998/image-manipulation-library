using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP3304Assessment
{
    public class NewImagesEventArgs : EventArgs
    {
        /// <summary>
        /// Property stores updated image
        /// </summary>
        public IDictionary<int, Image> images { get; }

        public NewImagesEventArgs(IDictionary<int, Image> imgs)
        {
            images = imgs;
        }
    }
}
