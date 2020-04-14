using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// COMP3304 Assessment Final Milestone - by Ben Rose
/// </summary>
namespace ImageManipulationLibrary
{
    public class DisplayImageEventArgs : EventArgs
    {
        /// <summary>
        /// Property stores updated image
        /// </summary>
        public Image image { get; }

        public IDictionary<int, Image> images { get; }

        public DisplayImageEventArgs(Image img)
        {
            image = img;
        }

        public DisplayImageEventArgs(IDictionary<int, Image> imgs)
        {
            images = imgs;
        }
    }
}
