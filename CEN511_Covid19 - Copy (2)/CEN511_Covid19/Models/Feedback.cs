using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CEN511_Covid19.Models
{
    public class Feedback
    {
        public int ID { get; set; }
        public string Comment { get; set; }
        //[ForeignKey("User")]
        public string User { get; set; }

    }
}