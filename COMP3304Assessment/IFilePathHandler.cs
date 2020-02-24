using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP3304Assessment
{
    interface IFilePathHandler
    {
        void add(string filename);

        Image getImage(int index);
    }
}
