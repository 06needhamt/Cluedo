using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cluedo
{
    // this class represents a player within the game
    class Player
    {
        string name; // variable to hold the players name
        LinkedListNode<Square> currentSquare; // variable to hold the square that the player is currently on 
        readonly LinkedListNode<Square> Start; // variable to hold the first square on the board
        public EnumCards[] cards = new EnumCards[3]; // array to hold the player's cards
        static List<string> accusations = new List<string>();

        // constructor for the player
        public Player(string name, LinkedListNode<Square> head)
        {
            // initalise the instance variables
            this.name = name;
            this.Start = head;
            this.currentSquare = this.Start;
        }

        // function to roll the dice
        public EnumDiceValues RollDice(Dice theDice)
        {
            return theDice.RollDice(); // return the value that was rolled on the dice
        }

        // function to move the player around the board
        public LinkedListNode<Square> Move(int amount)
        {
            Console.WriteLine("You Rolled " + amount); // print out the number rolled on the dice
            this.currentSquare.Value.isoccupied = false;
            // while we have still got spaces to move
            while (amount > 0)
            {
                // if the current player is on the last square on the board
                if (this.currentSquare.Next == null)
                {
                    this.currentSquare = this.Start; // move to the first square on the board
                }
                this.currentSquare = currentSquare.Next; // move to the next square on the board
                Console.WriteLine(amount + this.currentSquare.Value.name); // write the number of spaces left to move and the name of the current square to the console
                amount--; // decrement the amount of spaces left to move
                //if the current square is a doorway
                if(this.currentSquare.Value.isdoorway)
                {
                    Console.WriteLine("Do You Want to enter " + this.currentSquare.Value.name + " Y/N "); // ask the player whether they want to enter the room 
                    char input; // variable to hold the users input
                    input = Console.ReadKey().KeyChar; // get the user's input
                    if(input.Equals('Y') || input.Equals('y')) // if they entered 'Y' (Yes)
                    {
                        this.currentSquare = currentSquare.Next; // move into the room
                        Console.WriteLine(this.currentSquare.Value.name); // write the name of the room to the console
                        //this.currentSquare.Value.isoccupied = true; // set it to occupied
                        Accuse(); // make an accusation
                        return this.currentSquare; // return the current square
                    }
                    else if (input.Equals('N') || input.Equals('n')) // if they entered 'N' (No)
                    {
                        this.currentSquare = currentSquare.Next; // move over the room without decrementing moves
                        continue; // keep moving
                    }
                }
            }
            if(this.currentSquare.Value.isoccupied) // if the player landed on an occupied room
            {
                do
                {
                    if (currentSquare.Next == null) // if the player is on the last square on the board
                    {
                        this.currentSquare = this.Start; // move to the first square on the board
                    }
                    else 
                    {
                        this.currentSquare = this.currentSquare.Next; // otherwise move to the next square
                    }

                } while (this.currentSquare.Value.isoccupied); // while they are on an occupied square
            }
            Console.WriteLine(this.currentSquare.Value.name); // write the name of the square that they landed on to the console
            this.currentSquare.Value.isoccupied = true; // mark the square as occupied
            return this.currentSquare; // return the square that the player landed on
        }

        private string Accuse()
        {
            bool accused = false;
            while (!accused)
            {
                Console.WriteLine("Enter the name of the player you wish to accuse"); // ask the player to Enter the name of the player you wish to accuse
                string name = Console.ReadLine(); // save the user input
                Console.WriteLine("Enter the weapon that you think was used"); // ask the player to Enter the weapon that you think was used
                EnumCards weapon = (EnumCards)Enum.Parse(typeof(EnumCards), Console.ReadLine().ToUpper()); // save the inputted weapon
                string accusation = "I think it was " + name + " in the " + this.currentSquare.Value.name + " Using the " + weapon.ToString().ToLower(); // save the accusation
                Program.Players.Find(x => x.name.Equals(name)).currentSquare = currentSquare; // move the suspected player into the room
                // if the cuerrent accusation has already been made
                if (accusations.Contains(accusation))
                {
                    Console.WriteLine("This Accusation has already been made please make another"); // ask the user to make another
                    accused = false;
                }
                else // otherwise they have made a valid accusation
                {
                    accused = true; // a calid accusation has been made
                    accusations.Add(accusation); // add it to the list of accusations that have been made
                    Console.WriteLine(accusation);
                    return accusation; // return the accusation
                }
            }
            return null; // otherwise return null
        }
    }
}
