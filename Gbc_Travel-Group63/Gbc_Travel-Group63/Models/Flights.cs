using System.ComponentModel.DataAnnotations;

namespace Gbc_Travel_Group63.Models
{
    public class Flights
    {
        [Key]
        public string FlightNumber { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        [DataType(DataType.Date)]
        public DateTime DepartureDate { get; set; }
        [DataType(DataType.Time)]
        public DateTime DepartureTime { get; set; }
        [DataType(DataType.Time)]
        public DateTime ArrivalTime { get; set; }
        public int? NumberOfPassengers { get; set; } // Nullable integer
        public int TotalSeats { get; } = 450; // Static total seats
        public decimal Price { get; set; } // Add the Price property
    }
}
