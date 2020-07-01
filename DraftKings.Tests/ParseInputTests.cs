using DraftKings.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DraftKings.Tests
{


    
    public class ParseInputTests
    {


        [Fact]
        public void Parse_ReadInputShouldHaveFiveCommaSeparatedValues()
        {


            //Arrange
            string input = "add,10,Sharilyn Gruber,-1";
            ParseInputCSV parser = new ParseInputCSV(input);

            
            int expected = 5;

            //Act
            parser.Parse();
            string[] results = parser.GetParsedValues();

            //Assert

            Assert.Equal(4, results.Length);
        }

        [Fact]
        public void Parse_ReadInputShouldHaveOneValue()
        {


            //Arrange
            string input = "6";
            int expected = 1;
            ParseInputCSV parser = new ParseInputCSV(input);
            //Act

            parser.Parse();
            string[] results = parser.GetParsedValues();

            //Assert

            Assert.Equal(expected, results.Length);
        }
    }
}
