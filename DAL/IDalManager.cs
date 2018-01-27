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
               
        #region User

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
        /// Update user password
        /// </summary>
        /// <param name="username"> username</param>
        /// <param name="password"> new password</param>
        /// <returns></returns>
        void UpdateUserPassword(string username, string password);
        
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
        /// Delete User by Email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        void DeleteUserById(Guid userId);

        #endregion


        #region Token

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

        /// <summary>
        /// Get a Token by username
        /// </summary>
        /// <param name="username">username</param>
        /// <returns></returns>
        List<db_CO_TOKEN> GetTokenByUsername(string username);

        /// <summary>
        /// Delete a token
        /// </summary>
        /// <param name="token">token</param>
        void DeleteToken(string token);

        #endregion


        #region Address

        /// <summary>
        /// Add address
        /// </summary>
        /// <param name="adr">address to add</param>
        void InsertAddress(db_GeoCodeAddress adr);

        /// <summary>
        /// Add address
        /// </summary>
        /// <param name="adr">address to add</param>
        void UpdateAddress(db_GeoCodeAddress adr);

        /// <summary>
        /// Delete address
        /// </summary>
        /// <param name="adr">address to add</param>
        void DeleteAddress(Guid adrId);

        #endregion


        #region ReqGoodTransfer

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reqId"></param>
        /// <returns></returns>
        List<db_ReqGoodTransferWithAddresses> GetReqGoodTransfer_ByKeyFields(Guid? reqId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="addressFrom"></param>
        /// <param name="addreessDest"></param>
        /// <param name="dateTransportFixed"></param>
        /// <param name="dateTransportType"></param>
        /// <param name="dateTransportInfo"></param>
        /// <param name="requestState"></param>
        /// <param name="userId"></param>
        /// <param name="volRequired"></param>
        /// <returns></returns>
        List<db_ReqGoodTransferWithAddresses> GetReqGoodTransfer_ByKeySomeEqualFields(Nullable<System.Guid> id, Nullable<System.Guid> addressFrom, Nullable<System.Guid> addreessDest, Nullable<System.DateTime> dateTransportFixed, Nullable<int> dateTransportType, string dateTransportInfo, Nullable<int> requestState, Nullable<System.Guid> userId, string volRequired);

        /// <summary>
        /// Add transfer good request
        /// </summary>
        /// <param name="reqGoodTransferItem">Transfer good request</param>
        void InsertReqGoodTransfer(db_ReqGoodTransferWithAddresses reqGoodTransferItem);

        /// <summary>
        /// Update transfer good request
        /// </summary>
        /// <param name="reqGoodTransferItem">Transfer good request</param>
        void UpdateReqGoodTransfer(db_ReqGoodTransferWithAddresses reqGoodTransferItem);

        /// <summary>
        /// Delete transfer good request
        /// </summary>
        /// <param name="id">Item id</param>
        void DeleteReqGoodTransfer(Guid rgtId);

        #endregion


        #region TransferAv

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reqId"></param>
        /// <returns></returns>
        List<db_TransportAvWithAddress> GetTransportAv_ByKeyFields(Guid? reqId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="addressFrom"></param>
        /// <param name="addreessDest"></param>
        /// <param name="dateTransportFixed"></param>
        /// <param name="dateTransportType"></param>
        /// <param name="dateTransportInfo"></param>
        /// <param name="requestState"></param>
        /// <param name="userId"></param>
        /// <param name="volRequired"></param>
        /// <returns></returns>
        List<db_TransportAvWithAddress> GetTransportAv_ByKeySomeEqualFields(Nullable<System.Guid> id, Nullable<System.Guid> addressFrom, Nullable<System.Guid> addreessDest, Nullable<System.DateTime> dateTransportFixed, Nullable<int> dateTransportType, string dateTransportInfo, Nullable<int> requestState, Nullable<System.Guid> userId, string volAvailable);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transportAvItem"></param>
        void InsertTransportAv(db_TransportAvWithAddress transportAvItem);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="transportAvItem"></param>
        void UpdateTransportAv(db_TransportAvWithAddress transportAvItem);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rgtId"></param>
        void DeleteTransportAv(Guid rgtId);

        #endregion


        #region ReqGoodTransfer Options

        /// <summary>
        ///  Transport Id
        /// </summary>
        /// <param name="transportId"></param>
        /// <returns>Options list</returns>
        List<db_ReqGoodTransportOptions> GetReqGoodTransportOptionsByTransportId(Guid transportId);

        /// <summary>
        /// Add transfer good request Option
        /// </summary>
        /// <param name="reqGoodTransferItem">Transfer good request option</param>
        void InsertReqGoodTransferOption(ReqGoodTransportOptions reqGoodTransferOptionItem);

        /// <summary>
        /// Update transfer good request Option
        /// </summary>
        /// <param name="reqGoodTransferItem">Transfer good request option</param>
        void UpdateReqGoodTransferOption(ReqGoodTransportOptions reqGoodTransferOptionItem);

        /// <summary>
        /// Delete transfer good request Option
        /// </summary>
        /// <param name="reqGoodTransferItem">Transfer good request option</param>
        void DeleteReqGoodTransferOption(ReqGoodTransportOptions reqGoodTransferOptionItem);

        #endregion

    }
}
