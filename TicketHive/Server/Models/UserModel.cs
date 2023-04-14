using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketHive.Server.Models
{
    public class UserModel : IdentityUser
    {
		[ForeignKey(nameof(Country))]
        [Column("Country")]
        public string? CountryName { get; set; }
        public CountryModel? Country { get; set; }
    }
}