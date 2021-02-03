using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CER
{
    class Logger
    {
        /// <summary>
        /// Outputs a string to Console with Timestamp
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        public void Output(string s, bool t)
        {
         if (t)
         {
                string time = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
                Console.WriteLine("[" + time + "] " + s);
                File.AppendAllText("log.txt", "[" + time + "] " + s + Environment.NewLine);
            }
         else if (!t)
            {
                Console.WriteLine(s);
            }
        }
    }
}
