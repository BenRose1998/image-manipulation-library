using System;
using System.Collections.Generic;
using System.Drawing;

/// <summary>
/// COMP3304 Assessment Final Milestone - by Ben Rose
/// </summary>
namespace ImageManipulationLibrary
{
    /// <summary>
    /// Declare a delegate that is used to excute commands, call it ExecuteDelegate.
    /// </summary>
    /// <param name="command"></param>
    public delegate void ExecuteDelegate(ICommand command);

    /// <summary>
    /// Declare a delegate for retrieving an image, call it RetrieveImageDelegate
    /// </summary>
    /// <returns>The note text</returns>
    public delegate void RetrieveImageDelegate();


    public delegate void AddImageDelegate(IList<String> filenames);

    public delegate void DisplayImageDelegate(int key);

    public delegate void RequestImageDelegate(int key, Size size);

    public delegate void FlipImageDelegate(int key, Boolean flipVertical);

    public delegate void SaveImageDelegate(int key, String filePath);
}