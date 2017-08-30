using DAL;
using Services.Helpers;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BaseAccountService
    {
        private ILogService logger;
        protected IDalManager dbManager;

        public BaseAccountService(ILogService logger, IDalManager dbManager)
        {
            this.logger = logger;
            this.dbManager = dbManager;
        }

        public string GenerateToken(string username)
        {
            try
            {
                var token = Guid.NewGuid().ToString();

                dbManager.InsertToken(token, DateTime.Now, DateTime.Now.AddHours(GetTokenDuration()), username);

                return token;
            }
            catch (Exception e)
            {
                StringBuilder parameterStringBuilder = new StringBuilder();
                parameterStringBuilder.Append(" username=" + username);

                logger.Log(parameterStringBuilder.ToString(), e);

                return "";
            }
        }
        

        /// <summary>
        /// Generates the password.
        /// </summary>
        /// <param name="codUt">The cod ut.</param>
        /// <returns></returns>
        public string GeneratePassword(string codUt)
        {
            logger.Log(() => GeneratePassword(codUt));
            return PasswordGenerator.GetEncryptedPassword(codUt);
        }


        protected string GetAndRefreshToken(string username)
        {
            logger.Log(() => GetAndRefreshToken(username));

            var tokenList = dbManager.GetTokenByUsername(username);
            var validToken = tokenList.FirstOrDefault(t => t.DATA_SCADENZA.Value > DateTime.Now);

            if (validToken != null)
            {
                //There is a valid token
                RefreshToken(validToken.TOKEN);
                return validToken.TOKEN;
            }
            else
            {
                //No valid token
                return "";
            }
        }

        protected void RefreshToken(string token)
        {
            logger.Log(() => RefreshToken(token));
            try
            {
                var tokenDuration = GetTokenDuration();
                dbManager.RefreshToken(token, DateTime.Now, DateTime.Now.AddHours(GetTokenDuration()));
            }
            catch (Exception e)
            {
                StringBuilder parameterStringBuilder = new StringBuilder();
                parameterStringBuilder.Append(" token=" + token);

                logger.Log(parameterStringBuilder.ToString(), e);
                return;
            }
        }

        protected static int GetTokenDuration()
        {
            //return int.Parse(System.Configuration.ConfigurationManager.AppSettings["TokenDurationInHours"]);
            return 2;
        }

    }
}
