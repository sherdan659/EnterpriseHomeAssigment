using Data.Interface;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class FlightsController : Controller
    {
        private readonly IFlightDbRepository _flightRepository;

        public FlightsController(IFlightDbRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Rows,Columns,DepartureDate,ArrivalDate,CountryFrom,CountryTo,WholesalePrice,CommissionRate")] Flight flight)
        {
            if (ModelState.IsValid)
            {
                await _flightRepository.AddFlight(flight);
                return RedirectToAction(nameof(Index));
            }
            return View(flight);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var flight = await _flightRepository.GetFlight(id);
            if (flight == null)
            {
                return NotFound();
            }
            return View(flight);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Rows,Columns,DepartureDate,ArrivalDate,CountryFrom,CountryTo,WholesalePrice,CommissionRate")] Flight flight)
        {
            if (id != flight.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _flightRepository.UpdateFlight(flight);
                return RedirectToAction(nameof(Index));
            }
            return View(flight);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var flight = await _flightRepository.GetFlight(id);
            if (flight == null)
            {
                return NotFound();
            }
            return View(flight);
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _flightRepository.DeleteFlight(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
