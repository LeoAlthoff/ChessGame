using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board
{
    internal class Position
    {
        public int Lines { get; set; }
        public int Column { get; set; }

        public Position(int lines, int column) { 
            this.Lines = lines;
            this.Column = column;
        }

    }
}
