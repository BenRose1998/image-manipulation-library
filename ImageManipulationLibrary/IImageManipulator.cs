using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

/// <summary>
/// COMP3304 Assessment - by Ben Rose & Luke Mitchell
/// </summary>
namespace ImageManipulationLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public interface IImageManipulator
    {
        Image Resize(Image image, int frameWidth, int frameHeight);
    }
}
