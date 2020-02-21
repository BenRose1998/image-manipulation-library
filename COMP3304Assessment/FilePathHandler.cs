using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP3304Assessment
{
    class FilePathHandler
    {
        // ---------
        // Variables
        // ---------

        // DECLARE an IList interface for a List to store image keys as strings, call it '_keys':
        private IList<string> _keys;

        // DECLARE an IList interface for a List to store image file names as strings, call it '_pathfilenames':
        private IList<string> _pathfilenames;

        // DECLARE an IModel interface to store a reference to the Model instance, call it '_model':
        private IModel _model;


        // ------------
        // Constructor
        // ------------
        public FilePathHandler(IModel model)
        {
            // INSTANTIATE the local 'model', with the passed 'model'
            this._model = model;

            // INSTANTIATE the 'keys' & 'pathfilenames' Lists
            _keys = new List<string>();
            _pathfilenames = new List<string>();


            // -----------------------------------------
            // --------------- TEMPORARY ---------------
            // (Should probably start with no images???)
            // -----------------------------------------
            add("../../assets/JavaFish.png");
            loadImages();
            // -----------------------------------------
        }


        // -------------------------------------------------------------------------------------------
        // Add Filename Method - Used by the 'ImageView.cs' to pass new filenames from the File Dialog
        // -------------------------------------------------------------------------------------------
        public void add(string filename)
        {
            // Adds the passed 'filename', to the local IList of strings 'pathfilenames'
            _pathfilenames.Add(filename);

            // Call the local 'loadImages' method
            loadImages();
        }


        // -------------------------------------------------------------------------------
        // Load Image Method - Used to load new images by path filenames by the 'Model.cs'
        // -------------------------------------------------------------------------------
        private void loadImages()
        {
            // Call load on the '_model', passing the IList of strings 'pathfilenames'
            _keys = _model.load(_pathfilenames);
        }


        // --------------------------------------------------------------------------------------
        // Get Image Method - Used by the 'ImageHandler.cs' to retreive loaded images by indexing
        // --------------------------------------------------------------------------------------
        public Image getImage(int index)
        {
            // If the count value of '_keys' is greater than the 'index' value but above 0
            if (_keys.Count > index && index >= 0)
            {
                return _model.getImage(_keys[index], 480, 480);
            }
            else
            {
                return null;
            }          
        }
    }
}
