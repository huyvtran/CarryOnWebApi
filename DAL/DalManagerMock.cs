using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data.Entity;
using DAL.Helper;

namespace DAL
{
    public class DalManagerMock : IDalManager
    {
        protected CarryOnEntities entities;
        protected DbContextTransaction transaction;

        public DalManagerMock()
        {
            entities = new CarryOnEntities();
            entities.Configuration.AutoDetectChangesEnabled = false;
            entities.Configuration.ValidateOnSaveEnabled = false;
            bool instanceExists = System.Data.Entity.SqlServer.SqlProviderServices.Instance != null;
        }

        #region User

        public db_VW_USER_TOKEN GetUserByToken(string token)
        {
            return MockUserHelper.get_USER_TOKEN();
        }

        public db_CO01UT GetUserByUsername(string username)
        {
            return MockUserHelper.getUser();
        }

        public db_CO01UT GetUserByUsernameAndPassword(string username, string password)
        {
            return MockUserHelper.getUser();
        }

        /// <summary>
        /// Insert a new User
        /// </summary>
        /// <param name="idCompany">company id</param>
        /// <param name="user">user</param>
        /// <param name="role">role of user in company</param>
        public void InsertUser(db_CO01UT user)
        {
            return;
        }

        public void UpdateUser(db_CO01UT user)
        {
            return;
        }

        /// <summary>
        /// Update user password
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="password">new password</param>
        public void UpdateUserPassword(string username, string password)
        {
            return;
        }

        public db_CO01UT GetUserByEmail(string email)
        {
            return MockUserHelper.getUser();
        }

        /// <summary>
        /// Update user email
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="email">user email</param>
        public void UpdateUserEmail(string username, string email)
        {
            return;
        }

        #endregion

        #region Token

        public void InsertToken(string token, DateTime insertDate, DateTime expirationDate, string username)
        {
            return;
        }

        public void RefreshToken(string token, DateTime lastUsageDate, DateTime expirationDate)
        {
            return;
        }

        public List<db_CO_TOKEN> GetTokenByUsername(string username)
        {
            return MockUserHelper.getToken();
        }

        public void DeleteToken(string token)
        {
            return;
        }

        #endregion

        #region Addresses

        public void InsertAddress(AddressModel adr)
        {
            throw new NotImplementedException();
        }

        public void UpdateAddress(AddressModel adr)
        {
            throw new NotImplementedException();
        }

        public void DeleteAddress(Guid adrId)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Transfer Good

        public List<db_ReqGoodTransferWithAddresses> GetReqGoodTransfer_ByKeyFields(Guid? reqId)
        {
            return MockHelper.getRqgtList();
        }

        public List<db_ReqGoodTransferWithAddresses> GetReqGoodTransfer_ByKeySomeEqualFields(Nullable<System.Guid> id, Nullable<System.Guid> addressFrom, Nullable<System.Guid> addreessDest, Nullable<System.DateTime> dateTransportFixed, Nullable<int> dateTransportType, string dateTransportInfo, Nullable<int> requestState, Nullable<System.Guid> userId, string volRequired)
        {
            return MockHelper.getRqgtList();
        }

        public void InsertReqGoodTransfer(db_ReqGoodTransferWithAddresses rgtItem)
        {
            return;
        }

        public void UpdateReqGoodTransfer(db_ReqGoodTransferWithAddresses rgtItem)
        {
            return;
        }

        public void DeleteReqGoodTransfer(Guid rgtId)
        {
            return;
        }

        #endregion

        #region Transport Options

        public List<db_ReqGoodTransportOptions> GetReqGoodTransportOptionsByTransportId(Guid transportId)
        {
            return new List<db_ReqGoodTransportOptions>();
        }

        public void InsertReqGoodTransferOption(ReqGoodTransportOptions reqGoodTransferOptionItem)
        {
            return;
        }

        public void UpdateReqGoodTransferOption(ReqGoodTransportOptions reqGoodTransferOptionItem)
        {
            return;
        }

        public void DeleteReqGoodTransferOption(ReqGoodTransportOptions reqGoodTransferOptionItem)
        {
            return;
        }

        #endregion

        #region Transport availability

        public List<db_TransportAvWithAddress> GetTransportAv_ByKeyFields(Guid? transportId)
        {
            return MockHelper.getTransportAvList();
        }

        public List<db_TransportAvWithAddress> GetTransportAv_ByKeySomeEqualFields(Nullable<System.Guid> id, Nullable<System.Guid> addressFrom, Nullable<System.Guid> addreessDest, Nullable<System.DateTime> dateTransportFixed, Nullable<int> dateTransportType, string dateTransportInfo, Nullable<int> requestState, Nullable<System.Guid> userId, string volAvailable)
        {
            return MockHelper.getTransportAvList();
        }

        public void InsertTransportAv(db_TransportAvWithAddress transportAvItem)
        {
            return;
        }

        public void UpdateTransportAv(db_TransportAvWithAddress transportAvItem)
        {
            return;
        }

        public void DeleteTransportAv(Guid rgtId)
        {
            return;
        }

        #endregion
    }
}
