using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data.Entity;

namespace DAL
{
    public class DalManager : IDalManager
    {
        protected CarryOnEntities entities;
        protected DbContextTransaction transaction;

        public DalManager()
        {
            entities = new CarryOnEntities();
            entities.Configuration.AutoDetectChangesEnabled = false;
            entities.Configuration.ValidateOnSaveEnabled = false;
            bool instanceExists = System.Data.Entity.SqlServer.SqlProviderServices.Instance != null;
        }

        public List<db_ReqGoodTransferWithAddresses> GetReqGoodTransfer_ByKeyFields(Guid? reqId)
        {
            //return entities.GetAllReqGoodTransfer_ByKeyFields(reqId).ToList();
            return entities.f_GetAllFieldsFromReqGoodTransfer_BySomeEqualFields(reqId, null, null, null, null, null, null).ToList();
        }

        public List<db_ReqGoodTransferWithAddresses> GetReqGoodTransfer_ByKeySomeEqualFields(Nullable<System.Guid> id, Nullable<System.Guid> addressFrom, Nullable<System.Guid> addreessDest, Nullable<System.DateTime> dateTransportFixed, Nullable<int> dateTransportType, string dateTransportInfo, Nullable<int> requestState)
        {
            return entities.f_GetAllFieldsFromReqGoodTransfer_BySomeEqualFields(id, addressFrom, addreessDest, dateTransportFixed, dateTransportType, dateTransportInfo, requestState).ToList();
        }

        public db_VW_USER_TOKEN GetUserByToken(string token)
        {
            return entities.GetViewUserToken(token).FirstOrDefault();
        }

        public db_CO01UT GetUserByUsername(string username)
        {
            var user = entities.f_GetAllFieldsFromCO01UT_BySomeEqualFields(null, username, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null).FirstOrDefault();
            if ((user != null))
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public db_CO01UT GetUserByUsernameAndPassword(string username, string password)
        {
            var user = entities.f_GetAllFieldsFromCO01UT_BySomeEqualFields(null, username, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null).FirstOrDefault();
            if ((user != null) && (user.PASS == password))
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Insert a new User
        /// </summary>
        /// <param name="idCompany">company id</param>
        /// <param name="user">user</param>
        /// <param name="role">role of user in company</param>
        public void InsertUser(db_CO01UT user)
        {
            entities.f_InsertIntoCO01UT(new Guid(), user.UTEN, user.TIPU, user.PASS,
                user.PWGG, user.PWSC, user.NOME, user.LANG, user.EMAI,
                user.TELE, user.FAXN, user.UFFI, user.RIF1, user.RIF2, user.TELE2, null);
        }

        public void UpdateUser(db_CO01UT user)
        {
            entities.f_UpdateAllFieldsFromCO01UT_ByKeyFields(user.ID, user.UTEN, user.TIPU, user.PASS, user.PWGG, user.PWSC,
                user.NOME, user.LANG, user.EMAI, user.TELE, user.FAXN, user.UFFI, user.RIF1, user.RIF2, user.TELE2, user.ADR_ID);
        }

        public void DeleteToken(string token)
        {
            entities.DeleteToken(token);
        }

        /// <summary>
        /// Update user password
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="password">new password</param>
        public void UpdateUserPassword(string username, string password)
        {
            entities.f_UpdateAllFieldsFromCO01UT_ByKeyFields(null, username, null, password, null, null,
                null, null, null, null, null, null, null, null, null, null);
        }

        public List<db_CO_TOKEN> GetTokenByUsername(string username)
        {
            return entities.f_GetAllFieldsFromCO_TOKEN_BySomeEqualFields(null, null, null, null, username).ToList();
        }

        public db_CO01UT GetUserByEmail(string email)
        {
            var user = entities.f_GetAllFieldsFromCO01UT_BySomeEqualFields(null, null, null, null,
                null, null, null, null, email, null, null, null, null, null, null, null).FirstOrDefault();
            if (user != null)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Update user email
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="email">user email</param>
        public void UpdateUserEmail(string username, string email)
        {
            entities.f_UpdateAllFieldsFromCO01UT_ByKeyFields(null, username, null, null, null, null,
                null, null, email, null, null, null, null, null, null, null);
        }

        public void InsertToken(string token, DateTime insertDate, DateTime expirationDate, string username)
        {
            entities.f_InsertIntoCO_TOKEN(token, insertDate, insertDate, expirationDate, username);
        }

        public void RefreshToken(string token, DateTime lastUsageDate, DateTime expirationDate)
        {
            entities.f_UpdateAllFieldsFromCO_TOKEN_ByKeyFields(token, null, lastUsageDate, expirationDate, null);
        }

        #region Transport Options

        public List<db_ReqGoodTransportOptions> GetReqGoodTransportOptionsByTransportId(Guid transportId)
        {
            return entities.f_GetAllFieldsFromTransportOptions_BySomeEqualFields(transportId, null, null).ToList();
        }

        public void InsertReqGoodTransferOption(ReqGoodTransportOptions reqGoodTransferOptionItem)
        {
            entities.f_InsertIntoTransportOptions(reqGoodTransferOptionItem.TransportId, reqGoodTransferOptionItem.OptKey, reqGoodTransferOptionItem.OptValue);
        }

        #endregion

        #region Addresses

        public void InsertAddress(AddressModel adr)
        {
            entities.f_InsertIntoAddresses(adr.AddressID,
                adr.Type,
                adr.County,
                adr.Country,
                adr.District,
                adr.HouseName,
                adr.CreationDate,
                adr.HouseNumber,
                adr.PostCode,
                adr.Street1,
                adr.Street2,
                adr.Town);
        }

        #endregion

        #region Transfer Good

        public void InsertReqGoodTransfer(db_ReqGoodTransfer rgtItem)
        {
            entities.f_InsertIntoReqGoodTransfer(rgtItem.Id, rgtItem.AddressFrom, rgtItem.AddreessDest,
                rgtItem.DateTransportFixed, rgtItem.DateTransportType, rgtItem.DateTransportInfo, rgtItem.RequestState);
        }

        #endregion
    }
}
