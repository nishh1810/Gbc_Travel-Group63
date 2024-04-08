namespace Gbc_Travel_Group63.Models{
    public class Booking
{
    public int BookingId { get; set; }
    public string UserId { get; set; }
    public string BookingType { get; set; }

    public bool IsGuest { get; set; }

    public int ItemId { get; set; }
    // Add other necessary properties

    // Navigation property if needed
    // public User User { get; set; }

    public Booking()
    {
        // Set default values here
        // For example:
        IsGuest = true; // Default to true for non-authenticated users
        UserId = "Guest"; // Default user ID for non-authenticated users
    }
    
}
}