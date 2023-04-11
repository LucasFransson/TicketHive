using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using TicketHive.Shared.DTOs;

namespace TicketHive.Shared.ViewModels
{
    public class CountryViewModel
    { 
        public string Name { get; set; }
        public string Currency { get; set; }    // Consider changing to defaulted Currency for all countries
        public bool IsAvailableForUserRegistration { get; set; }

        public CountryViewModel()
        {
           
        }
        public CountryViewModel(CountryDTO countryDTO)
        {
            Name = countryDTO.Name;
            Currency = countryDTO.Currency;
            IsAvailableForUserRegistration = countryDTO.IsAvailableForUserRegistration;
        }


        //public CountryViewModel(CountryDTO cDto)
        //{
        //    Name = cDto.Name;
        //    Currency = cDto.Currency;
        //    IsAvailableForUserRegistration = cDto.IsAvailableForUserRegistration;

        //}
        //// Constructor for getting related data to SoldTicketDto in the SoldTicketController
        //public CountryViewModel(SoldTicketDTO soldTicket)
        //{
        //    Name = soldTicket.Event.Country.Name;
        //    Currency = soldTicket.Event.Country.Currency;
        //    IsAvailableForUserRegistration = soldTicket.Event.Country.IsAvailableForUserRegistration;
        //}
    }

   
}
