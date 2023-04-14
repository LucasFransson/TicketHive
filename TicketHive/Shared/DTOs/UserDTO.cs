using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TicketHive.Shared.ViewModels;

namespace TicketHive.Shared.DTOs;
public class UserDTO
	{
		public string? CountryName { get; set; }
		public string? Currency { get; set; }


    public UserDTO(string countryName, string currency)
    {
        CountryName = countryName;

	    Currency = currency;
    }
}

