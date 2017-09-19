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

        #region User

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
            entities.f_InsertIntoCO01UT(Guid.NewGuid(), user.UTEN, user.TIPU, user.PASS,
                user.PWGG, user.PWSC, user.NOME, user.LANG, user.EMAI,
                user.TELE, user.FAXN, user.UFFI, user.RIF1, user.RIF2, user.TELE2, null);
        }

        public void UpdateUser(db_CO01UT user)
        {
            entities.f_UpdateAllFieldsFromCO01UT_ByKeyFields(user.ID, user.UTEN, user.TIPU, user.PASS, user.PWGG, user.PWSC,
                user.NOME, user.LANG, user.EMAI, user.TELE, user.FAXN, user.UFFI, user.RIF1, user.RIF2, user.TELE2, user.ADR_ID);
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

        #endregion

        #region Token

        public void InsertToken(string token, DateTime insertDate, DateTime expirationDate, string username)
        {
            entities.f_InsertIntoCO_TOKEN(token, insertDate, insertDate, expirationDate, username);
        }

        public void RefreshToken(string token, DateTime lastUsageDate, DateTime expirationDate)
        {
            entities.f_UpdateAllFieldsFromCO_TOKEN_ByKeyFields(token, null, lastUsageDate, expirationDate, null);
        }

        public List<db_CO_TOKEN> GetTokenByUsername(string username)
        {
            return entities.f_GetAllFieldsFromCO_TOKEN_BySomeEqualFields(null, null, null, null, username).ToList();
        }

        public void DeleteToken(string token)
        {
            entities.DeleteToken(token);
        }

        #endregion

        #region GeoCode Addresses

        public void InsertAddress(db_GeoCodeAddress adr)
        {
            entities.f_InsertIntoGeoCodeAddress(adr.Id,
                adr.formatted_address,
                adr.location_type,
                adr.lat,
                adr.lng);
        }

        public void UpdateAddress(db_GeoCodeAddress adr)
        {
            entities.f_UpdateAllFieldsFromGeoCodeAddress_ByKeyFields(adr.Id,
                adr.formatted_address,
                adr.location_type,
                adr.lat,
                adr.lng);
        }

        public void DeleteAddress(Guid adrId)
        {
            entities.f_DeleteFromAddresses_ByKeyFields(adrId);
        }

        #endregion

        #region Transfer Good

        public List<db_ReqGoodTransferWithAddresses> GetReqGoodTransfer_ByKeyFields(Guid? reqId)
        {
            //return entities.GetAllReqGoodTransfer_ByKeyFields(reqId).ToList();
            return entities.f_GetAllFieldsFromReqGoodTransfer_ByKeyFields(reqId).ToList();
        }
        
        public List<db_ReqGoodTransferWithAddresses> GetReqGoodTransfer_ByKeySomeEqualFields(Nullable<System.Guid> id, Nullable<System.Guid> addressFrom, Nullable<System.Guid> addreessDest, Nullable<System.DateTime> dateTransportFixed, Nullable<int> dateTransportType, string dateTransportInfo, Nullable<int> requestState, Nullable<System.Guid> userId, string volRequired)
        {
            return entities.f_GetAllFieldsFromReqGoodTransfer_BySomeEqualFields(id, addressFrom, addreessDest,
                dateTransportFixed, dateTransportType, dateTransportInfo, requestState, userId, volRequired).ToList();
        }

        public void InsertReqGoodTransfer(db_ReqGoodTransferWithAddresses rgtItem)
        {
            entities.f_InsertIntoReqGoodTransfer(rgtItem.Id, rgtItem.AddressFrom, rgtItem.AddreessDest,
                rgtItem.DateTransportFixed, rgtItem.DateTransportType, rgtItem.DateTransportInfo, rgtItem.RequestState, rgtItem.UserId, rgtItem.VolRequired);
        }

        public void UpdateReqGoodTransfer(db_ReqGoodTransferWithAddresses rgtItem)
        {
            entities.f_UpdateAllFieldsFromReqGoodTransfer_ByKeyFields(rgtItem.Id, rgtItem.AddressFrom, rgtItem.AddreessDest,
                rgtItem.DateTransportFixed, rgtItem.DateTransportType, rgtItem.DateTransportInfo, rgtItem.RequestState, rgtItem.UserId, rgtItem.VolRequired);
        }

        public void DeleteReqGoodTransfer(Guid rgtId)
        {
            entities.f_DeleteFromReqGoodTransfer_ByKeyFields(rgtId);
        }

        #endregion

        #region Transport availability

        public List<db_TransportAvWithAddress> GetTransportAv_ByKeyFields(Guid? transportId)
        {
            return entities.f_GetAllFieldsFromTransportAv_ByKeyFields(transportId).ToList();
        }

        public List<db_TransportAvWithAddress> GetTransportAv_ByKeySomeEqualFields(Nullable<System.Guid> id, Nullable<System.Guid> addressFrom, Nullable<System.Guid> addreessDest, Nullable<System.DateTime> dateTransportFixed, Nullable<int> dateTransportType, string dateTransportInfo, Nullable<int> requestState, Nullable<System.Guid> userId, string volAvailable)
        {
            return entities.f_GetAllFieldsFromTransportAv_BySomeEqualFields(id, addressFrom, addreessDest,
                dateTransportFixed, dateTransportType, dateTransportInfo, requestState, userId, volAvailable).ToList();
        }

        public void InsertTransportAv(db_TransportAvWithAddress transportAvItem)
        {
            entities.f_InsertIntoTransportAv(transportAvItem.Id, transportAvItem.AddressFrom, transportAvItem.AddreessDest,
                transportAvItem.DateTransportFixed, transportAvItem.DateTransportType, transportAvItem.DateTransportInfo, transportAvItem.RequestState, transportAvItem.UserId, transportAvItem.VolAvailable);
        }

        public void UpdateTransportAv(db_TransportAvWithAddress transportAvItem)
        {
            entities.f_UpdateAllFieldsFromTransportAv_ByKeyFields(transportAvItem.Id, transportAvItem.AddressFrom, transportAvItem.AddreessDest,
                transportAvItem.DateTransportFixed, transportAvItem.DateTransportType, transportAvItem.DateTransportInfo, transportAvItem.RequestState, transportAvItem.UserId, transportAvItem.VolAvailable);
        }

        public void DeleteTransportAv(Guid rgtId)
        {
            entities.f_DeleteFromTransportAv_ByKeyFields(rgtId);
        }

        #endregion

        #region Transport Options

        public List<db_ReqGoodTransportOptions> GetReqGoodTransportOptionsByTransportId(Guid transportId)
        {
            return entities.f_GetAllFieldsFromTransportOptions_BySomeEqualFields(transportId, null, null).ToList();
        }

        public void InsertReqGoodTransferOption(ReqGoodTransportOptions reqGoodTransferOptionItem)
        {
            entities.f_InsertIntoTransportOptions(reqGoodTransferOptionItem.TransportId, reqGoodTransferOptionItem.OptKey, reqGoodTransferOptionItem.OptValue);
        }

        public void UpdateReqGoodTransferOption(ReqGoodTransportOptions reqGoodTransferOptionItem)
        {
            entities.f_UpdateAllFieldsFromTransportOptions_ByKeyFields(reqGoodTransferOptionItem.TransportId, reqGoodTransferOptionItem.OptKey, reqGoodTransferOptionItem.OptValue);
        }

        public void DeleteReqGoodTransferOption(ReqGoodTransportOptions reqGoodTransferOptionItem)
        {
            entities.f_DeleteFromTransportOptions_ByKeyFields(reqGoodTransferOptionItem.TransportId, reqGoodTransferOptionItem.OptKey);
        }

        #endregion
        
    }
}
