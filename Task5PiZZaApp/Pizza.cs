using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5PiZZaApp
{
    class Pizza
    {
        public string Name { get; private set; }
        public int PiecesCount { get; private set; }

       
        public Pizza(string name, int piecesCount)
        {
            Name = name;
            PiecesCount = piecesCount;
        }
    }
}
