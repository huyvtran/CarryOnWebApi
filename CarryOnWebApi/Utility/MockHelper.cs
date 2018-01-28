using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarryOnWebApi.Utility
{
    public static class UtilityHelper
    {
        public static UserModel getStandardUser()
        {
            var standardUser = new UserModel
            {
                UserEmail = "notIdentifiedmail.com",
                UserName = "notIdentifiedmail.com",
                UserLongName = "Not Identified"
            };

            return standardUser;
        }

      
    }
}
