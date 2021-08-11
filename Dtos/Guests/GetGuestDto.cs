using HostelApp.Dtos.Reservations;
using HostelApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HostelApp.Dtos.Guests
{
    public class GetGuestDto
    {

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public DateTime? BirthdayDate { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }
}