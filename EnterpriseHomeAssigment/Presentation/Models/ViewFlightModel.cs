namespace Presentation.Models
{
    public class ViewFlightModel
    {
        public int Id { get; set; }
        public string FlightNumber { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }
        public decimal WholesalePrice { get; set; }
        public decimal CommissionRate { get; set; }
        public decimal RetailPrice { get; set; }
        public bool IsFullyBooked { get; set; }

    }
}
