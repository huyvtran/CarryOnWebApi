using Entities.enums;
using Entities.GMaps;
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
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserTELE { get; set; }
        public string UserTEL2 { get; set; }
        public string UserLang { get; set; }
        public string VolRequired { get; set; }
        public System.Guid UserId { get; set; }
        public GeoCodeResult fromAddress { get; set; }
        public GeoCodeResult destAddress { get; set; }
        public GeoCodeResult userAddress { get; set; }

        public List<ReqGoodTransportOptions> ReqGoodTransportOpt { get; set; }
        
    }
}
