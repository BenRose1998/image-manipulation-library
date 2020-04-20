using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// COMP3304 Assessment Final Milestone - by Ben Rose
/// </summary>
namespace ControllerLibrary
{
    /// <summary>
    /// Interface for the factory that return an instance of a specified interface (E)
    /// </summary>
    /// <typeparam name="E">The interface</typeparam>
    public interface IFactory<E> : IService
    {
        /// <summary>
        /// Instantiate an object of the 'E' interface and return it
        /// </summary>
        /// <typeparam name="T">Class to be instantiated</typeparam>
        /// <returns>Instance of type T</returns>
        E Create<T>() where T : E, new();
    }
}
