using AutoMapper;
using HostelApp.Data;
using HostelApp.Dtos.Reservations;
using HostelApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity;
using HostelApp.Models;

namespace HostelApp.Repositories
{
    public class ReservationRepository
    {
        private readonly HostelContext _context = new HostelContext();
        private readonly IMapper _mapper;

        public ReservationRepository()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<AutomapperWebProfile>();
            });

            _mapper = config.CreateMapper();
        }

        public async Task<List<GetReservationWithGuestsDto>> GetReservations()
        {
            var reservations = await _context.Reservations.Include(x => x.Guests).ToListAsync();

            return _mapper.Map<List<GetReservationWithGuestsDto>>(reservations);
        }

        public async Task<GetReservationWithGuestsDto> AddReservation(PostReservationDto dto)
        {
            try
            {

                var reservation = _mapper.Map<Reservation>(dto);

                var guests = await _context.Guests.Where(x => dto.GuestsIds.Contains(x.Id)).ToListAsync();

                reservation.Id = Guid.NewGuid();
                reservation.Guests = guests;
                reservation.CreatedAt = DateTime.UtcNow;

                _context.Reservations.Add(reservation);
                _context.SaveChanges();

                return _mapper.Map<GetReservationWithGuestsDto>(reservation);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}