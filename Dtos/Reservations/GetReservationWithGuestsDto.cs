using HostelApp.Dtos.Guests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HostelApp.Dtos.Reservations
{
    public class GetReservationWithGuestsDto : GetReservationDto
    {
        public virtual ICollection<GetGuestDto> Guests { get; set; }
    }
}