using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;
using Services.Interfaces;
using Entities.enums;
using DAL.Mapper;

namespace Services
{
    public class TransportAvService : ITransportAvService
    {
        public IDalManager _dbManager;
        private ILogService logger;

        public TransportAvService(IDalManager dbManager, ILogService logger)
        {
            _dbManager = dbManager;
            this.logger = logger;
        }

        public List<TransportAvModel> GetTransportAv(SearchRtFilter filterparams)
        {
            logger.Log(() => GetTransportAv(filterparams));
            var retList = new List<TransportAvModel>();

            /* Get items from db */
            //var db_TransportAv = _dbManager.GetTransportAv_ByKeySomeEqualFields(reqId, null, null, null, 
            //    null, null, null, userId, null);
            var db_TransportAv = _dbManager.GetTransportAv_ByKeySomeEqualFields(null, null, null, null,
                null, null, null, null, null);

            /* Convert them to model */
            foreach (var dbItem in db_TransportAv)
            {
                retList.Add(TransportAvMapper.TransportAv_DbToModel(dbItem));
            }

            ///* Foreach item, get transport options */
            //foreach (var retItem in retList)
            //{
            //    retItem.ReqGoodTransportOpt = new List<ReqGoodTransportOptions>();
            //    var transportGoodOpt = _dbManager.GetReqGoodTransportOptionsByTransportId(retItem.Id);
            //    retItem.ReqGoodTransportOpt.AddRange(transportGoodOpt.Select(x => TransportAvMapper.TransportAvOption_DbToModel(x)).ToList());
            //}

            return retList;
        }

        public List<TransportAvModel> MyGetTransportAv(Guid? userId)
        {
            logger.Log(() => MyGetTransportAv(userId));
            var retList = new List<TransportAvModel>();

            /* Get items from db */
            //var db_TransportAv = _dbManager.GetTransportAv_ByKeySomeEqualFields(reqId, null, null, null, 
            //    null, null, null, userId, null);
            var db_TransportAv = _dbManager.GetTransportAv_ByKeySomeEqualFields(null, null, null, null,
                null, null, null, userId, null);

            /* Convert them to model */
            foreach (var dbItem in db_TransportAv)
            {
                retList.Add(TransportAvMapper.TransportAv_DbToModel(dbItem));
            }

            ///* Foreach item, get transport options */
            //foreach (var retItem in retList)
            //{
            //    retItem.ReqGoodTransportOpt = new List<ReqGoodTransportOptions>();
            //    var transportGoodOpt = _dbManager.GetReqGoodTransportOptionsByTransportId(retItem.Id);
            //    retItem.ReqGoodTransportOpt.AddRange(transportGoodOpt.Select(x => TransportAvMapper.TransportAvOption_DbToModel(x)).ToList());
            //}

            return retList;
        }

        public TransportAvModel GetTrAvDetails(Guid? reqId)
        {
            logger.Log(() => GetTrAvDetails(reqId));

            /* Get items from db */
            var db_ReqGoodTransfer = _dbManager.GetTransportAv_ByKeyFields(reqId).FirstOrDefault();

            if (db_ReqGoodTransfer == null)
            {
                return null;
            }

            var retModel = TransportAvMapper.TransportAv_DbToModel(db_ReqGoodTransfer);

            // Get transfer options
            var options = _dbManager.GetReqGoodTransportOptionsByTransportId((Guid)reqId);
            retModel.ReqGoodTransportOpt = options.Select(x => ReqGoodTransferMapper.ReqGoodTransferOption_DbToModel(x)).ToList();

            return retModel;
        }

        public BaseResultModel InsertTransportAv(TransportAvModel travModel, UserModel user)
        {
            logger.Log(() => InsertTransportAv(travModel, user));
            var resultModel = new BaseResultModel() { OperationResult = true };

            try
            {
                //check if username exists
                var existingUser = _dbManager.GetUserByUsername(travModel.UserEmail);
                if (existingUser == null)
                {
                    resultModel.OperationResult = false;
                    resultModel.ResultMessage = ErrorsEnum.USER_NOT_PRESENT;
                    return resultModel;
                }

                /* Add addresses from */
                travModel.fromAddress.Id = Guid.NewGuid();
                travModel.AddressFrom = travModel.fromAddress.Id;
                travModel.destAddress.Id = Guid.NewGuid();
                travModel.AddreessDest = travModel.destAddress.Id;
                travModel.Id = Guid.NewGuid();

                /* Add addresses from */
                var addressFrom = GeoCodeMapper.GeoCodeAddress_ModelToDb(travModel.fromAddress);
                _dbManager.InsertAddress(addressFrom);

                /* Add addresses destination */
                var addressDest = GeoCodeMapper.GeoCodeAddress_ModelToDb(travModel.destAddress);
                _dbManager.InsertAddress(addressDest);

                /* Add TransportAv item */
                var db_TransportAvModel = TransportAvMapper.TransportAv_ModelToDb(travModel);
                /* Add guid */
                //db_TransportAvModel.Id = reqGoodTransportId;
                //db_TransportAvModel.AddressFrom = addressFromId;
                //db_TransportAvModel.AddreessDest = addressDestId;
                /* Add to db */
                _dbManager.InsertTransportAv(db_TransportAvModel);

                /* Add TransportAv options items */
                if (travModel.ReqGoodTransportOpt != null)
                {
                    foreach (var optItem in travModel.ReqGoodTransportOpt)
                    {
                        ReqGoodTransportOptions optToAdd = new ReqGoodTransportOptions
                        {
                            TransportId = travModel.Id,
                            OptKey = optItem.OptKey,
                            OptValue = optItem.OptValue
                        };
                        _dbManager.InsertReqGoodTransferOption(optToAdd);
                    }
                }
                return resultModel;
            }
            catch (Exception e)
            {
                logger.Log(() => InsertTransportAv(travModel, user), e);
                resultModel.OperationResult = false;
                resultModel.ResultMessage = ErrorsEnum.GENERIC_ERROR;
            }
            return resultModel;
        }

