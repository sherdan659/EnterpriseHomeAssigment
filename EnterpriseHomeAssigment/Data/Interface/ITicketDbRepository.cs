using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Data.Interface
{
    public interface ITicketDbRepository
    {
        Task<Ticket> Book(Ticket ticket);
        Task Cancel(int ticketId);
        Task<IEnumerable<Ticket>> GetTickets(int flightId);
    }
}
