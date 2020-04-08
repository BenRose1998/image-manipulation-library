using System;
using System.Collections.Generic;
using System.Drawing;

namespace COMP3304Assessment
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


    public delegate void AddImageDelegate(IList<String> filenames, Size size);

    public delegate void DisplayImageDelegate(int key);

    public delegate void RequestImageDelegate(int key, Size size);
}