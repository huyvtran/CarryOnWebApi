using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mapper
{
    public static class ReqGoodTransferMapper
    {
        private static AutoMapper.IMapper reqGoodTransfer_DbToModel;

        static ReqGoodTransferMapper()
        {
            var config = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<db_ReqGoodTransferWithAddresses, ReqGoodTransferModel>());
            reqGoodTransfer_DbToModel = config.CreateMapper();
        }

        public static ReqGoodTransferModel ReqGoodTransfer_DbToModel(db_ReqGoodTransferWithAddresses db_rqtItem)
        {            
            return reqGoodTransfer_DbToModel.Map<ReqGoodTransferModel>(db_rqtItem);
        }
    }
}
