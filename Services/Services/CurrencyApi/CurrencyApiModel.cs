using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketHive.Bll.Services.CurrencyApi;
public class CurrencyApiModel
{
	public class Rates
	{
		[JsonProperty("BGN")]
		public double BGN { get; set; }

		[JsonProperty("CZK")]
		public double CZK { get; set; }

		[JsonProperty("DKK")]
		public double DKK { get; set; }

		[JsonProperty("EUR")]
		public double EUR { get; set; }

		[JsonProperty("GBP")]
		public double GBP { get; set; }

		[JsonProperty("HRK")]
		public double HRK { get; set; }

		[JsonProperty("HUF")]
		public double HUF { get; set; }

		[JsonProperty("ISK")]
		public double ISK { get; set; }

		[JsonProperty("PLN")]
		public double PLN { get; set; }

		[JsonProperty("RON")]
		public double RON { get; set; }

		[JsonProperty("SEK")]
		public double SEK { get; set; }
	}

	public class Root
	{
		[JsonProperty("base")]
		public string Base { get; set; }

		[JsonProperty("date")]
		public string Date { get; set; }

		[JsonProperty("rates")]
		public Rates Rates { get; set; }

		[JsonProperty("success")]
		public bool? Success { get; set; }

		[JsonProperty("timestamp")]
		public int? Timestamp { get; set; }
	}


}
