using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CEN511_Covid19.Models
{
    public class UserType
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public string UserEmail { get; set; }
        public string UserName { get; set; }
        public string UserAddress { get; set; }
        public string UserPhone { get; set; }

        public string RoleID { get; set; }
        public string RoleName { get; set; }
    }
}