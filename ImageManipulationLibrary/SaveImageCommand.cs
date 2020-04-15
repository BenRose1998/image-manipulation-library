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
    /// Save Image Command Class - Executes an the Save Image command
    /// </summary>
    public class SaveImageCommand : ICommand
    {
        // DECLARE an Action to be executed, call it '_action':
        private SaveImageDelegate _action;
        private int _key;
        private String _filePath;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="action"></param>
        public SaveImageCommand(SaveImageDelegate action, int key, String filePath)
        {
            // INTIANIATE '_action' with action passed as parameter:
            _action = action;
            _key = key;
            _filePath = filePath;
        }

        /// <summary>
        /// Execute this command's action
        /// </summary>
        public void Execute()
        {
            // Execute
            _action(_key, _filePath);
        }
    }

}
