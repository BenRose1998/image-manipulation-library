using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// COMP3304 Assessment Final Milestone - by Ben Rose
/// </summary>
namespace ModelLibrary
{
    /// <summary>
    /// 
    /// </summary>
    interface IImageRetriever
    {
        /// <summary>
        /// Return an image specified by a key
        /// </summary>
        /// <param name="key">the unique identifier for the image</param>
        /// <returns>the images being requested</returns>
        Image Get(int key);
    }
}
