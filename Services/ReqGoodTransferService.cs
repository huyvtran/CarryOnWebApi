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
    public class ReqGoodTransferService : IReqGoodTransferService
    {
        public IDalManager _dbManager;
        private ILogService logger;

        public ReqGoodTransferService(IDalManager dbManager, ILogService logger)
        {
            _dbManager = dbManager;
            this.logger = logger;
        }

        public List<ReqGoodTransferModel> GetReqGoodTransfer(Guid? reqId, Guid? userId)
        {
            logger.Log(() => GetReqGoodTransfer(reqId, userId));
            var retList = new List<ReqGoodTransferModel>();

            /* Get items from db */
            //var db_ReqGoodTransfer = _dbManager.GetReqGoodTransfer_ByKeyFields(reqId);
            var db_ReqGoodTransfer = _dbManager.GetReqGoodTransfer_ByKeySomeEqualFields(reqId, null, null, null, null
                , null, null, userId, null);

            /* Convert them to model */
            foreach (var dbItem in db_ReqGoodTransfer)
            {
                retList.Add(ReqGoodTransferMapper.ReqGoodTransfer_DbToModel(dbItem));
            }

            return retList;
        }

        public List<ReqGoodTransferModel> GetReqGoodTransferList(SearchRtFilter filterparams)
        {
            logger.Log(() => GetReqGoodTransferList(filterparams));
            var retList = new List<ReqGoodTransferModel>();

            /* Get items from db */
            //var db_ReqGoodTransfer = _dbManager.GetReqGoodTransfer_ByKeyFields(reqId);
            var db_ReqGoodTransfer = _dbManager.GetReqGoodTransfer_ByKeySomeEqualFields(null, null, null, null, null
                , null, null, null, null);

            /* Convert them to model */
            foreach (var dbItem in db_ReqGoodTransfer)
            {
                retList.Add(ReqGoodTransferMapper.ReqGoodTransfer_DbToModel(dbItem));
            }

            return retList;
        }

        public ReqGoodTransferModel GetReqGoodTransferDetails(Guid? reqId)
        {
            logger.Log(() => GetReqGoodTransferDetails(reqId));

            /* Get items from db */
            var db_ReqGoodTransfer = _dbManager.GetReqGoodTransfer_ByKeyFields(reqId).FirstOrDefault();
            //var db_ReqGoodTransfer = _dbManager.GetReqGoodTransfer_ByKeySomeEqualFields(reqId, null, null, null, null
            //     , null, null, null, null).FirstOrDefault();

            return (db_ReqGoodTransfer != null) ? null : ReqGoodTransferMapper.ReqGoodTransfer_DbToModel(db_ReqGoodTransfer);
        }

        public BaseResultModel InsertReqGoodTransfer(ReqGoodTransferModel rqtModel, UserModel user)
        {
            logger.Log(() => InsertReqGoodTransfer(rqtModel, user));
            var resultModel = new BaseResultModel() { OperationResult = true };

            try
            {
                //check if username is existing
                var existingUser = _dbManager.GetUserByUsername(rqtModel.UserEmail);
                if (existingUser == null)
                {
                    resultModel.OperationResult = false;
                    resultModel.ResultMessage = ErrorsEnum.USER_NOT_PRESENT;
                    return resultModel;
                }

                /* Add addresses from */
                rqtModel.fromAddress.Id = Guid.NewGuid();
                rqtModel.AddressFrom = rqtModel.fromAddress.Id;
                rqtModel.destAddress.Id = Guid.NewGuid();
                rqtModel.AddreessDest = rqtModel.destAddress.Id;
                rqtModel.Id = Guid.NewGuid();

                /* Add addresses destination */
                var addressFrom = GeoCodeMapper.GeoCodeAddress_ModelToDb(rqtModel.fromAddress);
                _dbManager.InsertAddress(addressFrom);

                /* Add addresses destination */
                var addressDest = GeoCodeMapper.GeoCodeAddress_ModelToDb(rqtModel.destAddress);
                _dbManager.InsertAddress(addressDest);

                /* Add ReqGoodTransfer item */
                var db_ReqGoodTransferModel = ReqGoodTransferMapper.ReqGoodTransfer_ModelToDb(rqtModel);
                ///* Add guid */
                //db_ReqGoodTransferModel.Id = reqGoodTransportId;
                //db_ReqGoodTransferModel.AddressFrom = addressFromId;
                //db_ReqGoodTransferModel.AddreessDest = addressDestId;
                /* Add to db */
                _dbManager.InsertReqGoodTransfer(db_ReqGoodTransferModel);

                /* Add ReqGoodTransfer options items */
                if (rqtModel.ReqGoodTransportOpt != null)
                {
                    foreach (var optItem in rqtModel.ReqGoodTransportOpt)
                    {
                        ReqGoodTransportOptions optToAdd = new ReqGoodTransportOptions
                        {
                            TransportId = rqtModel.Id,
                            OptKey = optItem.Key,
                            OptValue = optItem.Value
                        };
                        _dbManager.InsertReqGoodTransferOption(optToAdd);
                    }
                }

                return resultModel;
            }
            catch (Exception e)
            {
                logger.Log(() => InsertReqGoodTransfer(rqtModel, user), e);
                resultModel.OperationResult = false;
                resultModel.ResultMessage = ErrorsEnum.GENERIC_ERROR;
            }
            return resultModel;
        }

        public BaseResultModel UpdateReqGoodTransfer(ReqGoodTransferModel rqtModel, UserModel user)
        {
            logger.Log(() => UpdateReqGoodTransfer(rqtModel, user));
            var resultModel = new BaseResultModel() { OperationResult = true };

            try
            {
                /* Check if item exists on db for that user */
                var existing_ReqGoodTransfer = _dbManager.GetReqGoodTransfer_ByKeySomeEqualFields(rqtModel.Id, null, null, null
                    , null, null, null, user.UserId, null).FirstOrDefault();
                if (existing_ReqGoodTransfer == null)
                {
                    resultModel.OperationResult = false;
                    resultModel.ResultMessage = ErrorsEnum.USERNAME_ALREADY_PRESENT;
                    return resultModel;
                }

                /* Add addresses from */
                var addressFrom = GeoCodeMapper.GeoCodeAddress_ModelToDb(rqtModel.fromAddress);
                _dbManager.UpdateAddress(addressFrom);

                /* Add addresses destination */
                var addressDest = GeoCodeMapper.GeoCodeAddress_ModelToDb(rqtModel.destAddress);
                _dbManager.UpdateAddress(addressDest);

                /* Add ReqGoodTransfer item */
                var db_ReqGoodTransferModel = ReqGoodTransferMapper.ReqGoodTransfer_ModelToDb(rqtModel);

                _dbManager.UpdateReqGoodTransfer(db_ReqGoodTransferModel);

                /* Add ReqGoodTransfer options items */
                foreach (var optItem in rqtModel.ReqGoodTransportOpt)
                {
                    ReqGoodTransportOptions optToUpd = new ReqGoodTransportOptions
                    {
                        TransportId = rqtModel.Id,
                        OptKey = optItem.Key,
                        OptValue = optItem.Value
                    };
                    _dbManager.UpdateReqGoodTransferOption(optToUpd);
                }

                return resultModel;
            }
            catch (Exception e)
            {
                logger.Log(() => UpdateReqGoodTransfer(rqtModel, user), e);
                resultModel.OperationResult = false;
                resultModel.ResultMessage = ErrorsEnum.GENERIC_ERROR;
            }
            return resultModel;
        }

        public BaseResultModel DeleteReqGoodTransfer(Guid rgtId, UserModel user)
        {
            logger.Log(() => DeleteReqGoodTransfer(rgtId, user));
            var resultModel = new BaseResultModel() { OperationResult = true };

            try
            {
                /* Check if item exists on db for the current user*/
                var existing_ReqGoodTransfer = _dbManager.GetReqGoodTransfer_ByKeySomeEqualFields(rgtId, null, null, null
                    , null, null, null, user.UserId, null).FirstOrDefault();
                if (existing_ReqGoodTransfer == null)
                {
                    resultModel.OperationResult = false;
                    resultModel.ResultMessage = ErrorsEnum.USERNAME_ALREADY_PRESENT;
                    return resultModel;
                }

                /* Delete addresses from */
                _dbManager.DeleteAddress((Guid)existing_ReqGoodTransfer.AddressFrom);
                /* Delete addresses dest */
                _dbManager.DeleteAddress((Guid)existing_ReqGoodTransfer.AddreessDest);
                /* Delete ReqGoodTransfer options items */
                _dbManager.DeleteReqGoodTransferOption(new ReqGoodTransportOptions
                {
                    TransportId = existing_ReqGoodTransfer.Id,
                    OptKey = null,
                    OptValue = null
                });
                /* Delete ReqGoodTransfer item */
                _dbManager.DeleteReqGoodTransfer(existing_ReqGoodTransfer.Id);
                return resultModel;
            }
            catch (Exception e)
            {
                logger.Log(() => DeleteReqGoodTransfer(rgtId, user), e);
                resultModel.OperationResult = false;
                resultModel.ResultMessage = ErrorsEnum.GENERIC_ERROR;
            }
            return resultModel;
        }

        public Dictionary<string, string> GetOptionsList(Guid? reqId)
        {
            logger.Log(() => GetOptionsList(reqId));
            var retList = new Dictionary<string, string>();

            /* Foreach item, get transport options */
            retList = new Dictionary<string, string>();
            var transportGoodOpt = _dbManager.GetReqGoodTransportOptionsByTransportId((Guid)reqId);
            transportGoodOpt.ForEach(x => retList.Add(x.OptKey, x.OptValue));
            return retList;
        }
    }
}
