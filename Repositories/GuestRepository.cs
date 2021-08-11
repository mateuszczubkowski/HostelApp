using AutoMapper;
using HostelApp.Data;
using HostelApp.Dtos.Guests;
using HostelApp.Helpers;
using HostelApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace HostelApp.Repositories
{
    public class GuestRepository
    {
        private readonly HostelContext _context = new HostelContext();
        private readonly IMapper _mapper;

        public GuestRepository()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<AutomapperWebProfile>();
            });

            _mapper = config.CreateMapper();
        }

        public async Task<List<GetGuestWithReservationsDto>> GetGuests()
        {
            var guests = await _context.Guests
                    .Where(x => x.FirstName == "Piotr" && (x.City == "Wrocław" || x.City == null))
                    .Include(x => x.Reservations).ToListAsync();

            return _mapper.Map<List<GetGuestWithReservationsDto>>(guests);
        }
        public async Task<List<GetGuestWithReservationsDto>> GetGuests(string firstName, string city)
        {
            var guests = await _context.Guests
                    .Where(x => x.FirstName == firstName && (x.City == city || x.City == null))
                    .Include(x => x.Reservations).ToListAsync();

            return _mapper.Map<List<GetGuestWithReservationsDto>>(guests);
        }
    }
}