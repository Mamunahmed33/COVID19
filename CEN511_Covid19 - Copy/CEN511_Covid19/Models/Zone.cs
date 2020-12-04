using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CEN511_Covid19.Models
{
    public class Zone
    {
        public int ZoneID { get; set; }
        [Display(Name = "Area Name")]
        public string Areaname { get; set; }
        [Display(Name = "District Name")]
        public string DistrictName { get; set; }
        [Display(Name = "Area Status")]
        public string AreaStatus { get; set; }
    }
}