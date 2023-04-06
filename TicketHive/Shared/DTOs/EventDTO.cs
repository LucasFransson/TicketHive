using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketHive.Shared.DTOs
{
    public class EventViewModel
    {
        public string Name { get; set; }
        public int MaxUsers { get; set; }
        public decimal Price { get; set; }
        public CountryDTO Country { get; set; }
    }
}
