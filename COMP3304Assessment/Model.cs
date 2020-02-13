using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP3304Assessment
{
    class Model : IModel
    {
        private IDictionary<string, Image> _images;

        public Model()
        {
            _images = new Dictionary<string, Image>();
        }

        public IList<String> load(IList<String> pathfilenames)
        {
            foreach(string path in pathfilenames)
            {
                _images.Add(path, Image.FromFile(path));
            }
            
            IList<string> keys = new List<string>();

            foreach(string key in _images.Keys)
            {
                keys.Add(key);
            }

            return keys;
        }

        public Image getImage(String key, int frameWidth, int frameHeight)
        {
            return _images[key];
        }

    }
}
