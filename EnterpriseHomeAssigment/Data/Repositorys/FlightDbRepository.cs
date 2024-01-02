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
            _context = context;
        }


        public async Task<IEnumerable<Flight>> GetFlights()
        {
            return await _context.Flights.ToListAsync();
        }


        public async Task<Flight> GetFlight(int id)
        {
            return await _context.Flights.FindAsync(id);
        }


        public async Task AddFlight(Flight flight)
        {
            _context.Flights.Add(flight);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateFlight(Flight flight)
        {
            _context.Flights.Update(flight);
            await _context.SaveChangesAsync();
        }


        public async Task DeleteFlight(int id)
        {
            var flight = await _context.Flights.FindAsync(id);
            if (flight != null)
            {
                _context.Flights.Remove(flight);
                await _context.SaveChangesAsync();
            }
        }


        public async Task<bool> IsFlightFullyBooked(int flightId)
        {
            var flight = await _context.Flights.FindAsync(flightId);
            if (flight == null)
            {
                return false; 
            }
            var totalseats = flight.Rows * flight.Columns; 
            var bookedTicketsCount = await _context.Tickets.CountAsync(t => t.FlightIdFK == flightId && !t.Cancelled);
            return bookedTicketsCount >= totalseats;
        }
    }
}
