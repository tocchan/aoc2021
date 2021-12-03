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
            string[] lines; 
            try 
            {
                lines = File.ReadAllLines( filename ); 
                List<string> ret = new List<string>(lines); 
                
                // remove erroneous empty lines at the end
                while ((ret.Count > 0) && string.IsNullOrEmpty(ret.Last()))
                {
                    ret.RemoveAt(ret.Count - 1); 
                }

                return ret; 
            }
            catch (Exception e)
            {
                Console.WriteLine( "File read failed: " + e.ToString() );
                return new List<string>(); 
            }
        }

        public static Int64 BinaryStringToInt( string s )
        {
            Int64 val = 0; 
            Int64 pow = 1; 
            for (int i = s.Length - 1; i >= 0; --i)
            {
                if (s[i] != '0')
                {
                    val += pow; 
                }
                pow *= 2; 
            }

            return val; 
        }
    }
}
