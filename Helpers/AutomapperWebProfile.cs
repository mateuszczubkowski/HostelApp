using AutoMapper;
using HostelApp.Dtos.Guests;
using HostelApp.Dtos.Reservations;
using HostelApp.Helpers.Enums;
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
            CreateMap<Reservation, GetReservationDto>()
                .ForMember(x => x.CurrencyType, y => y.MapFrom(z => CurrencyEnumHelper(z.CurrencyType)));
            CreateMap<Guest, GetGuestDto>();

            CreateMap<Reservation, GetReservationWithGuestsDto>()
                .ForMember(x => x.CurrencyType, y => y.MapFrom(z => CurrencyEnumHelper(z.CurrencyType)))
                .ForPath(x => x.Guests, y => y.MapFrom(z => z.Guests));
            CreateMap<Guest, GetGuestWithReservationsDto>()
                .ForPath(x => x.Reservations, y => y.MapFrom(z => z.Reservations));

            CreateMap<PostReservationDto, Reservation>()
                .ForMember(x => x.Guests, y => y.Ignore())
                .ForMember(x => x.CreatedAt, y => y.Ignore());
        }

        private string CurrencyEnumHelper(CurrencyType type)
        {
            switch (type)
            {
                case CurrencyType.CAD:
                    return "CAD";
                case CurrencyType.CHF:
                    return "CHF";
                case CurrencyType.EUR:
                    return "EUR";
                case CurrencyType.GPB:
                    return "GPB";
                case CurrencyType.JPY:
                    return "JPY";
                case CurrencyType.PLN:
                    return "PLN";
                case CurrencyType.USD:
                    return "USD";
                default:
                    return "PLN";
            }
        }
    }
}