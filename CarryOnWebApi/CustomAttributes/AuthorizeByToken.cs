using Entities.enums;
using Services;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarryOnWebApi.CustomAttributes
{
    public class AuthorizeByToken : AuthorizeAttribute
    {
        private ActionEnum[] actions { get; set; }

        public AuthorizeByToken(params ActionEnum[] actions)
        {
            this.actions = actions;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (Authorize(filterContext))
            {
                return;
            }
            HandleUnauthorizedRequest(filterContext);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new HttpUnauthorizedResult();
        }

        private bool Authorize(AuthorizationContext filterContext)
        {
            try
            {
                var headers = filterContext.HttpContext.Request.Headers;
                var token = headers["Token"];
                var idAnag = headers["IdAnag"];

                if (token == null || idAnag == null)
                    return false;

                var accountService = DependencyResolver.Current.GetService<IAccountService>();
                var user = accountService.GetUserByToken(token);

                if (user == null)
                {
                    return false;
                }
                else
                {
                    ////Check if the user is allowed to use this action
                    //var company = user.Companies.Where(c => c.Id == int.Parse(idAnag)).FirstOrDefault();
                    //if (company == null)
                    //    return false;

                    //bool allowed = false;

                    //if (actions.Count() > 0)
                    //{
                    //    foreach (var action in actions)
                    //    {
                    //        if (company.Actions.Any(a => a == action))
                    //            allowed = true;
                    //    }

                    //    if (!allowed)
                    //        return false;
                    //}                    
                    
                    //filterContext.RouteData.Values.Add("company", company);
                    filterContext.RouteData.Values.Add("user", user);

                    //Use this to get the property from the controller:
                    //var company = RouteData.Values["company"] as CompanyModel
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