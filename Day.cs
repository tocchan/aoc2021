using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021
{
    internal abstract class Day
    {
        abstract public string RunA();
        abstract public string RunB();

        public static Day? Create( string? num, System.Type defType )
        {
            if (num == null)
            {
                return (Day?) Activator.CreateInstance(defType);
            }

            if (num.Length < 2)
            {
                num = "0" + num; 
            }

            string className = "AoC2021.Day" + num; 
            System.Runtime.Remoting.ObjectHandle? objHandle = Activator.CreateInstance("AoC2021", className); 
            if (objHandle != null)
            {
                return (Day?) objHandle.Unwrap(); 
            }
            else
            {
                Console.WriteLine( "Unknown Day: " + className ); 
                return null; 
            }
        }
    }
}
