using Microsoft.AspNetCore.Identity;

namespace TicketHive.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<TicketModel> Tickets { get; set; }
    }
}