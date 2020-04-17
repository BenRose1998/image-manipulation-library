using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

/// <summary>
/// COMP3304 Assessment Final Milestone - by Ben Rose
/// </summary>
namespace ModelLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public interface IImageManipulator
    {
        Image Resize(Image image, int frameWidth, int frameHeight, Boolean stretch = false);

        Image Flip(Image image, Boolean flipVertical);

        Image Rotate(Image image, int degrees);
    }
}
