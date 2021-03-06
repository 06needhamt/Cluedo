﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace Cluedo
{
    class Program
    {
        static Board theBoard; // variable to hold the board
        static Dice theDice; // variable to hold the dice
        public static List<Player> Players = new List<Player>(6); // list to hold the players
        public static List<EnumCards> answer = new List<EnumCards>();
        static Random r = new Random(); // create random number generator
        static List<int> temp;
        public static string answerstring;
        public static bool GameWon = false;

        static void Main(string[] args)
        {
            PlaySound();
            Console.WriteLine("Welcome To Cluedo");
            theBoard = new Board(); // initialise the board
            theDice = new Dice(); // initialise the dice
            // initialise the players
            CreatePlayers();
            PrintData(); // print the list of cards to the console so the player can write them down
            DealCards(); // randomly deal the cards out to the players
            Console.WriteLine("Press any key to start the game");
            Console.ReadKey();
            int winner = GameLoop(); // start the game loop
            Console.WriteLine("Player " + winner + " Has won the game");
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
            
        }
        // Function to print the list of cards to the console so the player can write them down
        private static void PrintData()
        {
            Console.WriteLine("Please write these down before we begin");
            // print the players
            Console.WriteLine("These are the players");
            for(int i = 0; i < Players.Count; i++)
            {
                Console.WriteLine(Players.ElementAt(i).name);
            }
            Console.WriteLine("Press any key to see the weapons");
            Console.ReadKey();
            Console.Clear();
            // print the weapons
            Console.WriteLine("These are the weapons");
            Console.WriteLine(EnumCards.PEN_DRIVE.ToString().ToLower());
            Console.WriteLine(EnumCards.KEYBOARD.ToString().ToLower());
            Console.WriteLine(EnumCards.POWER_CABLE.ToString().ToLower());
            Console.WriteLine(EnumCards.POWER_POINT_SLIDES.ToString().ToLower());
            Console.WriteLine(EnumCards.SCISSORS.ToString().ToLower());
            Console.WriteLine(EnumCards.SOLDERING_IRON.ToString().ToLower());
            Console.WriteLine(EnumCards.STAPLER.ToString().ToLower());
            Console.WriteLine("Press any key to see the rooms");
            Console.ReadKey();
            Console.Clear();
            // print the rooms
            Console.WriteLine("These are the rooms");
            Console.WriteLine(EnumCards.CE011.ToString().ToLower());
            Console.WriteLine(EnumCards.FOYER.ToString().ToLower());
            Console.WriteLine(EnumCards.LAPTOP_LAB.ToString().ToLower());
            Console.WriteLine(EnumCards.LECTURE_THEATRE.ToString().ToLower());
            Console.WriteLine(EnumCards.NETWORK_LAB.ToString().ToLower());
            Console.WriteLine(EnumCards.RESEARCH_LAB.ToString().ToLower());
            Console.WriteLine(EnumCards.SCHOOL_OFFICE.ToString().ToLower());
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
        // Function to initialise the players
        private static void CreatePlayers()
        {
            // add each of the active players to the list of players
            Players.Add(new Player("mark", theBoard.boardSquares.First));
            Players.Add(new Player("collette", theBoard.boardSquares.First));
            Players.Add(new Player("chris", theBoard.boardSquares.First));
            Players.Add(new Player("dan", theBoard.boardSquares.First));
            Players.Add(new Player("darryl", theBoard.boardSquares.First));
            Players.Add(new Player("sally", theBoard.boardSquares.First));
            Players.Add(new Player("peter", theBoard.boardSquares.First));
        }
        // this function plays a sond when the game is first open
        private static void PlaySound()
        {
            SoundPlayer sp = new SoundPlayer();
            string currentdir = System.Environment.CurrentDirectory + "/"; // current working directory
            sp.SoundLocation = currentdir + "openTune.wav"; // load the sound file to be played into the sound player
            sp.Play(); // play the sound
            sp.Dispose(); // dispose the sound player

        }
        // procedure to deal each player 3 cards at random
        private static void DealCards()
        {
            temp = Enumerable.Range(0,21).OrderBy(x => r.Next()).ToList<int>(); // fill the list with values from 0 to 20 and arrange them randomly
            int index = 0; // index variable for temp array
            // loop to deal each player 3 cards at random
            GenerateAnswer(); // function to generate the answer required to win the game

                for (int j = 0; j < Players.Count - 1 ; j++)
                {
                    Players[j].cards[0] = (EnumCards)temp[index]; // assign the current players first card to the nth element of the temp array
                    temp.RemoveAt(index);
                    Players[j].cards[1] = (EnumCards)temp[index]; // assign the current players second card to the nth element of the temp array
                    temp.RemoveAt(index);
                    Players[j].cards[2] = (EnumCards)temp[index]; // assign the current players third card to the nth element of the temp array
                    temp.RemoveAt(index);
                    // print out the current players cards
                    Console.WriteLine("Player " + (j + 1) + " Your playing cards are");
                    Console.WriteLine(Players[j].cards[0].ToString());
                    Console.WriteLine(Players[j].cards[1].ToString());
                    Console.WriteLine(Players[j].cards[2].ToString());
                    Console.WriteLine("Please check these off your list");
                    Console.WriteLine("Press any key player " + (j + 2));
                    Console.ReadKey();
                    Console.Clear();
                }
            
        }
        // this function generates the answer required to win the game
        private static void GenerateAnswer()
        {
            // generate the numbers of the cards that will be used in the answer
            int card1 = r.Next(0, 7);
            int card2 = r.Next(7, 14);
            int card3 = r.Next(14, 21);
            // add the cards to the answer list and remove them from the list of cards to deal
            answer.Add((EnumCards)card1);
            temp.Remove(card1);
            answer.Add((EnumCards)card2);
            temp.Remove(card2);
            answer.Add((EnumCards)card3);
            temp.Remove(card3);
            answerstring = "I think it was " + answer.ElementAt(1).ToString().ToLower() + " in the " + answer.ElementAt(0).ToString().ToLower() + " Using the " + answer.ElementAt(2).ToString().ToLower(); // save the accusation
            Console.WriteLine(answerstring);
        }
        // main game loop function
        private static int GameLoop()
        {
            // main game loop
            while(true)
            {
                // loop that controls players turn
                for (int i = 0; i < Players.Count - 1 ; i++ )
                {
                    Console.Clear();
                    Console.WriteLine("Player " + (i + 1) + "'s " + "turn");
                    Players[i].Move((int)Players[i].RollDice(theDice)); // make the current player roll the dice
                    if(Program.GameWon) // if the game is won
                    {
                        Console.WriteLine("Player " + (i + 1) + " Has won the game "); // write the winner to the console
                        return (i + 1); // return the winning player number
                    }
                    Console.WriteLine("Press any key to end your turn"); // tell the player to press any key to end their turn
                    Console.ReadKey();
                }
            }
            return 0;
        }
    }
}
