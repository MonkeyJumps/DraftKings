using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraftKings.Lib
{
    public class ConsoleDisplay : IDisplay
    {
        public void Write(string line)
        {
            Debug.WriteLine(line);
        }
    }
}
