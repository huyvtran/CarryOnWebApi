using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mapper
{
    public static class TransportAvMapper
    {
        private static AutoMapper.IMapper transportAv_DbToModel;
        private static AutoMapper.IMapper transportAv_ModelToDb;
        private static AutoMapper.IMapper transportAvOption_DbToModel;

        static TransportAvMapper()
        {
            /* transportAv_DbToModel */
            var config_transportAv_DbToModel = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<db_TransportAvWithAddress, TransportAvModel>());
            transportAv_DbToModel = config_transportAv_DbToModel.CreateMapper();
            /* transportAv_ModelToDb */
            var config_transportAv_ModelToDb = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<TransportAvModel, db_TransportAvWithAddress>());
            transportAv_ModelToDb = config_transportAv_ModelToDb.CreateMapper();

            /* transportAvOption_DbToModel */
            var config_transportAvOption_DbToModel = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<db_TransportAvWithAddress, TransportAvModel>());
            transportAvOption_DbToModel = config_transportAvOption_DbToModel.CreateMapper();
        }

        public static TransportAvModel TransportAv_DbToModel(db_TransportAvWithAddress db_rqtItem)
        {
            TransportAvModel retModel = transportAv_DbToModel.Map<TransportAvModel>(db_rqtItem);
            /* now fill all addresses */
            GeoCodeMapper.fillModelAddressesFromDb(retModel, db_rqtItem);
            return retModel;
        }

        public static db_TransportAvWithAddress TransportAv_ModelToDb(TransportAvModel model)
        {
            db_TransportAvWithAddress db_item = transportAv_ModelToDb.Map<db_TransportAvWithAddress>(model);
            /* now fill all addresses */
            GeoCodeMapper.fillDbFieldsAddressesFromModel(db_item, model);
            return db_item;
        }

        public static ReqGoodTransportOptions TransportAvOption_DbToModel(db_ReqGoodTransportOptions db_optionItem)
        {
            return transportAvOption_DbToModel.Map<ReqGoodTransportOptions>(db_optionItem);
        }
        
    }
}
