using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using TicketHive.Shared.DTOs;

namespace TicketHive.Shared.ViewModels
{
    public class CountryViewModel
    { 
        public string Name { get; set; }
        public string Currency { get; set; }  
        public bool IsAvailableForUserRegistration { get; set; }

        public CountryViewModel()
        {
           
        }
        // Constructor for ViewModel from DTO
        public CountryViewModel(CountryDTO countryDTO)
        {
            Name = countryDTO.Name;
            Currency = countryDTO.Currency;
            IsAvailableForUserRegistration = countryDTO.IsAvailableForUserRegistration;
        }

    }

   
}
