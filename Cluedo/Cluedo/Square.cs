using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cluedo
{
    // this class represents a square on the board
    class Square
    {
        public string name = string.Empty; // variable to hold the name of the square
        public bool isroom = false; // variable to hold whether the square is a room
        public bool isdoorway = false; // variable to hold whether the square is a doorway
        public bool isoccupied = false; // variable to hold whether the square is occupied

        // constructor for the Square Class 
        public Square(string name, bool isroom, bool isdoorway, bool isoccupied )
        {
            // initialise the instance variables to the passed values
            this.name = name;
            this.isroom = isroom;
            this.isdoorway = isdoorway;
            this.isoccupied = false;
        }
    }
}
