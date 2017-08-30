using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IDalManager
    {
        List<db_ReqGoodTransferWithAddresses> GetReqGoodTransfer_ByKeyFields(Guid? reqId);
        List<db_ReqGoodTransferWithAddresses> GetReqGoodTransfer_ByKeySomeEqualFields(Nullable<System.Guid> id, Nullable<System.Guid> addressFrom, Nullable<System.Guid> addreessDest, Nullable<System.DateTime> dateTransportFixed, Nullable<int> dateTransportType, string dateTransportInfo, Nullable<int> requestState);

        /// <summary>
        /// Get a db_VW_USER_TOKEN by token
        /// </summary>
        /// <param name="token">token</param>
        /// <returns></returns>
        db_VW_USER_TOKEN GetUserByToken(string token);

        /// <summary>
        /// GEt User by username
        /// </summary>
        /// <param name="username"> username </param>
        /// <returns></returns>
        db_CO01UT GetUserByUsername(string username);

        /// <summary>
        /// Get a db_VW_USER_TOKEN by username and password
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="password">password</param>
        /// <returns></returns>
        db_CO01UT GetUserByUsernameAndPassword(string username, string password);

        /// <summary>
        /// Insert a new User
        /// </summary>
        /// <param name="idCompany"> company id</param>
        /// <param name="user">user</param>

        void InsertUser(db_CO01UT user);

        /// <summary>
        /// Update user
        /// </summary>
        /// <param name="user"></param>
        void UpdateUser(db_CO01UT user);

        /// <summary>
        /// Delete a token
        /// </summary>
        /// <param name="token">token</param>
        void DeleteToken(string token);

        /// <summary>
        /// Update user password
        /// </summary>
        /// <param name="username"> username</param>
        /// <param name="password"> new password</param>
        /// <returns></returns>
        void UpdateUserPassword(string username, string password);

        /// <summary>
        /// Get a Token by username
        /// </summary>
        /// <param name="username">username</param>
        /// <returns></returns>
        List<db_CO_TOKEN> GetTokenByUsername(string username);

        /// <summary>
        /// Get User by Email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        db_CO01UT GetUserByEmail(string email);

        /// <summary>
        /// Update user email
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="email">user email</param>
        void UpdateUserEmail(string username, string email);

        /// <summary>
        /// Insert a Token
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="insertDate">insert date</param>
        /// <param name="expirationDate">expiration date</param>
        /// <param name="username">username</param>
        void InsertToken(string token, DateTime insertDate, DateTime expirationDate, string username);
        
        /// <summary>
        /// Refresh the expiration date of a Token
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="lastUsageDate">last usate date</param>
        /// <param name="expirationDate">expiration date</param>
        void RefreshToken(string token, DateTime lastUsageDate, DateTime expirationDate);
    }
}
