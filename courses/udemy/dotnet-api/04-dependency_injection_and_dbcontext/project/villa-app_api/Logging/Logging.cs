using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace villa_app_api.Logging
{
    public class Logging : ILogging
    {
        public void Log(string message, string type)
        {
            if (type == "error")
            {
                Console.WriteLine("ERROR: " + message);
            }
            else
            {
                Console.WriteLine(message);
            }

        }
    }
}