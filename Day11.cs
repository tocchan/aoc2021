using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021
{
    internal class Day11 : Day
    {
        private string InputFile = "inputs/11d.txt"; 

        //----------------------------------------------------------------------------------------------
        public override string RunA()
        {
            List<string> lineInput = Util.ReadFileToLines(InputFile); 
            return lineInput[0]; 
        }

        //----------------------------------------------------------------------------------------------
        public override string RunB()
        {
            List<string> lineInput = Util.ReadFileToLines(InputFile); 
            return lineInput[0]; 
        }
    }
}

