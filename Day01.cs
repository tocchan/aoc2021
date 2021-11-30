using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021
{
    internal class Day01
    {
        private string InputFileA = "inputs/test.txt"; 
        private string InputFileB = "inputs/text.txt"; 

        //----------------------------------------------------------------------------------------------
        public string RunA()
        {
            List<string> lines = Util.ReadFileToLines(InputFileA); 
            return (lines.Count > 0) ? lines[0] : "empty"; 
        }

        //----------------------------------------------------------------------------------------------
        public string RunB()
        {
            List<string> lines = Util.ReadFileToLines(InputFileA); 
            return (lines.Count > 0) ? lines[0] : "empty"; 
        }
    }
}
