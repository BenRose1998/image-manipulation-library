using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// COMP3304 Assessment Final Milestone - by Ben Rose
/// </summary>
namespace ImageManipulationLibrary
{
    /// <summary>
    /// Command Class - Executes an action that has no parameters
    /// </summary>
    public class GenericCommand : ICommand
    {
        // DECLARE an Action to be executed, call it '_action':
        private Action _action;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="action"></param>
        public GenericCommand(Action action)
        {
            // INTIANIATE '_action' with action passed as parameter:
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

    /// <summary>
    /// Genereic Command Class - Executes an action with one parameter
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericCommand<T> : ICommand
    {
        // DECLARE an Action to be executed, call it '_action':
        private Action<T> _action;

        // DECLARE a variable type T to store parameter passed, call it '_parameter':
        private T _parameter;

        /// <summary>
        /// Constructor of generic command
        /// </summary>
        /// <param name="action">Action to be executed</param>
        /// <param name="parameter">Parameter passed for the action</param>
        public GenericCommand(Action<T> action, T parameter)
        {
            // Store passed action in local '_action' variable:
            _action = action;
            // Store passed parameter in local '_parameter' variable:
            _parameter = parameter;
        }

        /// <summary>
        /// Execute the generic command's action
        /// </summary>
        public void Execute()
        {
            _action(_parameter);
        }
    }


}
