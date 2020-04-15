using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// COMP3304 Assessment Final Milestone - by Ben Rose
/// </summary>
namespace ImageManipulationLibrary
{
    /// <summary>
    /// Request Image Command Class - Executes the Request Image command
    /// </summary>
    public class RequestImageCommand : ICommand
    {
        // DECLARE an Action to be executed, call it '_action':
        private RequestImageDelegate _action;
        private int _key;
        private Size _size;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="action"></param>
        public RequestImageCommand(RequestImageDelegate action, int key, Size size)
        {
            // INTIANIATE '_action' with action passed as parameter:
            _action = action;
            _key = key;
            _size = size;
        }

        /// <summary>
        /// Execute this command's action
        /// </summary>
        public void Execute()
        {
            // Execute
            _action(_key, _size);
        }
    }

}
