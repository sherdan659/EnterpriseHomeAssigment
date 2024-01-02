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


        public async Task<Ticket> Book(Ticket ticket)
        {
            var existingTicket = await _context.Tickets
                .FirstOrDefaultAsync(t => t.FlightIdFK == ticket.FlightIdFK && t.Row == ticket.Row && t.Column == ticket.Column);

            if (existingTicket != null)
            {
                throw new InvalidOperationException("This seat is already booked.");
            }

            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();
            return ticket;
        }


        public async Task Cancel(int ticketId)
        {
            var ticket = await _context.Tickets.FindAsync(ticketId);
            if (ticket == null)
            {
                throw new InvalidOperationException("Ticket not found.");
            }

            ticket.Cancelled = true;
            await _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<Ticket>> GetTickets(int flightId)
        {
            return await _context.Tickets
                .Where(t => t.FlightIdFK == flightId)
                .ToListAsync();
        }
    }
}
