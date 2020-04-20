using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// COMP3304 Assessment Final Milestone - by Ben Rose
/// </summary>
namespace ModelLibrary
{
    /// <summary>
    /// Interface for the NewImage event's listener, defines Event's listener method
    /// </summary>
    public interface INewImagesEventListener
    {
        /// <summary>
        /// Method called when event is triggered
        /// </summary>
        /// <param name="source">Object that triggered event</param>
        /// <param name="args">Arguments passed by event</param>
        void OnNewImages(object source, NewImagesEventArgs args);
    }
}
