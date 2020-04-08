using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// COMP3304 Assessment Final Milestone - by Ben Rose
/// </summary>
namespace ImageManipulationLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDisplayImageEventPublisher
    {
        /// <summary>
        /// Subscribe a listener to image events
        /// </summary>
        /// <param name="listener">Reference to listener's method</param>
        void Subscribe(EventHandler<DisplayImageEventArgs> listener);

        /// <summary>
        /// Unsubscribe a listener to image events
        /// </summary>
        /// <param name="listener">Reference to listener's method</param>
        void Unsubscribe(EventHandler<DisplayImageEventArgs> listener);
    }
}
