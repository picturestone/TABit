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
    }
}
