using System;
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
    /// Flip Command Class - Executes an the Flip command
    /// </summary>
    public class FlipImageCommand : ICommand
    {
        // DECLARE an Action to be executed, call it '_action':
        private FlipImageDelegate _action;
        private int _key;
        private Boolean _flipVertical;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="action"></param>
        public FlipImageCommand(FlipImageDelegate action, int key, Boolean flipVertical)
        {
            // INTIANIATE '_action' with action passed as parameter:
            _action = action;
            _key = key;
            _flipVertical = flipVertical;
        }

        /// <summary>
        /// Execute this command's action
        /// </summary>
        public void Execute()
        {
            // Execute
            _action(_key, _flipVertical);
        }
    }

}
