﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021
{
    internal class Day18 : Day
    {
        private string InputFile = "inputs/18d.txt"; 

        //----------------------------------------------------------------------------------------------
        public override string RunA()
        {
            List<string> lines = Util.ReadFileToLines(InputFile); 
            return lines[0]; 
        }

        //----------------------------------------------------------------------------------------------
        public override string RunB()
        {
            // List<string> lines = Util.ReadFileToLines(InputFileB); 
            return ""; 
        }
    }
}
