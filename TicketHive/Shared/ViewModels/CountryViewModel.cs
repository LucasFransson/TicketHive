using System.ComponentModel.DataAnnotations;

namespace TicketHive.Shared.ViewModels
{
    public class CountryViewModel
    {
  
        public  string Name { get; set; }
        public  string Currency { get; set; }    // Consider changing to defaulted Currency for all countries
        public bool IsAvailableForUserRegistration { get; set; }

        public CountryViewModel(string name, string currency, bool isAvailableForUserRegistration)
        {
            Name = name;
            Currency=currency;
            IsAvailableForUserRegistration = isAvailableForUserRegistration;
        }
    }
}
