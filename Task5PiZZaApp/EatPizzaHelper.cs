using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace Task5PiZZaApp
{
    class EatPizzaHelper
    {
        private static object lockConsole = new object();
        private static object lockObj = new object();
        private static StringBuilder strBuild = new StringBuilder();
        public static void WriteInConsole(string message)
        {
            lock (lockConsole)
            {
                Console.WriteLine(message);
                Console.WriteLine();
            }
        }

        public static void DoLog(string message)
        {
            lock (lockObj)
            {
                strBuild.AppendLine(message);
            }
        }

        public static void WriteToFile()
        {
            if (File.Exists("Pizza.log")) File.Delete("Pizza.log");
            File.AppendAllText("Pizza.log", strBuild.ToString());
        }

    }
}
