using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Helper
{
    public static class MockHelper
    {
        public static List<db_ReqGoodTransferWithAddresses> getRqgtList()
        {
            var db_ReqGoodTransferList = new List<db_ReqGoodTransferWithAddresses> {
                new db_ReqGoodTransferWithAddresses
                {
                    AddreessDest = new Guid("d56c8abe-d3f7-44bd-8087-1f2c8fde36c1"),
                    AddressFrom = new Guid("46d26fb9-6643-4e97-a10d-8f8e0a51ad3c"),
                    DateTransportFixed = DateTime.Today,
                    DateTransportInfo = "Prima possibile",
                    DateTransportType = 1,
                    dest_formatted_address = "Via Giadi 43, Budrio (BO)",
                    dest_location_type = "",
                    dest_lat = "4,459",
                    dest_lng = "15,7854",
                    from_formatted_address = "Via Gaudi 2, Milano (MI)",
                    from_location_type = "15,784",
                    from_lat = "25,4578",
                    from_lng = "",
                    user_formatted_address = "Via Franceschi 8, Carrara (CR)",
                    user_location_type = "",
                    user_lat = "8,7452",
                    user_lng = "12,4575",
                    Id = Guid.NewGuid(),
                    RequestState = 0,
                    UserEmail = "luca.liguori@yahoo.it",
                    UserLang = null,
                    UserName = "Luca Liguori",
                    UserTEL2 = null,
                    UserTELE = "3325784589",
                    VolRequired = "10"
                }
            };

            return db_ReqGoodTransferList;
        }

        public static List<db_TransportAvWithAddress> getTransportAvList()
        {
            var rqgtItem = new db_TransportAvWithAddress
            {
                AddreessDest = new Guid("d56c8abe-d3f7-44bd-8087-1f2c8fde36c1"),
                AddressFrom = new Guid("46d26fb9-6643-4e97-a10d-8f8e0a51ad3c"),
                DateTransportFixed = null,
                DateTransportInfo = "Prima possibile",
                DateTransportType = 1,
                dest_formatted_address = "Via Giadi 43, Budrio (BO)",
                dest_location_type = "",
                dest_lat = "4,459",
                dest_lng = "15,7854",
                from_formatted_address = "Via Gaudi 2, Milano (MI)",
                from_location_type = "15,784",
                from_lat = "25,4578",
                from_lng = "5,877",
                user_formatted_address = "Via Franceschi 8, Carrara (CR)",
                user_location_type = "",
                user_lat = "8,7452",
                user_lng = "12,4575",
                Id = Guid.NewGuid(),
                RequestState = 0,
                UserEmail = "luca.liguori@yahoo.it",
                UserLang = null,
                UserName = "Luca Liguori",
                UserTEL2 = null,
                UserTELE = "3325784589",
                VolAvailable = "200"
            };

            /* create list to return */
            var db_ReqGoodTransferList = new List<db_TransportAvWithAddress> { rqgtItem };

            return db_ReqGoodTransferList;
        }

        public static object getRqgtOptions()
        {
            throw new NotImplementedException();
        }
    }
}
