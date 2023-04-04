using System.ComponentModel.DataAnnotations;

namespace TicketHive.Shared.ViewModels
{
    public class CountryViewModel
    {
        [Key]
        [MaxLength(100)]
        public required string Name { get; set; }
        [MaxLength(100)]
        public required string Currency { get; set; }
        public bool IsAvailableForUserRegistration { get; set; }
    }
}
