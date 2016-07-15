using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Task5PiZZaApp
{
    class Kitchen
    {
       private object lockObj = new object();
       public Pizza Pizza { get; private set; }
       private Engineer eng1;
       private Engineer eng2;
       private Engineer eng3;
       private List<Engineer> engineers;
       private StringBuilder strBuild;
       
        public Kitchen()
        {
            Pizza = new Pizza("Paperonni", 12);
            eng1 = new Engineer("Tirion", "Lanister");
            eng2 = new Engineer("Jhon", "Snow");
            eng3 = new Engineer("Aria", "Stark");
            engineers = new List<Engineer> { eng1, eng2, eng3 };
            strBuild = new StringBuilder();

            foreach (Engineer eng in engineers)
            {
                eng.wToFile += LogToFile;
            }
        }

        public void StartEatPizza(ref List<Piece> piecesOfPizza)
        {
            foreach (Engineer eng in engineers)
            {
                Thread thr = new Thread(new ParameterizedThreadStart(eng.GrapPizza));
                thr.Start(piecesOfPizza);
                thr.Join();
            }
            if (File.Exists("Pizza.log")) File.Delete("Pizza.log");
            File.AppendAllText("Pizza.log", strBuild.ToString());
            
        }

        private void LogToFile(string message)
        { 
         lock(lockObj)
         {
             strBuild.AppendLine(message);
         }
        }
    }
}
