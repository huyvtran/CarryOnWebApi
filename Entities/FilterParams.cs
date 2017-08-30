using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class FilterParams
    {
        public int Page { get; set; }
        public int Count { get; set; }
        public Dictionary<string, string> Sorting { get; set; }
        public Dictionary<string, string> Filter { get; set; }

        public override string ToString()
        {
            return $"{{Page={Page}, Count={Count}}}";
        }
    }
}