        public BaseResultModel UpdateTransportAv(TransportAvModel travModel, UserModel user)
        {
            logger.Log(() => UpdateTransportAv(travModel, user));
            var resultModel = new BaseResultModel() { OperationResult = true };

            try
            {
                /* Check if item exists on db for that user */
                var existing_TransportAv = _dbManager.GetTransportAv_ByKeySomeEqualFields(travModel.Id, null, null, null
                    , null, null, null, null, null).FirstOrDefault();
                if (existing_TransportAv == null)
                {
                    resultModel.OperationResult = false;
                    resultModel.ResultMessage = ErrorsEnum.ITEM_NOT_PRESENT;
                    return resultModel;
                }

                /* Add TransportAv item */
                var db_TransportAvModel = TransportAvMapper.TransportAv_ModelToDb(travModel);

                _dbManager.UpdateTransportAv(db_TransportAvModel);

                /* Add addresses from */
                var addressFrom = GeoCodeMapper.GeoCodeAddress_ModelToDb(travModel.fromAddress);
                _dbManager.UpdateAddress(addressFrom);

                /* Add addresses destination */
                var addressDest = GeoCodeMapper.GeoCodeAddress_ModelToDb(travModel.destAddress);
                _dbManager.UpdateAddress(addressDest);

                /* Add TransportAv options items */
                if (travModel.ReqGoodTransportOpt != null)
                {
                    /* Add ReqGoodTransfer options items */
                    foreach (var optItem in travModel.ReqGoodTransportOpt)
                    {
                        ReqGoodTransportOptions optToUpd = new ReqGoodTransportOptions
                        {
                            TransportId = travModel.Id,
                            OptKey = optItem.OptKey,
                            OptValue = optItem.OptValue
                        };
                        _dbManager.UpdateReqGoodTransferOption(optToUpd);
                    }
                }

                return resultModel;
            }
            catch (Exception e)
            {
                logger.Log(() => UpdateTransportAv(travModel, user), e);
                resultModel.OperationResult = false;
                resultModel.ResultMessage = ErrorsEnum.GENERIC_ERROR;
            }
            return resultModel;
        }

        public BaseResultModel DeleteTransportAv(Guid rgtId, UserModel user)
        {
            logger.Log(() => DeleteTransportAv(rgtId, user));
            var resultModel = new BaseResultModel() { OperationResult = true };

            try
            {
                /* Check if item exists on db for the current user*/
                var existing_TransportAv = _dbManager.GetTransportAv_ByKeySomeEqualFields(rgtId, null, null, null
                    , null, null, null, null, null).FirstOrDefault();
                if (existing_TransportAv == null)
                {
                    resultModel.OperationResult = false;
                    resultModel.ResultMessage = ErrorsEnum.USERNAME_ALREADY_PRESENT;
                    return resultModel;
                }

                /* Delete TransportAv item */
                _dbManager.DeleteTransportAv(existing_TransportAv.Id);
                /* Delete addresses from */
                _dbManager.DeleteAddress((Guid)existing_TransportAv.AddressFrom);
                /* Delete addresses dest */
                _dbManager.DeleteAddress((Guid)existing_TransportAv.AddreessDest);
                /* Delete TransportAv options items */
                _dbManager.DeleteReqGoodTransferOption(new ReqGoodTransportOptions {
                    TransportId = existing_TransportAv.Id,
                    OptKey = null,
                    OptValue = null
                });
                            
                return resultModel;
            }
            catch (Exception e)
            {
                logger.Log(() => DeleteTransportAv(rgtId, user), e);
                resultModel.OperationResult = false;
                resultModel.ResultMessage = ErrorsEnum.GENERIC_ERROR;
            }
            return resultModel;
        }
    }
}
