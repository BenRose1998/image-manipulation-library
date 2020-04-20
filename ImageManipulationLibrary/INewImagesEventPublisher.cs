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
    /// Interface for the NewImage event's publisher, facilitates EventHandler subscriptions
    /// </summary>
    public interface INewImagesEventPublisher
    {
        /// <summary>
        /// Subscribe a listener to new or updated image events
        /// </summary>
        /// <param name="listener">Reference to listener's method</param>
        void Subscribe(EventHandler<NewImagesEventArgs> listener);

        /// <summary>
        /// Unsubscribe a listener to new or updated image events
        /// </summary>
        /// <param name="listener">Reference to listener's method</param>
        void Unsubscribe(EventHandler<NewImagesEventArgs> listener);
    }
}
