using ModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// COMP3304 Assessment Final Milestone - by Ben Rose
/// </summary>
namespace ViewLibrary
{
    /// <summary>
    /// Interface for the DisplayView form - allows image being displayed to be updated
    /// </summary>
    public interface IDisplayViewUpdater
    {
        /// <summary>
        /// Used to update '_key', the unique identifier of the image to be displayed. Image is the requested.
        /// </summary>
        /// <param name="key">the unique identifier of the image</param>
        void UpdateKey(int key);
    }
}
