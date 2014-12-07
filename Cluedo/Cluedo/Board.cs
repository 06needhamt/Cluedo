using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cluedo
{
    class Board
    {
        public LinkedList<Square> boardSquares = new LinkedList<Square>();

        public Board()
        {
            this.boardSquares.AddLast(new Square("Blank Square",false,false,false));
            this.boardSquares.AddLast(new Square("Blank Square",false,false,false));
            this.boardSquares.AddLast(new Square("Blank Square",false,false,false));
            this.boardSquares.AddLast(new Square("Doorway To Laptop Lab",false,true,false));
            this.boardSquares.AddLast(new Square("Laptop Lab", true, false, false));
            this.boardSquares.AddLast(new Square("Blank Square", false, false, false));
            this.boardSquares.AddLast(new Square("Blank Square", false, false, false));
            this.boardSquares.AddLast(new Square("Blank Square", false, false, false));
            this.boardSquares.AddLast(new Square("Doorway To Network Lab", false, true, false));
            this.boardSquares.AddLast(new Square("Network Lab", true, false, false));
            this.boardSquares.AddLast(new Square("Blank Square", false, false, false));
            this.boardSquares.AddLast(new Square("Doorway To School Office", false, true, false));
            this.boardSquares.AddLast(new Square("Network Lab", true, false, false));
            this.boardSquares.AddLast(new Square("Blank Square", false, false, false));
            this.boardSquares.AddLast(new Square("Doorway To CE011", false, true, false));
            this.boardSquares.AddLast(new Square("CE011", true, false, false));
            this.boardSquares.AddLast(new Square("Blank Square", false, false, false));
            this.boardSquares.AddLast(new Square("Blank Square", false, false, false));
            this.boardSquares.AddLast(new Square("Blank Square", false, false, false));
            this.boardSquares.AddLast(new Square("Doorway To Foyer", false, true, false));
            this.boardSquares.AddLast(new Square("Foyer", true, false, false));
            this.boardSquares.AddLast(new Square("Blank Square", false, false, false));
            this.boardSquares.AddLast(new Square("Blank Square", false, false, false));
            this.boardSquares.AddLast(new Square("Blank Square", false, false, false));
            this.boardSquares.AddLast(new Square("Doorway To Lecture Theatre", false, true, false));
            this.boardSquares.AddLast(new Square("Lecture Theatre", true, false, false));
            this.boardSquares.AddLast(new Square("Blank Square", false, false, false));
            this.boardSquares.AddLast(new Square("Doorway To Research Lab", false, true, false));
            this.boardSquares.AddLast(new Square("Research Lab", true, false, false));
            this.boardSquares.AddLast(new Square("Blank Square", false, false, false));
            this.boardSquares.AddLast(new Square("Blank Square", false, false, false));
            //this.boardSquares.Last = this.boardSquares.First;
        }
    }
}
