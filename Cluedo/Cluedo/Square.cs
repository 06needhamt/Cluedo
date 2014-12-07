using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cluedo
{
    class Square
    {
        public string name = string.Empty;
        public bool isroom = false;
        public bool isdoorway = false;
        public bool isoccupied = false;

        public Square(string name, bool isroom, bool isdoorway, bool isoccupied )
        {
            this.name = name;
            this.isroom = isroom;
            this.isdoorway = isdoorway;
            this.isoccupied = false;
        }
    }
}
