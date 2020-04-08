using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP3304Assessment
{
    /// <summary>
    /// 
    /// </summary>
    public interface INewImagesEventListener
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        void OnNewImages(object source, NewImagesEventArgs args);
    }
}
