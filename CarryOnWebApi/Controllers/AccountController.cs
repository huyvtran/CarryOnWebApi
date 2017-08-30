using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using CarryOnWebApi.Models;
using CarryOnWebApi.Providers;
using CarryOnWebApi.Results;
using Services.Interfaces;
using Entities.enums;
using Entities;
using CarryOnWebApi.CustomAttributes;
//using System.Web.Mvc;
//using System.Web.Http.Results;

namespace CarryOnWebApi.Controllers
{
    public class AccountController : BaseController
    {
        private IAccountService accountService;
        private ILogService logger;

        public AccountController(IAccountService accountService, ILogService logger)
        {
            this.accountService = accountService;
            this.logger = logger;
        }

        //
        // POST: /Account/Login
        [HttpPost]
        public ResultModel<UserModel> Login(LoginViewModel model)
        {
            ErrorsEnum retMsg = ErrorsEnum.GENERIC_ERROR;
            var res = new ResultModel<UserModel>();
            res.ResultData = new UserModel();

            try
            {
                logger.LogApi(() => Login(model), model.Username);

                bool error = false;
                if (!ModelState.IsValid)
                {
                    error = true;
                    retMsg = ErrorsEnum.LOGIN_INVALID_MODEL;
                }

                var user = accountService.UserLogin(model.Username, model.Password);
                if (user == null || string.IsNullOrEmpty(user.Token))
                {
                    error = true;
                    retMsg = ErrorsEnum.LOGIN_USER_PSWD_WRONG;
                }

                // create token if ok !
                res.OperationResult = true;
                res.ResultMessage = retMsg;
                res.ResultData = user;
                return res;
            }
            catch (System.Exception e)
            {

                logger.Log("", e);
                res.OperationResult = false;
                return res;
            }
        }

        [AuthorizeByToken]
        public BaseResultModel ResetPassword(string uten)
        {
            bool error = false;
            var result = accountService.ResetPassword(uten);
            if (!result.OperationResult)
            {
                error = true;
            }
            return result;
        }

        //
        // POST: /Account/Logout
        [HttpPost]
        public BaseResultModel Logout()
        {
            bool error = false;
            if (!ModelState.IsValid)
            {
                error = true;
            }

            var token = Request.Headers["Token"];

            logger.LogApi(() => Logout(), accountService.GetUserByToken(token).UTEN);

            accountService.UserLogout(token);

            // create token if ok !
            return new BaseResultModel()
            {
                OperationResult = !error,
                ResultMessage = null,
                InfoLog = ""
            };
        }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        public BaseResultModel ForgotPassword(ForgotPasswordViewModel model, string recoverBasicUrl)
        {
            logger.LogApi(() => ForgotPassword(model, recoverBasicUrl), model.Email);

            var result = accountService.ForgotPassword(model.Email, recoverBasicUrl);

            // send mail 
            return result;
        }

        
        //
        // POST: /Account/ChangePassword
        [AuthorizeByToken]
        [HttpPost]
        public BaseResultModel ChangePassword(string oldPassword, string newPassword)
        {
            var user = RouteData.Values["user"] as UserModel;
            logger.LogApi(() => ChangePassword("**********", "**********"), user.UTEN);

            var result = new BaseResultModel();
            bool error = false;
            if (ModelState.IsValid)
            {
                result = accountService.ChangePassword(user, oldPassword, newPassword);
                if (!result.OperationResult)
                {
                    error = true;
                }
            }

            return result;
        }

        //
        // GET: /Account/ForgotPasswordConfirmation

        //public JsonResult ForgotPasswordConfirmation()
        //{
        //    //email link confirmation
        //    return View();
        //}


        // POST: /Account/ResetPassword
        [HttpPost]
        public BaseResultModel ResetPassword(string resetPswdUserName, string resetPswdToken, string resetPswd)
        {
            logger.LogApi(() => ResetPassword(resetPswdUserName, resetPswdToken, "**********"), resetPswdUserName);

            var result = accountService.ResetPassword(resetPswdUserName, resetPswdToken, resetPswd);

            return result;
        }

        // POST: /Account/RegisterEmail
        [HttpPost]
        public BaseResultModel RegisterEmail(string userName, string email)
        {
            logger.LogApi(() => RegisterEmail(userName, email), userName);

            var result = accountService.RegisterEmail(userName, email);

            return result;
        }

        [HttpPost]
        public ResultModel<UserModel> CreateUser(UserModel userModel)
        {
            var user = RouteData.Values["user"] as UserModel;
            logger.LogApi(() => CreateUser(userModel), user.UTEN);

            // check if all required fields are filled in
            if (!ModelState.IsValid)
            {
                return new ResultModel<UserModel>()
                {
                    ResultData = new UserModel(),
                    OperationResult = false,
                    ResultMessage = ErrorsEnum.GENERIC_ERROR
                };
            }
            return accountService.CreateUser(userModel);
        }

        [AuthorizeByToken]
        [HttpPost]
        public ResultModel<UserModel> UpdateUser(UserModel userModel)
        {
            var user = RouteData.Values["user"] as UserModel;
            logger.LogApi(() => UpdateUser(userModel), user.UTEN);

            // check if all required fields are filled in
            if (!ModelState.IsValid)
            {
                return new ResultModel<UserModel>()
                {
                    ResultData = new UserModel(),
                    OperationResult = false,
                    ResultMessage = ErrorsEnum.GENERIC_ERROR
                };
            }
            return accountService.UpdateUser(userModel);
        }

        /// <summary>
        /// Write logs from client side
        /// </summary>
        /// <param name="status"></param>
        /// <param name="statusText"></param>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResultModel WriteLog(string status, string statusText, string url, string data, string user)
        {
            var message = $"{{Status={status}, StatusText={statusText}, Url={url}, User={user} Error={data}}}";

            logger.Log(LogLevel.ERROR, message);

            return new BaseResultModel()
            {
                OperationResult = false,
                ResultMessage = null,
                InfoLog = ""
            };
        }
        
        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        //private ActionResult RedirectToLocal(string returnUrl)
        //{
        //    if (Url.IsLocalUrl(returnUrl))
        //    {
        //        return Redirect(returnUrl);
        //    }
        //    return RedirectToAction("Index", "Home");
        //}

        //internal class ChallengeResult : HttpUnauthorizedResult
        //{
        //    public ChallengeResult(string provider, string redirectUri)
        //        : this(provider, redirectUri, null)
        //    {
        //    }

        //    public ChallengeResult(string provider, string redirectUri, string userId)
        //    {
        //        LoginProvider = provider;
        //        RedirectUri = redirectUri;
        //        UserId = userId;
        //    }

        //    public string LoginProvider { get; set; }
        //    public string RedirectUri { get; set; }
        //    public string UserId { get; set; }

        //    public override void ExecuteResult(ControllerContext context)
        //    {
        //        var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
        //        if (UserId != null)
        //        {
        //            properties.Dictionary[XsrfKey] = UserId;
        //        }
        //        context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
        //    }
        //}
        #endregion
    }
}
