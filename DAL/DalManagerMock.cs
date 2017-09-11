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
            throw new NotImplementedException();
        }

        public db_CO01UT GetUserByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public db_CO01UT GetUserByUsernameAndPassword(string username, string password)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Insert a new User
        /// </summary>
        /// <param name="idCompany">company id</param>
        /// <param name="user">user</param>
        /// <param name="role">role of user in company</param>
        public void InsertUser(db_CO01UT user)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(db_CO01UT user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update user password
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="password">new password</param>
        public void UpdateUserPassword(string username, string password)
        {
            throw new NotImplementedException();
        }

        public db_CO01UT GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update user email
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="email">user email</param>
        public void UpdateUserEmail(string username, string email)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Token

        public void InsertToken(string token, DateTime insertDate, DateTime expirationDate, string username)
        {
            throw new NotImplementedException();
        }

        public void RefreshToken(string token, DateTime lastUsageDate, DateTime expirationDate)
        {
            throw new NotImplementedException();
        }

        public List<db_CO_TOKEN> GetTokenByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public void DeleteToken(string token)
        {
            throw new NotImplementedException();
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
