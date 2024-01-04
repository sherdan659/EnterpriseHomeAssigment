using Microsoft.AspNetCore.Mvc;
using Data.Interface;
using Presentation.Models;
using Domain.Models;

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

        public async Task<IActionResult> Book(ViewTicketModel ticketViewModel)
        {
            if (ModelState.IsValid)
            {
                var flight = await _flightRepository.GetFlight(ticketViewModel.FlightId);
                if (flight == null || flight.DepartureDate <= DateTime.Now || await _flightRepository.IsFlightFullyBooked(flight.Id))
                {
                    ModelState.AddModelError("", "Cant book this flight");
                    return View(ticketViewModel);
                }
                var ticket = new Ticket
                {
                    FlightId = flight.Id,
                    Cancelled = false,
                };
                await _ticketRepository.Book(ticket);
                return RedirectToAction("Details", new { id = ticket.Id });
            }
            return View(ticketViewModel);
        }
    }
}
