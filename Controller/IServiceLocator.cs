using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerLibrary
{
    public interface IServiceLocator
    {
        /// <summary>
        /// Returns a service for creating the specified type
        /// </summary>
        /// <typeparam name="T">The type of the service being requested</typeparam>
        /// <returns>The service being requested</returns>
        IService Get<T>() where T : class;
    }
}
