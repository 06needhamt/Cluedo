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
        public static List<int> answer = new List<int>();
        static Random r = new Random(); // create random number generator
        static List<int> temp;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Cluedo");
            theBoard = new Board(); // initialise the board
            theDice = new Dice(); // initialise the dice
            // initialise the players
            Players.Add(new Player("Mark", theBoard.boardSquares.First));
            Players.Add(new Player("Collette", theBoard.boardSquares.First));
            Players.Add(new Player("Chris", theBoard.boardSquares.First));
            Players.Add(new Player("Dan", theBoard.boardSquares.First));
            Players.Add(new Player("Darryl", theBoard.boardSquares.First));
            Players.Add(new Player("Sally", theBoard.boardSquares.First));
            //Players.Add(new Player("Peter", theBoard.boardSquares.First));
            DealCards(); // randomly deal the cards out to the players
            Console.WriteLine("Press any key to start the game");
            Console.ReadKey();
            GameLoop(); // start the game loop
            
        }
        // procedure to deal each player 3 cards at random
        private static void DealCards()
        {
            //Random r = new Random(); // create random number generator
            temp = Enumerable.Range(0,21).OrderBy(x => r.Next()).ToList<int>(); // fill the list with values from 0 to 20 and arrange them randomly
            //for (int k = 0; k < temp.Length; k++)
            //{
            //    Console.WriteLine(temp[k]); // write the number out to the console
            //}
            int n = 0; // index variable for temp array
            // loop to deal each player 3 cards at random
            GenerateAnswer(); // function to generate the answer required to win the game

                for (int j = 0; j < Players.Count; j++)
                {
                    Players[j].cards[0] = (EnumCards)temp[n]; // assign the current players first card to the nth element of the temp array
                    temp.RemoveAt(n);
                    Players[j].cards[1] = (EnumCards)temp[n]; // assign the current players second card to the nth element of the temp array
                    temp.RemoveAt(n);
                    Players[j].cards[2] = (EnumCards)temp[n]; // assign the current players third card to the nth element of the temp array
                    temp.RemoveAt(n);
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
            answer.Add(card1);
            temp.Remove(card1);
            answer.Add(card2);
            temp.Remove(card2);
            answer.Add(card3);
            temp.Remove(card3);

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
                    Players[i].Move((int)Players[i].RollDice(theDice));
                    Console.WriteLine("Press any key to end your turn");
                    Console.ReadKey();
                }
            }
            return 0;
        }
    }
}
