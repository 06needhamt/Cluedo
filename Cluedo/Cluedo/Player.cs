using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cluedo
{
    class Player
    {
        string name;
        LinkedListNode<Square> currentSquare;
        Board board;
        public EnumCards[] cards = new EnumCards[3];

        public Player(string name, ref Board board)
        {
            this.name = name;
            this.board = board;
            this.currentSquare = board.boardSquares.First;
        }

        public EnumDiceValues RollDice(Dice theDice)
        {
            return theDice.RollDice();
        }

        public LinkedListNode<Square> Move(int amount)
        {
            Console.WriteLine("You Rolled " + amount);
            this.currentSquare.Value.isoccupied = false;
            while (amount != 0)
            {
                if (this.currentSquare.Next == null)
                {
                    this.currentSquare = board.boardSquares.First;
                }
                this.currentSquare = currentSquare.Next;
                Console.WriteLine(amount + this.currentSquare.Value.name);
                amount--;
                if(this.currentSquare.Value.isdoorway)
                {
                    Console.WriteLine("Do You Want to enter " + this.currentSquare.Value.name + " Y/N ");
                    char input;
                    input = Console.ReadKey().KeyChar;
                    if(input.Equals('Y') || input.Equals('y'))
                    {
                        this.currentSquare = currentSquare.Next;
                        Console.WriteLine(this.currentSquare.Value.name);
                        this.currentSquare.Value.isoccupied = true;
                        return this.currentSquare;
                    }
                    else if (input.Equals('N') || input.Equals('n'))
                    {
                        this.currentSquare = currentSquare.Next;
                        continue;
                    }
                }
            }
            if(this.currentSquare.Value.isoccupied)
            {
                do
                {
                    this.currentSquare = this.currentSquare.Next;
                    System.Threading.Thread.Sleep(25);

                } while (this.currentSquare.Value.isoccupied);
            }
            Console.WriteLine(this.currentSquare.Value.name);
            this.currentSquare.Value.isoccupied = true;
            return this.currentSquare;
        }
    }
}
