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

        private object lockObject = new object();

        public delegate void WriteToFile(string msg);
        public delegate void WriteToConsole(string msg);
        public WriteToConsole wToConsole;
        public WriteToFile wToFile;
        private Random rnd;

        public Engineer(string name, string surname)
        {
            Name = name;
            Surname = surname;
            rnd = new Random();
        }

        public void GrapPizza(object list)
        {
            GetPizza((List<Piece>)list);
        }

        private void GetPizza(List<Piece> listOfPieces)
        {
            StringBuilder strBuild = new StringBuilder();
            int piecesOfPizzaWant = rnd.Next(1, 3);
            Thread.CurrentThread.Name = "This thread is " + Name;
            strBuild.AppendLine("I'm " + Name + " " + Surname + " and I want " + piecesOfPizzaWant + " pieces. " + Thread.CurrentThread.Name);
            try
            {
                listOfPieces.RemoveRange(0, piecesOfPizzaWant);
                strBuild.Append(". After " + Name + " Pizza left: " + listOfPieces.Count);
                wToFile(Name + " " + Surname + " have taken " + piecesOfPizzaWant + " pieces");
            }
            catch (Exception)
            {
                strBuild.AppendLine(". Not enough pizza!! For " + Name);
                return;
            }
            wToConsole(strBuild.ToString());
        }


    }
}
