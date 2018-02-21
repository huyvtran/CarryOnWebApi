using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace Services.Helpers
{
    public static class UtilityCheck
    {
        public static string GetStringIfDecimalElseNull(string strIn)
        {
            decimal number;

            if (Decimal.TryParse(strIn, out number))
                return strIn;
            else
                return null;

        }
    }
}