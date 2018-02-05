using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IReqGoodTransferService
    {
        List<ReqGoodTransferModel> GetReqGoodTransferList(SearchRtFilter filterparams);
        ReqGoodTransferModel GetReqGoodTransferDetails(Guid? reqId);
        List<ReqGoodTransferModel> MyGetReqGoodTransferList(Guid? userId);

        BaseResultModel InsertReqGoodTransfer(ReqGoodTransferModel rqtModel, UserModel user); 
        BaseResultModel UpdateReqGoodTransfer(ReqGoodTransferModel rqtModel, UserModel user);
        BaseResultModel DeleteReqGoodTransfer(Guid rgtId, UserModel user);

        Dictionary<string, string> GetOptionsList(Guid? reqId);
    }
}
