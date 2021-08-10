using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HostelApp.Models
{
    public class Guest : BaseModel
    {
        public Guest()
        {
            this.Reservations = new HashSet<Reservation>();
        }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string SecondName { get; set; }
        [Required]
        public string Email { get; set; }
        public DateTime? BirthdayDate { get; set; }
        public string PostalCode { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }
}