using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CEN511_Covid19.Models
{
    public class Feedback
    {
        public int ID { get; set; }
        public string Comment { get; set; }

        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }

    }
}