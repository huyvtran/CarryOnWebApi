using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Helper
{
    public static class MockUserHelper
    {
        public static db_CO01UT getUser()
        {
            return new db_CO01UT
            {
                UTEN = "luca.liguori@gmail3.com",
                EMAI = "luca.liguori@gmail3.com",
                LANG = "IT-it",
                PASS = "ÏÞÈÏ",
                TELE = "3325784589",
                TELE2 = "0511235789",
                NOME = "luca liguori",
                ID = new Guid()
            };
        }

        internal static List<db_CO_TOKEN> getToken()
        {
            return new List<db_CO_TOKEN>()
            {
                new db_CO_TOKEN {
                DATA_CREAZIONE = DateTime.Today,
                DATA_SCADENZA = DateTime.Today.AddDays(1),
                DATA_ULTIMO_UTILIZZO = DateTime.Today.AddDays(-1),
                TOKEN = "test_token_12345",
                USERNAME = "luca.liguori@gmail3.com"
                }
            };
        }

        internal static db_VW_USER_TOKEN get_USER_TOKEN()
        {
            var token = getToken().ToList().FirstOrDefault();
            var user = getUser();

            return new db_VW_USER_TOKEN
            {
                DATA_CREAZIONE = token.DATA_CREAZIONE,
                DATA_ULTIMO_UTILIZZO = token.DATA_ULTIMO_UTILIZZO,
                DATA_SCADENZA = token.DATA_SCADENZA,
                TOKEN = token.TOKEN,
                UTEN = user.UTEN,
                USERNAME = user.NOME,
                PASS = user.PASS,
                EMAI = user.EMAI,
                ID = user.ID,
                LANG = user.LANG,
                NOME = user.NOME,
                TELE = user.TELE,
                TELE2 = user.TELE2,
            };
        }
    }
}
