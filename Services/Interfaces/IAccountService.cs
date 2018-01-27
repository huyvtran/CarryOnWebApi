using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IAccountService
    {
        /// <summary>
        /// Generate a new token for an username
        /// </summary>
        /// <param name="username">username</param>
        /// <returns></returns>
        string GenerateToken(string username);
        /// <summary>
        /// return user object by username and password
        /// </summary>
        /// <param name="username"> username</param>
        /// <param name="password">password</param>
        /// <param name="token">token</param>
        /// <returns></returns>
        UserModel UserLogin(string username, string password, string token);
        /// <summary>
        /// get user object by token
        /// </summary>
        /// <param name="token">token</param>
        /// <returns></returns>
        UserModel GetUserByToken(string token);
        /// <summary>
        /// delete the token to log out a user
        /// </summary>
        /// <param name="token">token</param>
        void UserLogout(string token);
        /// <summary>
        /// Change user password
        /// </summary>
        /// <param name="user"></param>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <returns>Operation result</returns>
        BaseResultModel ChangePassword(UserModel user, string oldPassword, string newPassword);

        /// <summary>
        /// Resets the password.
        /// </summary>
        /// <param name="uten">The uten.</param>
        /// <returns></returns>
        BaseResultModel ResetPassword(string uten);

        /// <summary>
        /// Send an email when password is forgotten
        /// </summary>
        /// <param name="email">Email</param>
        /// <param name="recoverBasicUrl">Recoveder url</param>
        /// <returns>Operation result</returns>
        BaseResultModel ForgotPassword(string email, string recoverBasicUrl);

        /// <summary>
        /// Reset user password
        /// </summary>
        /// <param name="resetPswdUserName">User Name</param>
        /// <param name="resetPswdToken">Token</param>
        /// <param name="resetPswd">New password</param>
        /// <returns>Operation result</returns>
        BaseResultModel ResetPassword(string resetPswdUserName, string resetPswdToken, string resetPswd);

        /// <summary>
        /// Register user email
        /// </summary>
        /// <param name="userName">User Name</param>
        /// <param name="email">Email</param>
        /// <returns>Operation result</returns>
        BaseResultModel RegisterEmail(string userName, string email);

        /// <summary>
        /// Generates the password.
        /// </summary>
        /// <param name="codUt">The cod ut.</param>
        /// <returns></returns>
        string GeneratePassword(string codUt);
        /// <summary>
        /// Create new User.
        /// </summary>
        /// <param name="user">user.</param>
        /// <returns></returns>
        ResultModel<UserModel> CreateUser(UserModel user);
        /// <summary>
        /// Udate User.
        /// </summary>
        /// <param name="user">user.</param>
        /// <returns></returns>
        ResultModel<UserModel> UpdateUser(UserModel user);

        /// <summary>
        /// Udate User.
        /// </summary>
        /// <param name="userName">userName</param>
        /// <returns></returns>
        BaseResultModel DeleteUser(string userName);
    }
}
