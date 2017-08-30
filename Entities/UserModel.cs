using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class UserModel
    {
        public System.Guid ID { get; set; }
        public string UTEN { get; set; }
        public string TIPU { get; set; }
        public string PASS { get; set; }
        public Nullable<short> PWGG { get; set; }
        public Nullable<System.DateTime> PWSC { get; set; }
        public string NOME { get; set; }
        public string LANG { get; set; }
        public string EMAI { get; set; }
        public string TELE { get; set; }
        public string FAXN { get; set; }
        public string UFFI { get; set; }
        public string RIF1 { get; set; }
        public string RIF2 { get; set; }
        public string TELE2 { get; set; }
        public Nullable<System.Guid> ADR_ID { get; set; }
        public string Token { get; set; }

    }
}
