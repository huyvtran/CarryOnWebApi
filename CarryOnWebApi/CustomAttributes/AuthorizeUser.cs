using Entities;
using Newtonsoft.Json;
using Services;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace CarryOnWebApi.CustomAttributes
{
    public class AuthorizeUser : AuthorizeAttribute
    {
        public AuthorizeUser()
        {
        }
     
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            try
            {
                var headers = System.Web.HttpContext.Current.Request.Headers;
                UserModel userInfo = null;
                if (headers["userInfo"] != null)
                {
                    userInfo = JsonConvert.DeserializeObject<UserModel>(headers["userInfo"]);
                }

                if (userInfo == null)
                    return false;

                var userId = userInfo.UserId;
                                
                var accountService = GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IAccountService)) as AccountService;
                var configurator = GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IConfigurationProvider)) as Configuration;
                
                userInfo = accountService.GetUserByToken(userInfo.Token);
                //userInfo = accountService.GetUserByToken(userInfo.Token);
                //var anagInfo = accountService.GetUserAnagInfo(userId);

                if (userInfo == null)
                {
                    return false;
                }
                else
                {
                    SharedConfig.UserInfo = userInfo;
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}