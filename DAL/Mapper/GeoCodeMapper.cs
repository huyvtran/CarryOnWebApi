using DAL;
using Entities;
using Entities.GMaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mapper
{
    public static class GeoCodeMapper
    {

        public static GeoCodeResult GeoCodeAddress_DbToModel(db_GeoCodeAddress db_geocodeItem)
        {
            var addressModel = new GeoCodeResult() { geometry = new Geometry { location = new Location() } };
            if (db_geocodeItem != null)
            {
                addressModel.Id = db_geocodeItem.Id;
                addressModel.formatted_address = db_geocodeItem.formatted_address;
                addressModel.geometry.location.lat = db_geocodeItem.lat;
                addressModel.geometry.location.lng = db_geocodeItem.lng;
            }
            return addressModel;
        }

        public static db_GeoCodeAddress GeoCodeAddress_ModelToDb(GeoCodeResult addressModel)
        {
            var db_geocodeItem = new db_GeoCodeAddress();
            if (db_geocodeItem != null)
            {
                db_geocodeItem.Id = addressModel.Id == null ? Guid.NewGuid() : (Guid)addressModel.Id;
                db_geocodeItem.formatted_address = addressModel.formatted_address;
                if (addressModel.geometry != null && addressModel.geometry.location != null)
                {
                    db_geocodeItem.lat = addressModel.geometry.location.lat;
                    db_geocodeItem.lng = addressModel.geometry.location.lng;
                }
            }
            return db_geocodeItem;
        }

        public static GeoCodeResult GeoCodeAddress_DbFieldsToModel(Guid _id, string _formatted_address,
            string _lat, string _lng)
        {
            var addressModel = new GeoCodeResult() { geometry = new Geometry { location = new Location() } };
            addressModel.Id = _id;
            addressModel.formatted_address = _formatted_address;
            addressModel.geometry.location.lat = _lat;
            addressModel.geometry.location.lng = _lng;

            return addressModel;
        }
        
        public static GeoCodeResult GeoCodeAddress_FieldsToModel(Guid _id, string _formatted_address,
            string _lat, string _lng)
        {
            var addressModel = new GeoCodeResult() { geometry = new Geometry { location = new Location() } };
            addressModel.Id = _id;
            addressModel.formatted_address = _formatted_address;
            addressModel.geometry.location.lat = _lat;
            addressModel.geometry.location.lng = _lng;

            return addressModel;
        }


        public static void fillModelAddressesFromDb(ReqGoodTransferModel retModel, db_ReqGoodTransferWithAddresses db_rqtItem)
        {
            /* Address FROM */
            retModel.fromAddress = GeoCodeAddress_FieldsToModel(
                (Guid)db_rqtItem.AddressFrom,
                db_rqtItem.from_formatted_address?.Trim(),
                db_rqtItem.from_lat?.Trim(),
                db_rqtItem.from_lng?.Trim());

            /* Address DEST */
            retModel.destAddress = GeoCodeAddress_FieldsToModel(
                (Guid)db_rqtItem.AddreessDest,
                db_rqtItem.dest_formatted_address?.Trim(),
                db_rqtItem.dest_lat?.Trim(),
                db_rqtItem.dest_lng?.Trim());

            /* Address USER */
            retModel.userAddress = GeoCodeAddress_FieldsToModel(
                new Guid(),
                db_rqtItem.user_formatted_address?.Trim(),
                db_rqtItem.user_lat?.Trim(),
                db_rqtItem.user_lng?.Trim());
        }

        public static void fillModelAddressesFromDb(TransportAvModel retModel, db_TransportAvWithAddress db_trAvItem)
        {
            /* Address FROM */
            retModel.fromAddress = GeoCodeAddress_FieldsToModel(
                (Guid)db_trAvItem.AddressFrom,
                db_trAvItem.from_formatted_address,
                db_trAvItem.from_lat,
                db_trAvItem.from_lng);

            /* Address DEST */
            retModel.destAddress = GeoCodeAddress_FieldsToModel(
                (Guid)db_trAvItem.AddreessDest,
                db_trAvItem.dest_formatted_address,
                db_trAvItem.dest_lat,
                db_trAvItem.dest_lng);

            /* Address USER */
            retModel.userAddress = GeoCodeAddress_FieldsToModel(
                new Guid(),
                db_trAvItem.user_formatted_address,
                db_trAvItem.user_lat,
                db_trAvItem.user_lng);
        }

        // Change here
        public static void fillDbFieldsAddressesFromModel(db_ReqGoodTransferWithAddresses db_item, ReqGoodTransferModel model)
        {
            /* Address FROM */
            db_item.AddressFrom = model.AddressFrom;
            db_item.from_formatted_address = model.fromAddress?.formatted_address;
            db_item.from_lat = model.fromAddress?.geometry?.location?.lat;
            db_item.from_lng = model.fromAddress?.geometry?.location?.lng;
            db_item.from_location_type = model.fromAddress?.geometry?.location_type;

            /* Address DEST */
            db_item.AddreessDest = model.AddreessDest;
            db_item.dest_formatted_address = model.destAddress?.formatted_address;
            db_item.dest_lat = model.destAddress?.geometry?.location?.lat;
            db_item.dest_lng = model.destAddress?.geometry?.location?.lng;
            db_item.dest_location_type = model.destAddress?.geometry?.location_type;

            /* Address USER */
            //db_item.AddressUser = model.userAddress.Id;
            db_item.user_formatted_address = model.userAddress?.formatted_address;
            db_item.user_lat = model.userAddress?.geometry?.location?.lat;
            db_item.user_lng = model.userAddress?.geometry?.location?.lng;
            db_item.user_location_type = model.userAddress?.geometry?.location_type;
        }

        public static void fillDbFieldsAddressesFromModel(db_TransportAvWithAddress db_item, TransportAvModel model)
        {
            /* Address FROM */
            model.fromAddress = new GeoCodeResult
            {
                Id = db_item.AddressFrom,
                formatted_address = db_item.from_formatted_address,
                geometry = new Geometry
                {
                    location = new Location { lat = db_item.from_lat, lng = db_item.from_lng }
                }
            };

            /* Address DEST */
            model.destAddress = new GeoCodeResult
            {
                Id = db_item.AddreessDest,
                formatted_address = db_item.dest_formatted_address,
                geometry = new Geometry
                {
                    location = new Location { lat = db_item.dest_lat, lng = db_item.dest_lng }
                }
            };

            /* Address USER */
            model.userAddress = new GeoCodeResult
            {
                Id = new Guid(),
                formatted_address = db_item.user_formatted_address,
                geometry = new Geometry
                {
                    location = new Location { lat = db_item.user_lat, lng = db_item.user_lng }
                }
            };
        }
    }
}
