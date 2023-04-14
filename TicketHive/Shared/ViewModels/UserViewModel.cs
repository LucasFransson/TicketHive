using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketHive.Shared.DTOs;

namespace TicketHive.Shared.ViewModels;
public class UserViewModel
{
	public string? CountryName { get; set; }
	public string? Currency { get; set; }

    public UserViewModel()
    {
			
    }

    public UserViewModel(UserDTO dto)
	{
		CountryName = dto.CountryName;

		Currency = dto.Currency;
	}
}
