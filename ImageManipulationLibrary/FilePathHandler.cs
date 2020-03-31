using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// COMP3304 Assessment - by Ben Rose & Luke Mitchell
/// </summary>
namespace COMP3304Assessment
{
    /// <summary>
    /// FilePathHandler - Responsible for storing image file paths and passing them to Model
    /// </summary>
    public class FilePathHandler : IFilePathAdder, IFilePathGetter
    {
        // DECLARE an IList interface for a List to store image keys as strings, call it '_keys':
        private IList<string> _keys;
        // DECLARE an IList interface for a List to store image file names as strings, call it '_pathfilenames':
        private IList<string> _pathFileNames;
        // DECLARE an IModel interface to store a reference to the Model instance, call it '_model':
        private IModel _model;

        public FilePathHandler(IModel model)
        {
            // INSTANTIATE the local 'model', with the passed 'model'
            this._model = model;

            // INSTANTIATE the 'keys' & 'pathfilenames' Lists
            _keys = new List<string>();
            _pathFileNames = new List<string>();
        }

        /// <summary>
        /// Recieves a string and adds it to the '_pathfilenames' list, calls loadImages method to pass the updated file names to model
        /// </summary>
        /// <param name="filename">File path to be added to container</param>
        public void Add(string fileName)
        {
            // Adds the passed 'fileName', to the local IList of strings '_pathfilenames'
            _pathFileNames.Add(fileName);

            // Call load on the '_model', passing a single string 'fileName'
            _keys = _model.load(new List<String> { fileName });
        }

        /// <summary>
        /// Recieves an index (int) and returns the file path string from '_keys' at that index
        /// </summary>
        /// <param name="index">Index of image of which file path is being requested</param>
        /// <returns>File path string for specified index</returns>
        public string GetFilePath(int index)
        {
            // If the count value of '_keys' is greater than the 'index' value but above 0
            if (_keys.Count > index && index >= 0)
            {
                // Return the file path of the specified index
                return _keys[index];
            }
            else
            {
                return null;
            }
        }
    }
}
