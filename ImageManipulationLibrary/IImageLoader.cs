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
    interface IImageLoader
    {
        /// <summary>
        /// Load the images pointed to by 'pathfilenames' into '_images' container
        /// </summary>
        /// <param name="pathfilenames">a list of strings; each string containing path/filename for an image file to be loaded</param>
        /// <returns>a Dictionary of loaded images, indexed by their key</returns>
        IDictionary<int, Image> Load(IList<String> pathfilenames);
    }
}
