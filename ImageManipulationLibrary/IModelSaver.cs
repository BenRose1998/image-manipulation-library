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
    public interface IModelSaver
    {
        /// <summary>
        /// Save an Image to a file
        /// </summary>
        /// <param name="key">the unique identifier for the image</param>
        /// <param name="filePath">the directory path and file name in which to save the image</param>
        void SaveImage(int key, String filePath);
    }
}
