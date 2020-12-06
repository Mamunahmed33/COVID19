using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CEN511_Covid19.Models
{
    public class DoctorUserRelation
    {
        public string userID { get; set; }
        public int SymptomsID { get; set; }
        public bool Fever { get; set; }
        public bool Cough { get; set; }
        [Display(Name = "Shortness of Breathe")]
        public bool ShortnessOfBreathe { get; set; }
        public bool Aches { get; set; }
        public bool Headache { get; set; }
        public bool Indigestion { get; set; }
        [Display(Name = "Starting Day of Symptoms")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartingDayOfSymptoms { get; set; }
        public int HealthStatusID { get; set; }

        [Display(Name = "Suggested for Testing?")]
        public bool SuggestedForTest { get; set; }

        [Display(Name = "Please mark if testing result is positive.")]
        public bool ResultStatus { get; set; }
        [Display(Name = "Result Verified?")]
        public bool VerificationStatus { get; set; }

        [Display(Name = "Are you recovered from COVID-19?")]
        public bool RecoveryStatus { get; set; }
        //[ForeignKey("User")]
        public string User { get; set; }
        //[ForeignKey("User")]
   
    }
}