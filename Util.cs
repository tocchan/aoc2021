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
            return Convert.ToInt64( s, 2 );
        }

        public static string ApplyMarkup( string str )
        {
            (string,string)[] list = {
                ("-",        "\u001b[0m"),
                ("black",    "\u001b[30m"),
                ("red",      "\u001b[31m"),
                ("green",    "\u001b[32m"),
                ("yellow",   "\u001b[33m"),
                ("blue",     "\u001b[34m"),
                ("magenta",  "\u001b[35m"),
                ("cyan",     "\u001b[36m"),
                ("white",    "\u001b[37m"),
                ("+black",   "\u001b[30;1m"),
                ("+red",     "\u001b[31;1m"),
                ("+green",   "\u001b[32;1m"),
                ("+yellow",  "\u001b[33;1m"),
                ("+blue",    "\u001b[34;1m"),
                ("+magenta", "\u001b[35;1m"),
                ("+cyan",    "\u001b[36;1m"),
                ("+white",   "\u001b[37;1m")
            }; 

            // forgive me...
            while (str.Contains("[ "))
            {
                str = str.Replace("[ ", "["); 
            }

            // todo: bug that I'm not escaping the '<' character, but not a case I need so ignoring it; 
            // todo: currently unhandled types will be left in, would be nice to cleanse and warn about them
            foreach ((string find, string replace) in list)
            {
                string search = $"[{find}]"; 
                str = str.Replace( search, replace ); 
            }

            // always cleanup at the end of a line; 
            return $"{str}{list[0].Item2}"; 
        }

        public static void WriteLine( string line )
        {
            Console.WriteLine( ApplyMarkup(line) ); 
        }

        public static (float, float) Quadratic( float a, float b, float c )
        {
            float inner = b * b - 4 * a * c; 
            if (inner < 0)
            {
                return (float.NaN, float.NaN); 
            }

            inner = MathF.Sqrt(inner); 
            float ansA = (-b - inner) / (2 * a); 
            float ansB = (-b + inner) / (2 * a); 

            return (ansA, ansB); 
        }
    }
}
