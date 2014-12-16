using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cluedo
{
    // this class represents the dice
    class Dice
    {

        // this method rolls the dice
        public EnumDiceValues RollDice()
        {
            Random R = new Random(); // create a random number generator
            return (EnumDiceValues)R.Next(1, 7); // generate a random number between 1 and 6
        }
    }
}
