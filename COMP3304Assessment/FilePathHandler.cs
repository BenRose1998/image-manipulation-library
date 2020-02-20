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

        private IList<string> keys;

        private IList<string> pathfilenames;

        private IModel _model;

        public FilePathHandler(IModel model)
        {
            _model = model;
            keys = new List<string>();
            pathfilenames = new List<string>();
            add("../../assets/JavaFish.png");
            loadImages();
        }

        public void add(string filename)
        {
            pathfilenames.Add(filename);
            loadImages();
        }

        private void loadImages()
        {
            keys = _model.load(pathfilenames);
        }

        public Image getImage(int index)
        {
            //
            if (keys.Count > index && index >= 0)
            {
                return _model.getImage(keys[index], 480, 480);
            }
            else
            {
                return null;
            }          
        }
    }
}
