using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// COMP3304 Assessment - by Ben Rose & Luke Mitchell
/// </summary>
namespace COMP3304Assessment
{
    /// <summary>
    /// 
    /// </summary>
    interface IFilePathGetter
    {
        /// <summary>
        /// Recieves an index (int) and returns the file path string from '_keys' at that index
        /// </summary>
        /// <param name="index"></param>
        /// <returns>File path string for specified index</returns>
        string GetFilePath(int index);
    }
}
