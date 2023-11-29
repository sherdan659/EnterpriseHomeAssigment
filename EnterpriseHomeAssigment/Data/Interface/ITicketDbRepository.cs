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
        Ticket BookTicket(Ticket ticket);
        void CancelTicket(int ticketId);
        IEnumerable<Ticket> GetTicketsByFlight(int flightId);
    }
}
