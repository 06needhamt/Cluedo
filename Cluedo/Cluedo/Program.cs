using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cluedo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Cluedo");
            Board theBoard = new Board();
            Dice theDice = new Dice();
            Player Player1 = new Player("Mark", ref theBoard);
            Player1.Move((int)Player1.RollDice(theDice));
            Console.ReadKey();
        }
    }
}
