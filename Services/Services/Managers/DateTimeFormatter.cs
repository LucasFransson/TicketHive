using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketHive.Bll.Services.Managers
{
	public static class DateTimeFormatter
	{

		// 30th July - 19:30
		public static string FormatDayNumberMonthText(DateTime dateTime)
		{
			string formattedDate = dateTime.ToString("dd')' MMMM");
			string formattedTime = dateTime.ToString("HH:mm");
			return $"{formattedDate} - {formattedTime}";
		}
		// July 2023
		public static string FormatMonthNameYear(DateTime dateTime)
		{
			return dateTime.ToString("MMMM yyyy");
		}
		//19:30
		public static string FormatTime(DateTime dateTime)
		{
			return dateTime.ToString("t");
		}

		//Saturday, July 30, 2023 7:30:00 PM
		public static string FormatFullDateTime(DateTime dateTime)
		{
			return dateTime.ToString("F");
		}
	}
}
