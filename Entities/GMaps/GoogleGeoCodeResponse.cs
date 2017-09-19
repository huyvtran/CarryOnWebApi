using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.GMaps
{
    public class GoogleGeoCodeResponse
    {

        public string status { get; set; }
        public GeoCodeResult[] results { get; set; }

    }

    public class GeoCodeResult
    {
        public Guid? Id { get; set; }
        public string formatted_address { get; set; }
        public Geometry geometry { get; set; }
        //public string[] types { get; set; }
        public Address_component[] address_components { get; set; }
    }

    public class Geometry
    {
        public string location_type { get; set; }
        public Location location { get; set; }
    }

    public class Location
    {
        public string lat { get; set; }
        public string lng { get; set; }
    }

    public class Address_component
    {
        public string long_name { get; set; }
        public string short_name { get; set; }
        public string[] types { get; set; }
    }
}
