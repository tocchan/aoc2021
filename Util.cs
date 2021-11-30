using System;
using System.Collections.Generic;
using System.IO; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021
{
    static class Util
    {
        public static List<string> ReadFileToLines( string filename )
        {
            List<string> ret = new List<string>();
            string[] lines; 
            try 
            {
                lines = File.ReadAllLines( filename ); 
            }
            catch (Exception e)
            {
                Console.WriteLine( "File read failed: " + e.ToString() );
                return ret; 
            }

            foreach (string line in lines)
            {
                if (!string.IsNullOrEmpty(line))
                { 
                    ret.Add(line); 
                }
            }

            return ret; 
        }
    }
}
