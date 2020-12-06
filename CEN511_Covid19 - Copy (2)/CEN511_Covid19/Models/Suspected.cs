using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CEN511_Covid19.Models
{
    public class Suspected
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "You must provide a phone number")]
        [Display(Name = "Suspect Person's Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }
        public string UserID { get; set; }

    }
}