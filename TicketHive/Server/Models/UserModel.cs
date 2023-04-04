using Microsoft.AspNetCore.Identity;

namespace TicketHive.Server.Models
{
    public class UserModel : IdentityUser
    {
        public CountryModel Country { get; set; }
    }
}