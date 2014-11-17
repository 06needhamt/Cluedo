using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cluedo
{
    class Board
    {
        private LinkedList<Square> board = new LinkedList<Square>();

        public Board()
        {
            for (int i = 0; i <= 36; i++)
            {
                board.AddLast(new Square());
            }
        }
    }
}
