using ModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// COMP3304 Assessment Final Milestone - by Ben Rose
/// </summary>
namespace ViewLibrary
{
    public interface IImageViewer
    {
        void UpdateKey(int key);

        void OnDisplayImage(object source, DisplayImageEventArgs args);
    }
}
