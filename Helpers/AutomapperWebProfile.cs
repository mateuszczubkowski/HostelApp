using AutoMapper;
using HostelApp.Dtos.Guests;
using HostelApp.Dtos.Reservations;
using HostelApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HostelApp.Helpers
{
    public class AutomapperWebProfile : Profile
    {
        public AutomapperWebProfile()
        {
            CreateMap<Reservation, GetReservationDto>();
            CreateMap<Guest, GetGuestDto>();

            CreateMap<Reservation, GetReservationWithGuestsDto>()
                 .ForPath(x => x.Guests, y => y.MapFrom(z => z.Guests));
            CreateMap<Guest, GetGuestWithReservationsDto>()
                .ForPath(x => x.Reservations, y => y.MapFrom(z => z.Reservations));

            CreateMap<PostReservationDto, Reservation>()
                .ForMember(x => x.Guests, y => y.Ignore())
                .ForMember(x => x.CreatedAt, y => y.Ignore());
        }
    }
}