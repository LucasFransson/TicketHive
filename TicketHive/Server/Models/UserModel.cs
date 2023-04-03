using Microsoft.AspNetCore.Identity;

namespace TicketHive.Server.Models
{
    public class UserModel : IdentityUser
    {
        public List<TicketModel> Tickets { get; set; }
        public CountryModel Country { get; set; }
    }
}