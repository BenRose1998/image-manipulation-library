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
    /// Interface for the DisplayView form - which displays a single image
    /// </summary>
    public interface IDisplayView
    {
        /// <summary>
        /// Used to image identifier key and all required delegates after instantiation (So that a generic factory can be used)
        /// </summary>
        /// <param name="imageKey">unique identifier for image</param>
        /// <param name="execute">Delegate for executing commands</param>
        /// <param name="requestImage">Action for RequestImageCommand</param>
        /// <param name="flipImage">Action for FlipImageCommand</param>
        /// <param name="rotateImage">Action for RotateImageCommand</param>
        /// <param name="scaleImage">Action for ScaleImageCommand</param>
        /// <param name="saveImage">Action for SaveImageCommand</param>
        void Initialise(int imageKey, ExecuteDelegate execute, RequestImageDelegate requestImage, FlipImageDelegate flipImage,
                               RotateImageDelegate rotateImage, ScaleImageDelegate scaleImage, SaveImageDelegate saveImage);

        /// <summary>
        /// Used to update '_key', the unique identifier of the image to be displayed. Image is the requested.
        /// </summary>
        /// <param name="key">the unique identifier of the image</param>
        void UpdateKey(int key);

        /// <summary>
        /// Event Listener for DisplayImage event, an image is received to be displayed
        /// </summary>
        /// <param name="source">Object that raised event</param>
        /// <param name="args">image to be displayed</param>
        void OnDisplayImage(object source, DisplayImageEventArgs args);
    }
}
