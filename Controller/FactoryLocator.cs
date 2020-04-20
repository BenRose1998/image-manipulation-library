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
    /// FactoryLocator - A service locator for factories
    /// </summary>
    class FactoryLocator : IServiceLocator
    {
        // DECLARE an IDictionary to store references to 'factories' (IServices), indexed by the type they create, call it '_factories':
        private IDictionary<Type, IService> _factories;

        /// <summary>
        /// Constructor
        /// </summary>
        public FactoryLocator()
        {
            // INSTANTIATE '_factories' as a Dictionary:
            _factories = new Dictionary<Type, IService>();
        }

        /// <summary>
        /// Returns a factory for creating the specified type
        /// </summary>
        /// <typeparam name="T">The type of the factory being requested</typeparam>
        /// <returns>The factory being requested</returns>
        public IService Get<T>() where T : class
        {
            if (!_factories.ContainsKey(typeof(T)))
            {
                // If a factory of specified type doesn't exist, create one:
                _factories.Add(typeof(T), new Factory<T>());
            }
            // Return the requested factory
            return _factories[typeof(T)];
        }

    }
}
