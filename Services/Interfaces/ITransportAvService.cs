using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ITransportAvService
    {
        List<TransportAvModel> GetTransportAv(SearchRtFilter filterparams);
        TransportAvModel GetTrAvDetails(Guid? reqId);
        List<TransportAvModel> MyGetTransportAv(Guid? userId);
        

        BaseResultModel InsertTransportAv(TransportAvModel rqtModel, UserModel user); 
        BaseResultModel UpdateTransportAv(TransportAvModel rqtModel, UserModel user);
        BaseResultModel DeleteTransportAv(Guid rgtId, UserModel user);

        
    }
}
