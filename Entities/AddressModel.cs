using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class AddressModel
    {
        public System.Guid AddressID { get; set; }
        public int Type { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public string District { get; set; }
        public string HouseName { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public string HouseNumber { get; set; }
        public string PostCode { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string Town { get; set; }
    }
}
