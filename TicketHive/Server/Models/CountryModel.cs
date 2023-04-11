using System.ComponentModel.DataAnnotations;
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
        public CountryModel(CountryDTO countryDTO)  // Constructor for recieving DTO
        {
            Name = countryDTO.Name;
            Currency = countryDTO.Currency;
            IsAvailableForUserRegistration = countryDTO.IsAvailableForUserRegistration;
        }

        //public CountryModel(CountryDTO cDto) // Constructor for DTO
        //{
        //    Name = cDto.Name;
        //    Currency = cDto.Currency;
        //    IsAvailableForUserRegistration = cDto.IsAvailableForUserRegistration;
        //}
    }
}
