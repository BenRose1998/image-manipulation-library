using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP3304Assessment
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
