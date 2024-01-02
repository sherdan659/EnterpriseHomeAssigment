using Data.Interface;
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
    }
}
