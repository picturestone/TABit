using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TABit
{
    static class Config
    {
        public static int getLinesBetweenBlocks()
        {
            string userLinesBetweenBlocks = TABit.Properties.Settings.Default.SLinesUser;
            if (userLinesBetweenBlocks == "")
            {
                return Convert.ToInt16(TABit.Properties.Settings.Default.SLinesDefault);
            }
            return Convert.ToInt16(userLinesBetweenBlocks);
        }

        public static int getCharsPerString()
        {
            string userCharsPerString = TABit.Properties.Settings.Default.SCharsUser;
            if (userCharsPerString == "")
            {
                return Convert.ToInt16(TABit.Properties.Settings.Default.SCharsDefault);
            }
            return Convert.ToInt16(userCharsPerString);
        }

        //TODO get timing upside and downside from config
        public static int getTimingUpside(Main main)
        {
            return Convert.ToInt16(main.cbTimingUpside.Text);
        }

        public static int getTimingDownside(Main main)
        {
            return Convert.ToInt16(main.cbTimingDownside.Text);
        }

        public static int getBarWhereCursorIsIn(Main main)
        {
            int charnumber = main.tbWorkspace.SelectionStart;
            for (int i = 0; i < Convert.ToInt16(main.cbStrings.Text); i++)
            {
                foreach (Bar bar in main.notesheet.bars)
                {
                    int barlength = bar.getBarLength(bar.getNoteLengths());
                    if (charnumber > barlength)
                    {
                        charnumber = charnumber - barlength;
                    }
                }
            }
            return 0;
        }
    }
}
