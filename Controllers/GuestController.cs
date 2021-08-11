using HostelApp.Dtos.Guests;
using HostelApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace HostelApp.Controllers
{
    public class GuestController : ApiController
    {
        private readonly GuestRepository _repository = new GuestRepository();

        // GET api/guest
        public async Task<IEnumerable<GetGuestWithReservationsDto>> GetGuests()
        {
            return await _repository.GetGuests();
        }
        public async Task<IEnumerable<GetGuestWithReservationsDto>> GetGuests(string firstName, string city)
        {
            return await _repository.GetGuests(firstName, city);
        }
    }
}