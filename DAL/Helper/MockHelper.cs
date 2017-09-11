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
                    DateTransportFixed = null,
                    DateTransportInfo = "Prima possibile",
                    DateTransportType = 1,
                    DestCountry = "Italia",
                    DestCounty = "Pesaro",
                    DestCreationDate = null,
                    DestDistrict = "Pesaro",
                    DestHouseName = "",
                    DestHouseNumber = "43",
                    DestPostCode = "43105",
                    DestStreet1 = "Via Giadi",
                    DestStreet2 = "testTo",
                    DestTown = "Budrio",
                    DestType = 0,
                    FromCountry = "Italia",
                    FromCounty = "Milano",
                    FromCreationDate = null,
                    FromDistrict = "Milano",
                    FromHouseName = "",
                    FromHouseNumber = "2",
                    FromPostCode = "20103",
                    FromStreet1 = "Via Gaudi",
                    FromStreet2 = "",
                    FromTown = "Monza",
                    FromType = 0,
                    Id = new Guid("d67cf6fb-7469-448c-9d4e-00ad01efb8da"),
                    RequestState = 0,
                    UserCountry = "TestUser",
                    UserCounty = "TestUser",
                    UserCreationDate = null,
                    UserDistrict = "TestUser",
                    UserEmail = "mario.fornaroli@yahoo.it",
                    UserHouseName = "TestUser",
                    UserHouseNumber = "5",
                    UserLang = null,
                    UserName = null,
                    UserPostCode = "TestUser",
                    UserStreet1 = "TestUser",
                    UserStreet2 = "TestUser",
                    UserTEL2 = null,
                    UserTELE = null,
                    UserTown = "TestUser",
                    UserType = 0,
                    VolRequired = "10"
                }
            };

            return db_ReqGoodTransferList;
        }

        public static List<db_TransportAvWithAddress> getTransportAvList()
        {
            var db_ReqGoodTransferList = new List<db_TransportAvWithAddress> {
                new db_TransportAvWithAddress
                {
                    AddreessDest = new Guid("d56c8abe-d3f7-44bd-8087-1f2c8fde36c1"),
                    AddressFrom = new Guid("46d26fb9-6643-4e97-a10d-8f8e0a51ad3c"),
                    DateTransportFixed = null,
                    DateTransportInfo = "Prima possibile",
                    DateTransportType = 1,
                    DestCountry = "Italia",
                    DestCounty = "Pesaro",
                    DestCreationDate = null,
                    DestDistrict = "Pesaro",
                    DestHouseName = "",
                    DestHouseNumber = "43",
                    DestPostCode = "43105",
                    DestStreet1 = "Via Giadi",
                    DestStreet2 = "testTo",
                    DestTown = "Budrio",
                    DestType = 0,
                    FromCountry = "Italia",
                    FromCounty = "Milano",
                    FromCreationDate = null,
                    FromDistrict = "Milano",
                    FromHouseName = "",
                    FromHouseNumber = "2",
                    FromPostCode = "20103",
                    FromStreet1 = "Via Gaudi",
                    FromStreet2 = "",
                    FromTown = "Monza",
                    FromType = 0,
                    Id = new Guid("d67cf6fb-7469-448c-9d4e-00ad01efb8da"),
                    RequestState = 0,
                    UserCountry = "TestUser",
                    UserCounty = "TestUser",
                    UserCreationDate = null,
                    UserDistrict = "TestUser",
                    UserEmail = "mario.fornaroli@yahoo.it",
                    UserHouseName = "TestUser",
                    UserHouseNumber = "5",
                    UserLang = null,
                    UserName = null,
                    UserPostCode = "TestUser",
                    UserStreet1 = "TestUser",
                    UserStreet2 = "TestUser",
                    UserTEL2 = null,
                    UserTELE = null,
                    UserTown = "TestUser",
                    UserType = 0,
                    VolAvailable = "10"
                }
            };

            return db_ReqGoodTransferList;
        }        
    }
}
