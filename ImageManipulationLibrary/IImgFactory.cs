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
    /// Interface used to create an instance of Image from a file
    /// </summary>
    interface IImgFactory
    {
        /// <summary>
        /// Instantiates an instance of Image using FromFile method
        /// </summary>
        /// <param name="path">Image file path name</param>
        /// <returns>A System.Drawing Image instance</returns>
        Image Create(string path);
    }
}
