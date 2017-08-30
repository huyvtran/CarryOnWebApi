using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace Services.Helpers
{
    public class PasswordGenerator
    {
        public static string GetEncryptedPassword(string password)
        {
            string cStringa = string.Empty;
            int nCodeKey = 187;
            int nI;

            var charsPassword = password.ToCharArray();
            for (int i = 0; i < charsPassword.Length; i++)
            {
                nI = charsPassword[i] ^ nCodeKey;
                cStringa = cStringa + Strings.Chr(nI);
            }

            return cStringa;
        }
    }
}
