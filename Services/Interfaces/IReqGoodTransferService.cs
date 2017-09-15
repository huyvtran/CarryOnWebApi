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
        List<ReqGoodTransferModel> GetReqGoodTransfer(Guid? reqId, Guid? userId);

        BaseResultModel InsertReqGoodTransfer(ReqGoodTransferModel rqtModel, UserModel user); 
        BaseResultModel UpdateReqGoodTransfer(ReqGoodTransferModel rqtModel, UserModel user);
        BaseResultModel DeleteReqGoodTransfer(Guid rgtId, UserModel user);

        
    }
}
