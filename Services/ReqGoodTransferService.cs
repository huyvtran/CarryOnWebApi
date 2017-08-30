using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;
using Services.Interfaces;
using Entities.enums;

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

        public List<ReqGoodTransferModel> GetReqGoodTransfer(Guid? reqId)
        {
            logger.Log(() => GetReqGoodTransfer(reqId));
            var retList = new List<ReqGoodTransferModel>();

            /* Get items from db */
            var db_ReqGoodTransfer = _dbManager.GetReqGoodTransfer_ByKeySomeEqualFields(reqId, null, null, null
                , null, null, null);

            /* Convert them to model */
            foreach (var dbItem in db_ReqGoodTransfer)
            {
                retList.Add(Mapper.ReqGoodTransferMapper.ReqGoodTransfer_DbToModel(dbItem));
            }

            /* Foreach item, get transport options */
            foreach (var retItem in retList)
            {
                retItem.ReqGoodTransportOpt = new List<ReqGoodTransportOptions>();
                var transportGoodOpt = _dbManager.GetReqGoodTransportOptionsByTransportId(retItem.Id);
                retItem.ReqGoodTransportOpt.AddRange(transportGoodOpt.Select(x => Mapper.ReqGoodTransferMapper.ReqGoodTransferOption_DbToModel(x)).ToList());
            }

            return retList;
        }

        public BaseResultModel InsertReqGoodTransfer(ReqGoodTransferModel rqtModel, UserModel user)
        {
            logger.Log(() => InsertReqGoodTransfer(rqtModel, user));
            var resultModel = new BaseResultModel() { OperationResult = true };

            try
            {
                //check if username is already registerd
                var existingUser = _dbManager.GetUserByUsername(user.UTEN);
                if (existingUser != null)
                {
                    resultModel.OperationResult = false;
                    resultModel.ResultMessage = ErrorsEnum.USERNAME_ALREADY_PRESENT;
                    return resultModel;
                }

                /* Add addresses from */
                var addressFrom = new AddressModel
                {
                    AddressID = new Guid(),
                    Type = rqtModel.FromType,
                    County = rqtModel.FromCounty,
                    Country = rqtModel.FromCountry,
                    District = rqtModel.FromDistrict,
                    HouseName = rqtModel.FromHouseName,
                    CreationDate = rqtModel.FromCreationDate,
                    HouseNumber = rqtModel.FromHouseNumber,
                    PostCode = rqtModel.FromPostCode,
                    Street1 = rqtModel.FromStreet1,
                    Street2 = rqtModel.FromStreet2,
                    Town = rqtModel.FromTown
                };

                _dbManager.InsertAddress(addressFrom);

                /* Add addresses destination */
                var addressDest = new AddressModel
                {
                    AddressID = new Guid(),
                    Type = rqtModel.DestType,
                    County = rqtModel.DestCounty,
                    Country = rqtModel.DestCountry,
                    District = rqtModel.DestDistrict,
                    HouseName = rqtModel.DestHouseName,
                    CreationDate = rqtModel.DestCreationDate,
                    HouseNumber = rqtModel.DestHouseNumber,
                    PostCode = rqtModel.DestPostCode,
                    Street1 = rqtModel.DestStreet1,
                    Street2 = rqtModel.DestStreet2,
                    Town = rqtModel.DestTown
                };
                _dbManager.InsertAddress(addressDest);

                /* Add ReqGoodTransfer item */
                var db_ReqGoodTransferModel = Mapper.ReqGoodTransferMapper.ReqGoodTransfer_ModelToDb(rqtModel);
                _dbManager.InsertReqGoodTransfer(db_ReqGoodTransferModel);
                
                /* Add ReqGoodTransfer options items */
                foreach (var optItem in rqtModel.ReqGoodTransportOpt)
                {
                    _dbManager.InsertReqGoodTransferOption(optItem);
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
    }
}
