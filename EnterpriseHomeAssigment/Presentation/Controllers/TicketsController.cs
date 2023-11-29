using Microsoft.AspNetCore.Mvc;
using Data.Interface;


namespace Presentation.Controllers
{
    public class TicketsController : Controller
    {

        private readonly IFlightDbRepository _flightRepository;
        private readonly ITicketDbRepository _ticketRepository;
        public TicketsController(IFlightDbRepository flightRepository, ITicketDbRepository ticketRepository)
        {
            _flightRepository = flightRepository;
            _ticketRepository = ticketRepository;
        }
       

    }
}
