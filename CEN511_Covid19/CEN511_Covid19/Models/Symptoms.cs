using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CEN511_Covid19.Models
{
    public class Symptoms
    {
        public int SymptomsID { get; set; }
        public bool Fever { get; set; }
        public bool Cough { get; set; }
        [Display(Name = "Shortness of Breathe")]
        public bool ShortnessOfBreathe { get; set; }
        public bool Aches { get; set; }
        public bool Headache { get; set; }
        public bool Ingigestion { get; set; }
        [Display(Name = "Starting Day of Symptoms")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartingDayOfSymptoms { get; set; }
        public virtual ICollection<RegisterViewModel> RegisterViewModel { get; set; }


    }
}