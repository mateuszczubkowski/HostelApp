using HostelApp.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HostelApp.Dtos.Reservations
{
    public class PostReservationDto
    {
        public string ReservationCode { get; set; }
        public double Price { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public CurrencyType CurrencyType { get; set; }
        public double? Commission { get; set; }
        public string Source { get; set; }
        public List<Guid> GuestsIds { get; set; }
    }
}