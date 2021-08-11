using HostelApp.Dtos.Guests;
using HostelApp.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HostelApp.Dtos.Reservations
{
    public class GetReservationDto
    {
        public Guid Id { get; set; }
        public string ReservationCode { get; set; }
        public DateTime CreatedAt { get; set; }
        public double Price { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string CurrencyType { get; set; }
        public double? Commission { get; set; }
        public string Source { get; set; }
    }
}