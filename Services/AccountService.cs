﻿using DAL;
using DAL.Mapper;
using Entities;
using Entities.enums;
using Services.Helpers;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AccountService : BaseAccountService, IAccountService
    {
        private ILogService logger;

        //public AccountService(ILogService logger) : base(logger, new DalManager())
        //{
        //    this.logger = logger;
        //    dbManager = new DalManager();
        //}

        public AccountService(ILogService logger, IDalManager dbManager) : base(logger, dbManager)
        {
            this.logger = logger;
            this.dbManager = dbManager;
        }

        public UserModel GetUserByToken(string token)
        {
            logger.Log(() => GetUserByToken(token));

            try
            {
                var dbUser = dbManager.GetUserByToken(token);

                var user = UserMapper.UserToken_DbUserToken(dbUser);
                user.Token = token;

                return user;
            }
            catch (Exception e)
            {
                StringBuilder parameterStringBuilder = new StringBuilder();
                parameterStringBuilder.Append(" username=" + token);

                logger.Log(parameterStringBuilder.ToString(), e);

                return null;
            }
        }

        public UserModel UserLogin(string username, string password, string inputToken)
        {
            logger.Log(() => UserLogin(username, "****", "****"));
            UserModel user = null;
            
            try
            {
                /* Is login by token? */
                if (!string.IsNullOrEmpty(inputToken)) {
                    return GetUserByToken(inputToken);
                }

                var token = "";
                var encryptedPassword = PasswordGenerator.GetEncryptedPassword(password);

                var dbUser = dbManager.GetUserByUsernameAndPassword(username, encryptedPassword);
                //if (dbUser == null || dbUser.TIPU == UserType.R.ToString())
                //    return null;

                token = GetAndRefreshToken(dbUser.UTEN);
                if (string.IsNullOrEmpty(token))
                {
                    //No valid token present
                    token = GenerateToken(dbUser.UTEN);
                }

                user = UserMapper.UserMapper_DbToModel(dbUser);
                user.Token = token;
            }
            catch (Exception e)
            {
                logger.Log(() => UserLogin(username, "****", "****"), e);
            }
            return user;
        }

        public void UserLogout(string token)
        {
            logger.Log(() => UserLogout(token));
            try
            {
                dbManager.DeleteToken(token);
            }
            catch (Exception e)
            {
                StringBuilder parameterStringBuilder = new StringBuilder();
                parameterStringBuilder.Append(" token=" + token);

                logger.Log(parameterStringBuilder.ToString(), e);
                return;
            }
        }

        public BaseResultModel ResetPassword(string uten)
        {
            logger.Log(() => ResetPassword(uten));

            var opResult = new BaseResultModel() { OperationResult = true };
            opResult.OperationResult = true;
            try
            {
                if (string.IsNullOrWhiteSpace(uten)) throw new Exception("Missing parameter: uten");
                dbManager.UpdateUserPassword(uten, GeneratePassword(uten));
            }
            catch (Exception e)
            {
                StringBuilder parameterStringBuilder = new StringBuilder();
                parameterStringBuilder.Append(" uten=" + uten);

                logger.Log(parameterStringBuilder.ToString(), e);

                // set the operation result
                opResult.OperationResult = false;
                opResult.ResultMessage = ErrorsEnum.GENERIC_ERROR;
            }
            return opResult;
        }

        public BaseResultModel ChangePassword(UserModel user, string oldPassword, string newPassword)
        {
            logger.Log(() => ChangePassword(user, null, null));

            var opResult = new BaseResultModel();
            opResult.OperationResult = true;
            try
            {
                // check if password is corect for the current user
                var encryptedOldPassword = PasswordGenerator.GetEncryptedPassword(oldPassword);
                var dbUser = dbManager.GetUserByUsernameAndPassword(user.UserEmail, encryptedOldPassword);
                if (dbUser == null)
                {
                    opResult.OperationResult = false;
                    opResult.ResultMessage = ErrorsEnum.GENERIC_ERROR;
                }
                else
                {
                    // update password
                    var encryptedNewPassword = PasswordGenerator.GetEncryptedPassword(newPassword);
                    dbManager.UpdateUserPassword(user.UserEmail, encryptedNewPassword);
                }

            }
            catch (Exception e)
            {
                StringBuilder parameterStringBuilder = new StringBuilder();
                parameterStringBuilder.Append(" username=" + user.UserEmail);

                logger.Log(parameterStringBuilder.ToString(), e);

                // set the operation result
                opResult.OperationResult = false;
                opResult.ResultMessage = ErrorsEnum.GENERIC_ERROR;
            }
            return opResult;
        }

        public BaseResultModel ResetPassword(string resetPswdUserName, string resetPswdToken, string resetPswd)
        {
            logger.Log(() => ResetPassword(resetPswdUserName, resetPswdToken, resetPswd));

            var opResult = new BaseResultModel();
            opResult.OperationResult = true;
            try
            {
                // check if token is valid for the current user
                var tokenList = dbManager.GetTokenByUsername(resetPswdUserName);
                var validToken = tokenList.FirstOrDefault(t => t.DATA_SCADENZA.Value > DateTime.Now);

                if (validToken == null || validToken.TOKEN != resetPswdToken)
                {
                    opResult.OperationResult = false;
                    opResult.ResultMessage = ErrorsEnum.GENERIC_ERROR;
                }
                else
                {
                    // update password
                    var encryptedNewPassword = PasswordGenerator.GetEncryptedPassword(resetPswd);
                    dbManager.UpdateUserPassword(resetPswdUserName, encryptedNewPassword);
                }

            }
            catch (Exception e)
            {
                StringBuilder parameterStringBuilder = new StringBuilder();
                parameterStringBuilder.Append(" username=" + resetPswdUserName);
                parameterStringBuilder.Append(" token=" + resetPswdToken);

                logger.Log(parameterStringBuilder.ToString(), e);

                // set the operation result
                opResult.OperationResult = false;
                opResult.ResultMessage = ErrorsEnum.GENERIC_ERROR;
            }
            return opResult;
        }

        public BaseResultModel RegisterEmail(string userName, string email)
        {
            logger.Log(() => RegisterEmail(userName, email));

            var opResult = new BaseResultModel();
            opResult.OperationResult = true;

            try
            {
                /* Check if a user with that email already exists */
                var dbUser = dbManager.GetUserByEmail(email);
                if (dbUser != null)
                {
                    opResult.OperationResult = false;
                    opResult.ResultMessage = ErrorsEnum.EMAIL_ALREADY_PRESENT;
                    return opResult;
                }

                /* Register email here */
                dbManager.UpdateUserEmail(userName, email);
            }
            catch (Exception e)
            {
                StringBuilder parameterStringBuilder = new StringBuilder();
                parameterStringBuilder.Append(" username=" + userName);
                parameterStringBuilder.Append(" email=" + email);

                logger.Log(parameterStringBuilder.ToString(), e);

                // set the operation result
                opResult.OperationResult = false;
                opResult.ResultMessage = ErrorsEnum.GENERIC_ERROR;
            }
            return opResult;
        }

        public BaseResultModel ForgotPassword(string email, string recoverBasicUrl)
        {
            logger.Log(() => ForgotPassword(email, recoverBasicUrl));

            var opResult = new BaseResultModel();
            opResult.OperationResult = true;
            string userName, token, linkForMail;

            try
            {
                /*  1 ---- Get the user from the mail */
                var dbUser = dbManager.GetUserByEmail(email);
                if (dbUser == null)
                {
                    opResult.OperationResult = false;
                    opResult.InfoLog = "User Not Found";
                    opResult.ResultMessage = ErrorsEnum.USER_NOT_PRESENT;
                    return opResult;
                }

                userName = dbUser.UTEN;
                var tokenList = dbManager.GetTokenByUsername(userName);
                var validToken = tokenList.FirstOrDefault(t => t.DATA_SCADENZA.Value > DateTime.Now);

                /* 2 ---- Check if the user has a valid token and in case getAndRefresh it */
                if (validToken == null)
                {
                    /* If it has not a valid token, create one */
                    token = GenerateToken(dbUser.UTEN);
                }
                else
                {
                    /* There is a valid token */
                    RefreshToken(validToken.TOKEN);
                    token = validToken.TOKEN;
                }

                /* 4 - Create the link from userName and token. 
                 * Example is: http://localhost:54496/#/user/recover-pswd?userName=USER_JOB_BRUNO&userToken=4c0ff4e0-46f2-4dc4-a3a2-00499c078cf4
                 */
                linkForMail = recoverBasicUrl + "?userName=" + userName + "&userToken=" + token;

                /* 5 - Create and send the mail */
                MailSenderHelper mailHelper = new MailSenderHelper
                {
                    SenderMail = "coadmin@coadmin.com",
                    ReceiverMail = email,
                    Subject = string.Concat("CO - User : ", userName, " - Reset password procedure"),
                    Body = createMailBody(userName, linkForMail),
                };
                mailHelper.SendMail();
            }
            catch (Exception e)
            {
                StringBuilder parameterStringBuilder = new StringBuilder();
                parameterStringBuilder.Append(" email=" + email);

                logger.Log(parameterStringBuilder.ToString(), e);

                // set the operation result
                opResult.OperationResult = false;
                opResult.ResultMessage = ErrorsEnum.GENERIC_ERROR;
            }
            return opResult;
        }

        public BaseResultModel DeleteUser(string userName)
        {
            logger.Log(() => DeleteUser(userName));

            var opResult = new BaseResultModel();
            opResult.OperationResult = true;

            try
            {
                /*  1 ---- Get the user from the mail */
                var dbUser = dbManager.GetUserByEmail(userName);
                if (dbUser == null)
                {
                    opResult.OperationResult = false;
                    opResult.InfoLog = "User Not Found";
                    opResult.ResultMessage = ErrorsEnum.USER_NOT_PRESENT;
                    return opResult;
                }
                
                dbManager.DeleteUserById(dbUser.ID);
            }
            catch (Exception e)
            {
                logger.Log(() => DeleteUser(userName), e);
                opResult.OperationResult = false;
                opResult.ResultMessage = ErrorsEnum.GENERIC_ERROR;
            }
            return opResult;
        }

        public ResultModel<UserModel> CreateUser(UserModel user)
        {
            logger.Log(() => CreateUser(user));
            var resultModel = new ResultModel<UserModel>() { OperationResult = true };
            try
            {
                //check if username is already registerd
                var existingUser = dbManager.GetUserByUsername(user.UserEmail);
                if (existingUser != null)
                {
                    resultModel.OperationResult = false;
                    resultModel.ResultMessage = ErrorsEnum.USERNAME_ALREADY_PRESENT;
                    return resultModel;
                }

                //check if email is already registerd
                if (!string.IsNullOrWhiteSpace(user.UserEmail))
                {
                    var existingUserWithEmail = dbManager.GetUserByEmail(user.UserEmail);
                    if (existingUserWithEmail != null)
                    {
                        resultModel.OperationResult = false;
                        resultModel.ResultMessage = ErrorsEnum.EMAIL_ALREADY_PRESENT;
                        return resultModel;
                    }
                }

                var userDb = UserMapper.UserMapper_ModelToDb(user);
                userDb.PASS = PasswordGenerator.GetEncryptedPassword(userDb.PASS);
                /* First insert Address */
                /* TO BE DEVELOPED IF NEEDED */

                /* Than insert user */
                dbManager.InsertUser(userDb);
                
                //return inserted user
                var newUserDb = dbManager.GetUserByUsername(user.UserEmail);
                var newUser = UserMapper.UserMapper_DbToModel(newUserDb);
                resultModel.ResultData = newUser;
            }
            catch (Exception e)
            {
                logger.Log(() => CreateUser(user), e);
                resultModel.OperationResult = false;
                resultModel.ResultMessage = ErrorsEnum.GENERIC_ERROR;
            }
            return resultModel;
        }

        public UserModel GetUserByEmail(string userEmail)
        {
            logger.Log(() => GetUserByEmail(userEmail));
            //var resultModel = new ResultModel<UserModel>() { OperationResult = true };
            UserModel userModel = null;
            try
            {
                var userModelDb = dbManager.GetUserByUsername(userEmail);
                if (userModelDb != null)
                 {
                    userModel = UserMapper.UserMapper_DbToModel(userModelDb);
                }
            }
            catch (Exception e)
            {
                return userModel;
            }
            return userModel;
        }

        public ResultModel<UserModel> UpdateUser(UserModel userToUpdate)
        {
            logger.Log(() => UpdateUser(userToUpdate));
            var resultModel = new ResultModel<UserModel>() { OperationResult = true };
            try
            {
                //check if email is already registerd
                if (!string.IsNullOrWhiteSpace(userToUpdate.UserEmail))
                {
                    var existingUser = dbManager.GetUserByEmail(userToUpdate.UserEmail);
                    if (existingUser != null && userToUpdate.UserEmail.Trim() != existingUser.UTEN.Trim())
                    {
                        resultModel.OperationResult = false;
                        resultModel.ResultMessage = ErrorsEnum.EMAIL_ALREADY_PRESENT;
                        return resultModel;
                    }
                }

                //var userDB = dbManager.GetUserByUsername(user.UserEmail);
                var userToUpdateDb = UserMapper.UserMapper_ModelToDb(userToUpdate);
                dbManager.UpdateUser(userToUpdateDb);

                /* Get updated user from db */
                var updatedUserDB = dbManager.GetUserByUsername(userToUpdateDb.UTEN);
                var updatedUser = UserMapper.UserMapper_DbToModel(updatedUserDB);
                /* Return result */
                resultModel.ResultData = updatedUser;
            }
            catch (Exception e)
            {
                logger.Log(() => UpdateUser(userToUpdate), e);
                resultModel.OperationResult = false;
                resultModel.ResultMessage = ErrorsEnum.GENERIC_ERROR;
            }
            return resultModel;
        }

        private void AddLine(ref string strBefore, string strToAdd)
        {
            strBefore = string.Concat(strBefore, strToAdd + "\n");
        }

        private string createMailBody(string userName, string linkForMail)
        {
            string body = string.Empty;

            /* Fill body */
            AddLine(ref body, "Ciao utente " + userName);
            AddLine(ref body, "");
            AddLine(ref body, "Utilizza il seguente link per effettuare il reset della tua password:");
            AddLine(ref body, "");

            AddLine(ref body, linkForMail);

            AddLine(ref body, "");
            body = string.Concat(body, "  ------  ");
            AddLine(ref body, "");
            body = string.Concat(body, "Si prega di non rispondere direttamente a questo messaggio poiché è stato inviato da un indirizzo e-mail non programmato per la ricezione.");

            return body;
        }
    }
}
