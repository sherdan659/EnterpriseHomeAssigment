using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Interface;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositorys
{
    public class TicketDbRepository : ITicketDbRepository
    {
        private readonly AirlineDbContext _context;

        public TicketDbRepository(AirlineDbContext context)
        {
            _context = context;
        }

        public Ticket BookTicket(Ticket ticket)
        {
            var existingTicket = _context.Tickets
                .FirstOrDefault(t => t.FlightIdFK == ticket.FlightIdFK && t.Row == ticket.Row && t.Column == ticket.Column);

            if (existingTicket != null)
            {
                throw new InvalidOperationException("This seat is already booked.");
            }

            _context.Tickets.Add(ticket);
            _context.SaveChanges();
            return ticket;
        }

        public void CancelTicket(int ticketId)
        {
            var ticket = _context.Tickets.Find(ticketId);
            if (ticket == null)
            {
                throw new InvalidOperationException("Ticket not found.");
            }

            ticket.Cancelled = true;
            _context.SaveChanges();
        }

        public IEnumerable<Ticket> GetTicketsByFlight(int flightId)
        {
            return _context.Tickets
                .Where(t => t.FlightIdFK == flightId)
                .ToList();
        }
    }
}
