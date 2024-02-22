using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gbc_Travel_Group63.Models
{
    public class Flights
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FlightNumber { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        [DataType(DataType.Date)]
        public DateTime DepartureDate { get; set; }
        [DataType(DataType.Time)]
        public DateTime DepartureTime { get; set; }
        [DataType(DataType.Time)]
        public DateTime ArrivalTime { get; set; }
        public int? NumberOfPassengers { get; set; } // Nullable integer
        public int TotalSeats { get;  } = 450; 
        public decimal Price { get; set; } // Add the Price property
    }
}
