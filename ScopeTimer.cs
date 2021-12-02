using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AoC2021
{
    internal class ScopeTimer : IDisposable
    {
        public ScopeTimer(string label)
        { 
            m_label = label; 
            m_stopwatch = Stopwatch.StartNew();    
        }

        public void Dispose() => Dispose(true); 

        protected virtual void Dispose(bool disposing)
        {
            m_stopwatch.Stop();
            Console.WriteLine( $"{m_label} took {FormatTime()}." ); 
        }

        private string FormatTime()
        {
            double seconds = m_stopwatch.Elapsed.TotalSeconds;
            if (seconds > 0.5)
            {
                return seconds.ToString("0.000") + "s"; 
            } 
            else if (seconds > 0.001)
            {
                return (1000.0 * seconds).ToString("0.000") + "ms"; 
            }
            else
            {
                return (1000000.0 * seconds).ToString("0.000") + "us"; 
            }
        }

        private string m_label; 
        private Stopwatch m_stopwatch; 
    }
}
