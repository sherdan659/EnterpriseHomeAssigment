using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Data.Interface
{
    public interface IFlightDbRepository
    {
        Task<IEnumerable<Flight>> GetFlights();
        Task<Flight> GetFlight(int id);
        Task AddFlight(Flight flight);
        Task UpdateFlight(Flight flight);
        Task DeleteFlight(int id);
        Task<bool> IsFlightFullyBooked(int flightId);
    }
}
