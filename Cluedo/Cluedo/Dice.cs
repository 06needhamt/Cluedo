using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cluedo
{
    class Dice
    {
        EnumDiceValues currentvalue;

        public Dice()
        {

        }

        public EnumDiceValues RollDice()
        {
            Random R = new Random();
            return (EnumDiceValues)R.Next(1, 7);
        }
    }
}
