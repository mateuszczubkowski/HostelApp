using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using HostelApp.Helpers.Enums;

namespace HostelApp.Models
{
    public class Reservation :BaseModel
    {
        [Required]
        [MaxLength(10)]
        public string ReservationCode { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public DateTime CheckInDate { get; set; }
        [Required]
        public DateTime CheckOutDate { get; set; }
        [Required]
        public CurrencyType CurrencyType { get; set; }
        public double? Commission { get; set; }
        public string Source { get; set; }
        public virtual IEnumerable<Guest> Guests { get; set; }
    }
}