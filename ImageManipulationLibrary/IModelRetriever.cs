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
    public interface IModelRetriever
    {
        /// <summary>
        /// Trigger OnDisplayImage event passing the image defined by 'key', scaled to the Size object passed
        /// </summary>
        /// <param name="key">the unique identifier for the image</param>
        /// <param name="size">size object, holds width & height of image</param>
        void GetImage(int key, Size size);
    }
}
