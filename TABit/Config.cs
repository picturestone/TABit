using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TABit
{
    static class Config
    {
        public static int get_lines_between_blocks()
        {
            string user_lines_between_blocks = TABit.Properties.Settings.Default.SLinesUser;
            if (user_lines_between_blocks == "")
            {
                return Convert.ToInt16(TABit.Properties.Settings.Default.SLinesDefault);
            }
            return Convert.ToInt16(user_lines_between_blocks);
        }

        public static int get_chars_per_string()
        {
            string user_chars_per_string = TABit.Properties.Settings.Default.SCharsUser;
            if (user_chars_per_string == "")
            {
                return Convert.ToInt16(TABit.Properties.Settings.Default.SCharsDefault);
            }
            return Convert.ToInt16(user_chars_per_string);
        }

        //TODO get timing upside and downside from config
        public static int get_timing_upside(Main main)
        {
            return Convert.ToInt16(main.cbTimingUpside.Text);
        }

        public static int get_timing_downside(Main main)
        {
            return Convert.ToInt16(main.cbTimingDownside.Text);
        }
    }
}
