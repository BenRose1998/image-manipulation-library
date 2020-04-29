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
    interface IImageUpdater
    {
        /// <summary>
        /// Update an image (specified by key) to the image passed
        /// </summary>
        /// <param name="key">the unique identifier for the image</param>
        /// <param name="image">the image to update to</param>
        void Update(int key, Image image);
    }
}
