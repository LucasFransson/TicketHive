using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TicketHive.Bll.Services.CurrencyApi.CurrencyApiModel;

namespace TicketHive.Bll.Services.CurrencyApi;

public static class CurrencyApiHelper
{
    public static HttpClient HttpClient { get; set; } = new()
    {

    };

    public static void ApiInitializer()
    {
        HttpClient.BaseAddress = new Uri("https://api.apilayer.com/");
        HttpClient.DefaultRequestHeaders.Add("apikey", "9JMMGz1hmq0qbBfazIE9tIq7KVFgxqEq");
    }

    public static async Task<double?> MakeCallAsync(string userCurrency)
    {
        HttpResponseMessage response = await HttpClient.GetAsync("exchangerates_data/latest?symbols=EUR,GBP,HRK,CZK,DKK,HUF,PLN,RON,SEK,BGN,ISK&base=USD");

        if(response.IsSuccessStatusCode)
        {
			var json = await response.Content.ReadAsStringAsync();

			Root root = JsonConvert.DeserializeObject<Root>(json);

            if(userCurrency == "SEK" )
            {
                return root.Rates.SEK;
            }
			else if (userCurrency == "GBP")
			{
                return root.Rates.GBP;
			}
            else
            {
				return root.Rates.EUR;
			}
		}

        return 0;
    }
}
