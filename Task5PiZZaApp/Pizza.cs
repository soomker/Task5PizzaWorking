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

        private List<Piece> pieces;
        public Pizza(string name, int piecesCount)
        {
            Name = name;
            PiecesCount = piecesCount;
            pieces = new List<Piece>();
            for (int i = 0; i < piecesCount; i++)
            {
                pieces.Add(new Piece(name + " piece"));
            }
        }

        public List<Piece> GetPieces()
        { 
         return pieces;
        }


    }
}
