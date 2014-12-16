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
        readonly LinkedListNode<Square> head;
        public EnumCards[] cards = new EnumCards[3];

        public Player(string name, LinkedListNode<Square> head)
        {
            this.name = name;
            this.head = head;
            this.currentSquare = this.head;
        }

        public EnumDiceValues RollDice(Dice theDice)
        {
            return theDice.RollDice();
        }

        public LinkedListNode<Square> Move(int amount)
        {
            Console.WriteLine("You Rolled " + amount);
            this.currentSquare.Value.isoccupied = false;
            while (amount > 0)
            {
                if (this.currentSquare.Next == null)
                {
                    this.currentSquare = this.head;
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
                        Console.WriteLine("Enter the name of the player you wish to accuse");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter the weapon that you think was used");
                        EnumCards weapon = (EnumCards) Enum.Parse(typeof(EnumCards), Console.ReadLine());
                        Accuse(name,weapon,this.currentSquare);
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
                    if (currentSquare.Next == null)
                    {
                        this.currentSquare = this.head;
                    }
                    else
                    {
                        this.currentSquare = this.currentSquare.Next;
                        //System.Threading.Thread.Sleep(25);
                    }

                } while (this.currentSquare.Value.isoccupied);
            }
            Console.WriteLine(this.currentSquare.Value.name);
            this.currentSquare.Value.isoccupied = true;
            return this.currentSquare;
        }

        private void Accuse(string name, EnumCards Weapon, LinkedListNode<Square> currentsquare)
        {
            Program.Players.Find(x => x.name.Equals(name)).currentSquare = currentsquare; // move the suspected player into the room
            Console.WriteLine("I think it was " + name + " in the " + currentsquare.Value.name + " Using the " + Weapon.ToString());
        }
    }
}
