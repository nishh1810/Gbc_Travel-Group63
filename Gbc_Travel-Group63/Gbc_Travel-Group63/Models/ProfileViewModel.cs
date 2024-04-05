using Microsoft.AspNetCore.Http;


namespace Gbc_Travel_Group63.Models
{
    public class ProfileViewModel
    {
        public string FullName { get; set; }
        public string ContactNumber { get; set; }
        public string Preferences { get; set; }
        public byte[] ProfilePicture { get; set; }
    }
}