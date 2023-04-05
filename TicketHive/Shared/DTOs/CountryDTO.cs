using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketHive.Shared.DTOs
{
    public class CountryDTO
    {
        public string Name { get; set; }
        public string Currency { get; set; }
        public bool IsAvailableForUserRegistration { get; set; }
    }
}
