using Entities.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class BaseResultModel
    {
        public string InfoLog { get; set; }
        public bool OperationResult { get; set; }
        public ErrorsEnum? ResultMessage { get; set; }
    }
}
