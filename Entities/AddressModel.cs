using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class AddressModel
    {
        public System.Guid Id { get; set; }
        public string formatted_address { get; set; }
        public string location_type { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
    }
}
