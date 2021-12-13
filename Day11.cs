using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021
{
    internal class Day11
    {
        private string InputFile = "inputs/11.txt"; 

        private int Flash( ivec2 coord, int[,] grid )
        {
            int numFlashes = 0; 
            ivec2 min = ivec2.Max( coord - new ivec2(1, 1), ivec2.ZERO ); 
            ivec2 max = ivec2.Min( coord + new ivec2(1, 1), new ivec2(9, 9) ); 
            
            for (int x = min.x; x <= max.x; ++x)
            {
                for (int y = min.y; y <= max.y; ++y)
                {
                    if (grid[x, y] < 10) 
                    { 
                        ++grid[x, y]; 
                        if (grid[x, y] >= 10) 
                        {
                            ++numFlashes; 
                            numFlashes += Flash( new ivec2(x, y), grid ); 
                        }
                    }
                }
            }

            return numFlashes;
        }

        private int RunDay( int[,] grid )
        {
            int numFlashes = 0; 
            for (int x = 0; x < grid.GetLength(0); ++x)
            {
                for (int y = 0; y < grid.GetLength(1); ++y)
                {
                    if (grid[x, y] < 10) 
                    {
                        ++grid[x, y]; 
                        if (grid[x, y] >= 10) 
                        { 
                            ++numFlashes; 
                            numFlashes += Flash( new ivec2(x, y), grid ); 
                        }
                    }
                }
            }

            for (int x = 0; x < grid.GetLength(0); ++x)
            {
                for (int y = 0; y < grid.GetLength(1); ++y)
                {
                    if (grid[x, y] >= 10) 
                    { 
                        grid[x, y] = 0; 
                    }
                }
            }
            
            return numFlashes; 
        }

        //----------------------------------------------------------------------------------------------
        public string RunA()
        {
            List<string> lineInput = Util.ReadFileToLines(InputFile); 
            int[,] grid = new int[10,10]; 

            int y = 0; 
            foreach (string line in lineInput)
            {
                int x = 0; 
                foreach (char c in line)
                {
                    grid[x, y] = c - '0'; 
                    ++x; 
                }
                ++y;
            }

            int numDays = 100; 
            int numFlashes = 0; 
            for (int i = 0; i < numDays; ++i)
            {
                numFlashes += RunDay( grid ); 
            }

            return numFlashes.ToString(); 
        }

        //----------------------------------------------------------------------------------------------
        public string RunB()
        {
            List<string> lineInput = Util.ReadFileToLines(InputFile); 
            int[,] grid = new int[10,10]; 

            int y = 0; 
            foreach (string line in lineInput)
            {
                int x = 0; 
                foreach (char c in line)
                {
                    grid[x, y] = c - '0'; 
                    ++x; 
                }
                ++y;
            }

            int numDays = 0; 
            int flashCount = 0; 
            while (flashCount < 100)
            {
                ++numDays; 
                flashCount = RunDay( grid ); 
            }

            return numDays.ToString(); 
        }
    }
}

