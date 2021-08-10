using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HostelApp.Models
{
    public class Guest : BaseModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string SecondName { get; set; }
        [Required]
        public string Email { get; set; }
        public DateTime? BirthdayDate { get; set; }
        public string PostalCode { get; set; }
        public virtual IEnumerable<Reservation> Reservations { get; set; }
    }
}