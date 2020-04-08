using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP3304Assessment
{
    interface IImageViewer
    {
        void UpdateKey(int key);

        void OnDisplayImage(object source, DisplayImageEventArgs args);
    }
}
