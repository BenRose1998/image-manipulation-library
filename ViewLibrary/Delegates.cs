﻿using System;
using System.Collections.Generic;
using System.Drawing;

/// <summary>
/// COMP3304 Assessment Final Milestone - by Ben Rose
/// </summary>
namespace ViewLibrary
{
    /// <summary>
    /// Declare a delegate that is used to execute commands, call it ExecuteDelegate:
    /// </summary>
    /// <param name="command"></param>
    public delegate void ExecuteDelegate(ICommand command);

    public delegate void DisplayImageDelegate(int key);

    public delegate void AddImageDelegate(IList<String> filenames);

    public delegate void RequestImageDelegate(int key, Size size);

    public delegate void FlipImageDelegate(int key, Boolean flipVertical);

    public delegate void RotateImageDelegate(int key, int degrees);

    public delegate void ScaleImageDelegate(int key, Size size);

    public delegate void SaveImageDelegate(int key, String filePath);
}