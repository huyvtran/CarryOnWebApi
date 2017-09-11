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
        List<TransportAvModel> GetTransportAv(Guid? reqId);

        BaseResultModel InsertTransportAv(TransportAvModel rqtModel, UserModel user); 
        BaseResultModel UpdateTransportAv(TransportAvModel rqtModel, UserModel user);
        BaseResultModel DeleteTransportAv(Guid rgtId, UserModel user);

        
    }
}
