using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CEN511_Covid19.Models
{
    public class HealthStatus
    {
        public int HealthStatusID { get; set; }

        [Display(Name = "Suggested for Testing?")]
        public bool SuggestedForTest { get; set; }

        [Display(Name = "Please mark if testing result is positive.")]
        public bool ResultStatus { get; set; }
        [Display(Name = "Result Verified?")]
        public bool VerificationStatus { get; set; }

        [Display(Name = "Are you recovered from COVID-19?")]
        public bool RecoveryStatus { get; set; }

        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}