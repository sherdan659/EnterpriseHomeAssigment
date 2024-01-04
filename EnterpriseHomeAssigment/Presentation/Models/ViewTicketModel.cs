﻿namespace Presentation.Models
{
    public class ViewTicketModel
    {
        public int FlightId { get; set; }
        public string FlightNumber { get; set; }
        public DateTime DepartureDate { get; set; }
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }
        public decimal Price { get; set; }

    }
}
