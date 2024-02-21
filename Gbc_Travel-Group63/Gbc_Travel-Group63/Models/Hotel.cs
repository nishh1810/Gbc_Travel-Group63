namespace Gbc_Travel_Group63.Models
{
    public class Hotel
    {
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public string Location { get; set; }
        public int StarRating { get; set; }
        public decimal PricePerNight { get; set; }
        public bool IsPetFriendly { get; set; }
        public string RoomType { get; set; }
    }
}
