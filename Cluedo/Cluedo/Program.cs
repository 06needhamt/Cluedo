using System;
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
            DealCards(); // randomly deal the cards out to the players
            Console.WriteLine("Press any key to start the game");
            Console.ReadKey();
            GameLoop(); // start the game loop
            
        }
        // Function to initialise the players
        private static void CreatePlayers()
        {
            // add each of the active players to the list of players
            Players.Add(new Player("Mark", theBoard.boardSquares.First));
            Players.Add(new Player("Collette", theBoard.boardSquares.First));
            Players.Add(new Player("Chris", theBoard.boardSquares.First));
            Players.Add(new Player("Dan", theBoard.boardSquares.First));
            Players.Add(new Player("Darryl", theBoard.boardSquares.First));
            Players.Add(new Player("Sally", theBoard.boardSquares.First));
        }

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
            //Random r = new Random(); // create random number generator
            temp = Enumerable.Range(0,21).OrderBy(x => r.Next()).ToList<int>(); // fill the list with values from 0 to 20 and arrange them randomly
            int index = 0; // index variable for temp array
            // loop to deal each player 3 cards at random
            GenerateAnswer(); // function to generate the answer required to win the game

                for (int j = 0; j < Players.Count; j++)
                {
                    Players[j].cards[0] = (EnumCards)temp[index]; // assign the current players first card to the nth element of the temp array
                    temp.RemoveAt(index);
                    Players[j].cards[1] = (EnumCards)temp[index]; // assign the current players second card to the nth element of the temp array
                    temp.RemoveAt(index);
                    Players[j].cards[2] = (EnumCards)temp[index]; // assign the current players third card to the nth element of the temp array
                    temp.RemoveAt(index);
                    // print out the current players cards
                    Console.WriteLine("Player " + (j + 1) + " Your cards are");
                    Console.WriteLine(Players[j].cards[0].ToString());
                    Console.WriteLine(Players[j].cards[1].ToString());
                    Console.WriteLine(Players[j].cards[2].ToString());
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
                for (int i = 0; i < Players.Count; i++ )
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
