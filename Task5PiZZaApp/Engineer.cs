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

        public delegate void WriteToFile(string msg);

        public int PiecesLeft { get; private set; }

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
            Console.ForegroundColor = ConsoleColor.Gray;
            int piecesOfPizzaWant = rnd.Next(1, 3);
            Thread.CurrentThread.Name = "This thread is "+ Name;
            Console.Write("I'm " + Name + " " + Surname + " and I want " + piecesOfPizzaWant + " pieces. " + Thread.CurrentThread.Name);
           
            try
            {
                listOfPieces.RemoveRange(0, piecesOfPizzaWant);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(". After "+Name+" Pizza left: " + listOfPieces.Count);
                Console.WriteLine();
                wToFile(Name + " " + Surname + " have taken " + piecesOfPizzaWant + " pieces");
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(". Not enough pizza!! For " + Name);
                return;
            }
          
            
        }

       
    }
}
