using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketHive.Shared.ViewModels;

namespace TicketHive.Shared.DTOs
{
    public class CountryDTO
    {
        // Rmoved Required because it caused errors
        public string Name { get; set; } 
        public string Currency { get; set; } 
        public bool IsAvailableForUserRegistration { get; set; }


        //public CountryDTO()
        //{
            
        //}

        // Constructor for DTO from Model Input Parameters
     
        public CountryDTO(string name, string currency, bool isAvailableForUserRegistration)
        {
            Name = name;
            Currency = currency;
            IsAvailableForUserRegistration = isAvailableForUserRegistration;
        }
    }
}
