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
    /// 
    /// </summary>
    public interface ICollectionView
    {
        /// <summary>
        /// OnNewImages Event Listener - Recieves image(s) to be displayed, if an image is already being displayed it is updated, new images are added.
        /// </summary>
        /// <param name="source">Object that raised event</param>
        /// <param name="args">Event data (images)</param>
        void OnNewImages(object source, NewImagesEventArgs args);
    }
}
