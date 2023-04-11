using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketHive.Shared.ViewModels;

namespace TicketHive.Shared.DTOs
{
    public class CountryDTO
    {
        public required string Name { get; set; } 
        public required string Currency { get; set; } 
        public bool IsAvailableForUserRegistration { get; set; }


        public CountryDTO()
        {
            
        }
        // Constructor for Model
        public CountryDTO(string name, string currency, bool isAvailableForUserRegistration)
        {
            Name = name;
            Currency = currency;
            IsAvailableForUserRegistration = isAvailableForUserRegistration;
        }

        //// Constructor for ViewModel

        //public CountryDTO(CountryViewModel viewModel)
        //{
        //    Name = viewModel.Name;
        //    Currency = viewModel.Currency;
        //    IsAvailableForUserRegistration = viewModel.IsAvailableForUserRegistration;
        //}
    }
}
