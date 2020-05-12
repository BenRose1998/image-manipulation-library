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
    /// Interface for the DisplayView form - allows form to be initialised
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
    }
}
