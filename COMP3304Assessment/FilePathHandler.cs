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

        private IList<string> keys;

        private IList<string> pathfilenames;

        private IModel model;


        // ------------
        // Constructor
        // ------------
        public FilePathHandler(IModel model)
        {
            // Initaiate the local 'model', with the passed 'model'
            this.model = model;
            
            // Initaiate the 'keys' & 'pathfilenames' Lists
            keys = new List<string>();
            pathfilenames = new List<string>();


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
            pathfilenames.Add(filename);

            // Call the local 'loadImages' method
            loadImages();
        }


        // -------------------------------------------------------------------------------
        // Load Image Method - Used to load new images by path filenames by the 'Model.cs'
        // -------------------------------------------------------------------------------
        private void loadImages()
        {
            // Call load on the '_model', passing the IList of strings 'pathfilenames'
            keys = model.load(pathfilenames);
        }


        // --------------------------------------------------------------------------------------
        // Get Image Method - Used by the 'ImageHandler.cs' to retreive loaded images by indexing
        // --------------------------------------------------------------------------------------
        public Image getImage(int index)
        {
            // If the count value of 'keys' is greater than the 'index' value but above 0
            if (keys.Count > index && index >= 0)
            {
                return model.getImage(keys[index], 480, 480);
            }
            else
            {
                return null;
            }          
        }
    }
}
