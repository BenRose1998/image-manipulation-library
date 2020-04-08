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
    /// ICommand - Implemented by all Command classes
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Execute this command's action
        /// </summary>
        void Execute();
    }
}
