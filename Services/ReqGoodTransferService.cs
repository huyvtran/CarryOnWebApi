using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;
using Services.Interfaces;

namespace Services
{
    public class ReqGoodTransferService : IReqGoodTransferService
    {
        public IDalManager _dbManager;

        public ReqGoodTransferService(IDalManager dbManager)
        {
            _dbManager = dbManager;
        }

        public List<ReqGoodTransferModel> GetReqGoodTransfer(Guid? reqId)
        {
            /* Get items from db */
            var db_ReqGoodTransfer = _dbManager.GetReqGoodTransfer_ByKeySomeEqualFields(reqId, null, null, null
                , null, null, null);

            /* Convert them to model */
            var retList = new List<ReqGoodTransferModel>();
            foreach (var dbItem in db_ReqGoodTransfer)
            {
                retList.Add(Mapper.ReqGoodTransferMapper.ReqGoodTransfer_DbToModel(dbItem));
            }
            return retList;
        }
    }
}
