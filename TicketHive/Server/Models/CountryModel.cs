using System.ComponentModel.DataAnnotations;

namespace TicketHive.Server.Models
{
    public class CountryModel
    {
        [Key]
        [MaxLength(100)]
        public required string Name { get; set; }
        [MaxLength(100)]
        public required string Currency { get; set; }
    }
}
