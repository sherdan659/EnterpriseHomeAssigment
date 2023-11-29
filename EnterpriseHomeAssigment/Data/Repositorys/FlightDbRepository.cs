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
    public class FlightDbRepository : IFlightDbRepository
    {

        private readonly AirlineDbContext _context;

        public FlightDbRepository(AirlineDbContext context)
        {
            // The contents in the database needs to default to null   (if left empty it will expect a input and crash or cause corruption)
            // The model database needs to be the same as a normal database    empty -> Null by default
            _context = context;   
        }

        // connects via id from the interface
        public IEnumerable<Flight> GetAllFlights()
        {
            return _context.Flights.ToList();
        }

        public Flight GetFlightById(int id)
        {
            return _context.Flights.Find(id);
        }

        public void AddFlight(Flight flight)
        {
            _context.Flights.Add(flight);
            _context.SaveChanges();
        }

        public void UpdateFlight(Flight flight)
        {
            _context.Flights.Update(flight);
            _context.SaveChanges();
        }

        public void DeleteFlight(int id)
        {
            var flight = _context.Flights.Find(id);
            if (flight != null)
            {
                _context.Flights.Remove(flight);
                _context.SaveChanges();
            }
        }

    }
}
