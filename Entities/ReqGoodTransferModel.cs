using Entities.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ReqGoodTransferModel
    {
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> AddressFrom { get; set; }
        public Nullable<System.Guid> AddreessDest { get; set; }
        public Nullable<System.DateTime> DateTransportFixed { get; set; }
        public int DateTransportType { get; set; }
        public string DateTransportInfo { get; set; }
        public int RequestState { get; set; }
        public int FromType { get; set; }
        public string FromCounty { get; set; }
        public string FromCountry { get; set; }
        public string FromDistrict { get; set; }
        public string FromHouseName { get; set; }
        public Nullable<System.DateTime> FromCreationDate { get; set; }
        public string FromHouseNumber { get; set; }
        public string FromPostCode { get; set; }
        public string FromStreet1 { get; set; }
        public string FromStreet2 { get; set; }
        public string FromTown { get; set; }
        public int DestType { get; set; }
        public string DestCounty { get; set; }
        public string DestCountry { get; set; }
        public string DestDistrict { get; set; }
        public string DestHouseName { get; set; }
        public Nullable<System.DateTime> DestCreationDate { get; set; }
        public string DestHouseNumber { get; set; }
        public string DestPostCode { get; set; }
        public string DestStreet1 { get; set; }
        public string DestStreet2 { get; set; }
        public string DestTown { get; set; }
        public int UserType { get; set; }
        public string UserCounty { get; set; }
        public string UserCountry { get; set; }
        public string UserDistrict { get; set; }
        public string UserHouseName { get; set; }
        public Nullable<System.DateTime> UserCreationDate { get; set; }
        public string UserHouseNumber { get; set; }
        public string UserPostCode { get; set; }
        public string UserStreet1 { get; set; }
        public string UserStreet2 { get; set; }
        public string UserTown { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserTELE { get; set; }
        public string UserTEL2 { get; set; }
        public string UserLang { get; set; }
        public string VolRequired { get; set; }
        public System.Guid UserId { get; set; }

        public List<ReqGoodTransportOptions> ReqGoodTransportOpt { get; set; }

        public string MyProperty { get; set; }
        public string AddressFromFormattedStr
        {
            get
            {
                return FormatAddressStr(new List<string> { this.FromStreet1, this.FromHouseNumber, this.FromTown, this.FromDistrict, this.FromPostCode, this.FromCountry.Substring(0, 2) });
            }
        }
        public string AddressFromShortFormattedStr
        {
            get
            {
                return FormatAddressStr(new List<string> { this.FromTown, this.FromDistrict, this.FromPostCode, this.FromCountry.Substring(0, 2) });
            }
        }

        public string AddressDestFormattedStr
        {
            get
            {
                return FormatAddressStr(new List<string> { this.DestStreet1, this.DestHouseNumber, this.DestTown, this.DestDistrict, this.DestPostCode, this.DestCountry.Substring(0, 2) });
            }
        }

        public string AddressDestShortFormattedStr
        {
            get
            {
                return FormatAddressStr(new List<string> { this.DestTown, this.DestDistrict, this.DestPostCode, this.DestCountry.Substring(0, 2) });
            }
        }



        public string AddressUserFormattedStr
        {
            get
            {
                return FormatAddressStr(new List<string> { this.UserStreet1, this.UserHouseNumber, this.UserTown, this.UserDistrict, this.UserPostCode, this.UserCountry.Substring(0, 2) });
            }
        }

        private string FormatAddressStr(List<string> inputValues)
        {
            return String.Join(", ", inputValues.Where(x => !string.IsNullOrEmpty(x)).Distinct());
        }
    }
}
