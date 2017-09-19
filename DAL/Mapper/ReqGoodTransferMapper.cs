using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mapper
{
    public static class ReqGoodTransferMapper
    {
        private static AutoMapper.IMapper reqGoodTransfer_DbToModel;
        private static AutoMapper.IMapper reqGoodTransfer_ModelToDb;
        private static AutoMapper.IMapper reqGoodTransferOption_DbToModel;

        static ReqGoodTransferMapper()
        {
            /* reqGoodTransfer_DbToModel */
            var config_reqGoodTransfer_DbToModel = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<db_ReqGoodTransferWithAddresses, ReqGoodTransferModel>());
            reqGoodTransfer_DbToModel = config_reqGoodTransfer_DbToModel.CreateMapper();
            /* reqGoodTransfer_ModelToDb */
            var config_reqGoodTransfer_ModelToDb = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<ReqGoodTransferModel, db_ReqGoodTransferWithAddresses>());
            reqGoodTransfer_ModelToDb = config_reqGoodTransfer_ModelToDb.CreateMapper();

            /* reqGoodTransferOption_DbToModel */
            var config_reqGoodTransferOption_DbToModel = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<db_ReqGoodTransportOptions, ReqGoodTransportOptions>());
            reqGoodTransferOption_DbToModel = config_reqGoodTransferOption_DbToModel.CreateMapper();
        }

        public static ReqGoodTransferModel ReqGoodTransfer_DbToModel(db_ReqGoodTransferWithAddresses db_rqtItem)
        {
            ReqGoodTransferModel retModel = reqGoodTransfer_DbToModel.Map<ReqGoodTransferModel>(db_rqtItem);
            /* now fill all addresses */
            GeoCodeMapper.fillModelAddressesFromDb(retModel, db_rqtItem);
            return retModel;
        }

        public static db_ReqGoodTransferWithAddresses ReqGoodTransfer_ModelToDb(ReqGoodTransferModel model)
        {
            db_ReqGoodTransferWithAddresses db_item = reqGoodTransfer_ModelToDb.Map<db_ReqGoodTransferWithAddresses>(model);
            /* now fill all addresses */
            GeoCodeMapper.fillDbFieldsAddressesFromModel(db_item, model);
            return db_item;
        }

        public static ReqGoodTransportOptions ReqGoodTransferOption_DbToModel(db_ReqGoodTransportOptions db_optionItem)
        {
            return reqGoodTransferOption_DbToModel.Map<ReqGoodTransportOptions>(db_optionItem);
        }
        
    }
}
