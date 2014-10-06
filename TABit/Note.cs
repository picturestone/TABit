using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TABit
{
    class Note
    {
        public int fret { get; set; }
        public int length { get; set; }
        public int stringnumber { get; set; }
        public int startpoint { get; set; }

        /*
         * fret:
         *      0 - whatever    fret
         *      -1              ghoste note
         *      -2              pause
         */


        public Note(int fret, int length, int stringnumber, int startpoint)
        {
            this.fret = fret;
            this.length = length;
            this.stringnumber = stringnumber;
            this.startpoint = startpoint;
        }
    }
}
