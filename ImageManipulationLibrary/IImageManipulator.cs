using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ImageManipulationLibrary
{
    public interface IImageManipulator
    {
        Image Resize(Image image, int frameWidth, int frameHeight);
    }
}
