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
    interface IFilePathAdder
    {
        /// <summary>
        /// Recieves a string and adds it to the '_pathfilenames' list, calls loadImages method to pass the updated file names to model
        /// </summary>
        /// <param name="filename"></param>
        void Add(string filename);
    }
}
