using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP3304Assessment
{
    /// <summary>
    /// Command Class - Executes an action that has no parameters
    /// </summary>
    public class Command : ICommand
    {
        // DECLARE an Action to be executed, call it _action:
        private Action _action;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="action"></param>
        public Command(Action action)
        {
            // INTIANIATE _action with action passed as parameter:
            _action = action;
        }

        /// <summary>
        /// Execute this command's action
        /// </summary>
        public void Execute()
        {
            // Execute
            _action();
        }
    }
}
