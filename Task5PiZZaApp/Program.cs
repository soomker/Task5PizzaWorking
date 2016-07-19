using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Task5PiZZaApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Pizza pizza = new Pizza("Paperrony", 12);
            Engineer eng1 = new Engineer("Tirion", "Lanister");
            Engineer eng2  = new Engineer("Jhon", "Snow");
            Engineer eng3 = new Engineer("Aria", "Stark");
            List<Engineer> enginList = new List<Engineer> { eng1, eng2, eng3 };
            List<object> countList = new List<object>();

            for (int i = 0; i < pizza.PiecesCount; i++)
            {
                countList.Add(new object());
            }

            if (File.Exists("Pizza.log"))
            {
                File.Delete("Pizza.log");
            }

            while (countList.Count > 0)
            {
                foreach (Engineer eng in enginList)
                {
                    Thread thr = new Thread(new ParameterizedThreadStart(eng.GrabPizza));
                    thr.Start(countList);
                    Thread.Sleep(1);
                }
            }
            Engineer.WriteLog();

            Console.ReadLine();
        }
   
    }
}
