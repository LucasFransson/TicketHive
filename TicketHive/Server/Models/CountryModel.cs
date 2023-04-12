using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using TicketHive.Shared.DTOs;

namespace TicketHive.Server.Models
{
    public class CountryModel
    {
        [Key]
        [MaxLength(100)]
        public required string Name { get; set; }
        [MaxLength(100)]
        public required string Currency { get; set; }
        public bool IsAvailableForUserRegistration { get; set; }

        public CountryModel()   // Empty Constructor for creating a new CountryModel
        {

        }

        // Constructor for Model from recieving DTO
        [SetsRequiredMembers]
        public CountryModel(CountryDTO countryDTO)  
        {
            Name = countryDTO.Name;
            Currency = countryDTO.Currency;
            IsAvailableForUserRegistration = countryDTO.IsAvailableForUserRegistration;
        }
    }
}
