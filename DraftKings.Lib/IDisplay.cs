using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace DraftKings.Lib
{
    public interface IDisplay
    {
        void Write(string line);
    }
}
