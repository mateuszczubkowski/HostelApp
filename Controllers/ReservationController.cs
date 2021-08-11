using HostelApp.Dtos.Reservations;
using HostelApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace HostelApp.Controllers
{
    public class ReservationController : ApiController
    {
        private readonly ReservationRepository _repository = new ReservationRepository();

        // GET api/reservation
        public async Task<IEnumerable<GetReservationWithGuestsDto>> GetGuests()
        {
            return await _repository.GetReservations();
        }
        // POST api/reservation
        public Task<GetReservationWithGuestsDto> PostReservation([FromBody] PostReservationDto dto)
        {
            return _repository.AddReservation(dto);
        }
    }
}
