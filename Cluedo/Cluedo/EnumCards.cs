using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cluedo
{
    enum EnumCards
    {
        #region Rooms
        CE011 = 0,
        SCHOOL_OFFICE = 1,
        LECTURE_THEATRE = 2,
        LAPTOP_LAB = 3,
        NETWORK_LAB = 4,
        FOYER = 5,
        RESEARCH_LAB = 6,
        #endregion Rooms

        #region Suspects
        MARK = 7,
        COLLETTE = 8,
        CHRIS = 9,
        DAN = 10,
        DARREL = 11,
        SALLY = 12,
        PETER = 13,
        #endregion Suspects

        #region Weapons
        PEN_DRIVE = 14,
        POWER_CABLE = 15,
        KEYBOARD = 16,
        STAPLER = 17,
        SOLDERING_IRON = 18,
        SCISSORS = 19,
        POWER_POINT_SLIDES = 20
        #endregion Weapons
    }
}
