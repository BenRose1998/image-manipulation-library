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
    public interface IEventListener
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        void OnImageChanged(object source, ImageEventArgs args);
    }
}
