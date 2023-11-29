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
        //IEnum makes the class a collection which allows to get the flight id
        IEnumerable<Flight> GetAllFlights();
        Flight GetFlightById(int id);

        //what the program can do with the information got from id  (Add Update Delete)
        void AddFlight(Flight flight);
        void UpdateFlight(Flight flight);
        void DeleteFlight(int id);
    }
}
