using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021
{
    internal class Day16
    {
        private string InputFile = "inputs/16d.txt"; 

        //----------------------------------------------------------------------------------------------
        public string RunA()
        {
            List<string> lines = Util.ReadFileToLines(InputFile); 
            return lines[0]; 
        }

        //----------------------------------------------------------------------------------------------
        public string RunB()
        {
            // List<string> lines = Util.ReadFileToLines(InputFileB); 
            return ""; 
        }
    }
}
