using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CEN511_Covid19.Models
{
    public class CountryStatus
    {
        public int ID { get; set; }

        public int TotalSuspected { get; set; }
        public int TotalAffected { get; set; }
        public int TotalRecovered { get; set; }
        public DateTime Date { get; set; }
    }
}