using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task5PiZZaApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Kitchen kitch = new Kitchen();
            List<Piece> pizzaPieces = kitch.Pizza.GetPieces();
            while (pizzaPieces.Count>0)
            kitch.EatPizza(ref pizzaPieces);
            Console.ReadLine();
        }
    }
}
