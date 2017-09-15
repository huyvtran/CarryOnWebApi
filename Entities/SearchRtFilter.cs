using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class SearchRtFilter
    {
        public ReqGoodTransferModel RqgtFilter { get; set; }
        public TransportAvModel TranspAvFilter { get; set; }
        public FilterParams FilterParams { get; set; }
    }
}
