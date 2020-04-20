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
    /// NewImagesEventArgs - Stores new or updated Image(s) to be displayed in CollectionView
    /// </summary>
    public class NewImagesEventArgs : EventArgs
    {
        /// <summary>
        /// Property stores new or updated image(s)
        /// </summary>
        public IDictionary<int, Image> images { get; }

        /// <summary>
        /// Constructor - Receives Image(s), store as member variable
        /// </summary>
        /// <param name="imgs">Image(s) to be displayed</param>
        public NewImagesEventArgs(IDictionary<int, Image> imgs)
        {
            images = imgs;
        }
    }
}
