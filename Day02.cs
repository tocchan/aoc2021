using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021
{
    internal class Day02
    {
        private string InputFileA = "inputs/day02.a.txt"; 
        private string InputFileB = "inputs/day02.a.txt"; 

        //----------------------------------------------------------------------------------------------
        private (string, int) ParseInstruction( string instruction )
        {
            string[] parts = instruction.Split(' ', 2); 
            string dir = parts[0]; 
            int amount = int.Parse(parts[1]); 

            return (dir, amount); 
        }

        //----------------------------------------------------------------------------------------------
        private (int, int) ComputePositionA( List<string> lines )
        {
            int x = 0;
            int y = 0;

            foreach (string line in lines)
            { 
                (string dir, int amount) = ParseInstruction(line); 
                switch (dir[0])
                {
                    case 'f': x += amount; break; 
                    case 'u': y -= amount; break; 
                    case 'd': y += amount; break; 
                }
            }

            return (x, y); 
        }

        //----------------------------------------------------------------------------------------------
        private (int, int) ComputePositionB( List<string> lines )
        {
            int a = 0; 
            int x = 0;
            int y = 0;

            foreach (string line in lines)
            { 
                (string dir, int amount) = ParseInstruction(line); 
                switch (dir[0])
                {
                    case 'f': x += amount; y += a * amount; break; 
                    case 'u': a -= amount; break; 
                    case 'd': a += amount; break; 
                }
            }

            return (x, y); 
        }

        //----------------------------------------------------------------------------------------------
        public string RunA()
        {
            List<string> lines = Util.ReadFileToLines(InputFileA); 

            (int x, int y) = ComputePositionA(lines); 
         
            return (x * y).ToString(); 
        }

        //----------------------------------------------------------------------------------------------
        public string RunB()
        {
            List<string> lines = Util.ReadFileToLines(InputFileA); 

            (int x, int y) = ComputePositionB(lines); 
         
            return (x * y).ToString(); 
        }
    }
}
