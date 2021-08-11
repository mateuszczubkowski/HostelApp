using HostelApp.Dtos.Reservations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HostelApp.Dtos.Guests
{
    public class GetGuestWithReservationsDto : GetGuestDto
    {
        public virtual ICollection<GetReservationDto> Reservations { get; set; }
    }
}