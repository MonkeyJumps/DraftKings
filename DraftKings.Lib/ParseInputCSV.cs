using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraftKings.Lib
{


    /*
     * Reads lines of input of comma separated values
     * 
     * */
    public class ParseInputCSV
    {
        private readonly string _input;
        private string[] _results;

        public ParseInputCSV(string input)
        {
            _input = input;
        }

        public string [] GetParsedValues()
        {
            return _results;
        }
        public void Parse()
        {
            _results = _input.Split(',');
        }
    }
}
