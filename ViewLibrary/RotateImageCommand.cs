﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// COMP3304 Assessment Final Milestone - by Ben Rose
/// </summary>
namespace ViewLibrary
{
    /// <summary>
    /// Rotate Command Class - Executes the Rotate command
    /// </summary>
    public class RotateImageCommand : ICommand
    {
        // DECLARE an Action to be executed, call it '_action':
        private RotateImageDelegate _action;
        private int _key;
        private int _degrees;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="action"></param>
        public RotateImageCommand(RotateImageDelegate action, int key, int degrees)
        {
            // INTIANIATE '_action' with action passed as parameter:
            _action = action;
            _key = key;
            _degrees = degrees;
        }

        /// <summary>
        /// Execute this command's action
        /// </summary>
        public void Execute()
        {
            // Execute
            _action(_key, _degrees);
        }
    }

}
