using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

/// <summary>
/// COMP3304 Assessment Final Milestone - by Ben Rose
/// </summary>
namespace ImageManipulationLibrary
{
    public interface IModel
    {
        /// <summary>
        /// Load the media items pointed to by 'pathfilenames' into the 'Model'
        /// </summary>
        /// <param name="pathfilenames">a vector of strings; each string containing path/filename for an image file to be loaded</param>
        void Load(IList<String> pathfilenames);

        /// <summary>
        /// Return a copy of the image specified by 'key', scaled according to the dimentsions of the visual container (ie frame) it will be viewed in.
        /// </summary>
        /// <param name="key">the unique identifier for the image to be returned</param>
        /// <param name="size">size object, holds width & height of image</param>
        /// <returns>the Image pointed identified by key</returns>
        void GetImage(int key, Size size);

        void FlipImage(int key, Boolean flipVertical);

        void RotateImage(int key, int degrees);

        void ScaleImage(int key, Size size);

        void SaveImage(int key, String filePath);
    }
}
