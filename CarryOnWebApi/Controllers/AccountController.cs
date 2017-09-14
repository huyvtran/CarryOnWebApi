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
    public class AccountController : ApiController
    {
        private IAccountService accountService;
        private ILogService logger;
        private IConfigurationProvider configuration = null;
        
        public AccountController() { }

        public AccountController(IAccountService accountService, ILogService logger,
            IConfigurationProvider _config)
        {
            this.accountService = accountService;
            this.logger = logger;
            this.configuration = _config;
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [Route("api/Account/Login")]
        public ResultModel<UserModel> Login(LoginViewModel model)
        {
            logger.LogApi(() => Login(model), null);
            ErrorsEnum retMsg = ErrorsEnum.GENERIC_ERROR;
            var res = new ResultModel<UserModel>();
            res.ResultData = new UserModel();

            try
            {
                bool error = false;
                if (!ModelState.IsValid)
                {
                    error = true;
                    retMsg = ErrorsEnum.LOGIN_INVALID_MODEL;
                }

                var user = accountService.UserLogin(model.Username, model.Password, model.Token);
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
        [AuthorizeUser]
        [HttpPost]
        [Route("api/Account/Logout")]
        public BaseResultModel Logout()
        {
            bool error = false;
            if (!ModelState.IsValid)
            {
                error = true;
            }

            var user = configuration.UserInfo;
            var token = user.Token;

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
        [Route("api/Account/ForgotPassword")]
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
        [Route("api/Account/ChangePassword")]
        public BaseResultModel ChangePassword(string oldPassword, string newPassword)
        {
            //var user = RouteData.Values["user"] as UserModel;
            var user = configuration.UserInfo;
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
        [Route("api/Account/ResetPassword")]
        public BaseResultModel ResetPassword(string resetPswdUserName, string resetPswdToken, string resetPswd)
        {
            logger.LogApi(() => ResetPassword(resetPswdUserName, resetPswdToken, "**********"), resetPswdUserName);

            var result = accountService.ResetPassword(resetPswdUserName, resetPswdToken, resetPswd);

            return result;
        }

        // POST: /Account/RegisterEmail
        [HttpPost]
        [Route("api/Account/RegisterEmail")]
        public BaseResultModel RegisterEmail(string userName, string email)
        {
            logger.LogApi(() => RegisterEmail(userName, email), userName);

            var result = accountService.RegisterEmail(userName, email);

            return result;
        }

        [HttpPost]
        [Route("api/Account/CreateUser")]
        public ResultModel<UserModel> CreateUser(UserModel userModel)
        {            
            logger.LogApi(() => CreateUser(userModel), null);

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
        [Route("api/Account/UpdateUser")]
        public ResultModel<UserModel> UpdateUser(UserModel userModel)
        {
            var user = configuration.UserInfo;
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
        [Route("api/Account/WriteLog")]
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
    }
}
