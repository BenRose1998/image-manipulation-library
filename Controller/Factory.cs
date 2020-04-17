using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerLibrary
{
    /// <summary>
    /// A factory that return an instance of a specified interface (E)
    /// </summary>
    /// <typeparam name="E">The interface</typeparam>
    public class Factory<E> : IFactory<E>
    {
        /// <summary>
        /// Instantiate an object of the 'E' interface and return it
        /// </summary>
        /// <typeparam name="T">Class to be instantiated</typeparam>
        /// <returns>Instance of type T</returns>
        public E Create<T>() where T : E, new()
        {
            return new T();
        }
    }
}
