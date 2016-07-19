using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Task5PiZZaApp
{
    class Engineer
    {
        public string Name { get; private set; }
        public string Surname { get; private set;}

        private static string pathToLogFile;

        private StringBuilder strBuild = new StringBuilder();

        private static StringBuilder stringBuildForFile = new StringBuilder();
       
        private Random rnd;

        public Engineer(string name, string surname)
        {
            Name = name;
            Surname = surname;
            rnd = new Random();
            pathToLogFile = "Pizza.log";
        }

        public void GrabPizza(object count)
        {
           List<object> pizzaCount = (List<object>)count;
            GetPizza(pizzaCount);
        }

        private void GetPizza(List<object> countOfPieces)
        {
            strBuild.Clear();
            int piecesOfPizzaWant = rnd.Next(1, 3);
            Thread.CurrentThread.Name = "This thread is " + Name;
            strBuild.AppendLine("I'm " + Name + " " + Surname + " and I want " + piecesOfPizzaWant + " pieces. " + Thread.CurrentThread.Name);

            
             try
             {
                  lock (countOfPieces)
                 {
                    countOfPieces.RemoveRange(0, piecesOfPizzaWant);
                 }
                  strBuild.AppendLine(" After " + Name + " Pizza left: " + countOfPieces.Count);

                 lock (stringBuildForFile)
                 {
                    stringBuildForFile.AppendLine(Name + " " + Surname + " have taken " + piecesOfPizzaWant + " pieces");
                 }
             }
             catch (Exception)
             {
                lock (stringBuildForFile)
                {
                    strBuild.AppendLine(" Not enough pizza!! For " + Name);
                }
             }

            Console.WriteLine(strBuild);
        }

        public static void WriteLog()
        {
            lock (pathToLogFile)
            {
                File.AppendAllText(pathToLogFile, stringBuildForFile.ToString());
            }
        }

    }
}
