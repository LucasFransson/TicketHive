﻿using System;
using TicketHive.Server.Models;

namespace TicketHive.Server.StaticMethods
{
    public static class DataSeeder
    {
        // A List of all Countries in the Database
        public static List<CountryModel> Countries = new List<CountryModel>
        {
            new CountryModel { Name = "Afghanistan", Currency = "AFN", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Albania", Currency = "ALL", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Algeria", Currency = "DZD", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Andorra", Currency = "EUR", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Angola", Currency = "AOA", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Antigua and Barbuda", Currency = "XCD", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Argentina", Currency = "ARS", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Armenia", Currency = "AMD", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Australia", Currency = "AUD", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Austria", Currency = "EUR", IsAvailableForUserRegistration = true },
            new CountryModel { Name = "Azerbaijan", Currency = "AZN", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Bahamas", Currency = "BSD", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Bahrain", Currency = "BHD", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Bangladesh", Currency = "BDT", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Barbados", Currency = "BBD", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Belarus", Currency = "BYN", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Belgium", Currency = "EUR", IsAvailableForUserRegistration = true },
            new CountryModel { Name = "Belize", Currency = "BZD", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Benin", Currency = "XOF", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Bhutan", Currency = "BTN", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Bolivia", Currency = "BOB", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Bosnia and Herzegovina", Currency = "BAM", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Botswana", Currency = "BWP", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Brazil", Currency = "BRL", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Brunei", Currency = "BND", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Bulgaria", Currency = "BGN", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Burkina Faso", Currency = "XOF", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Burundi", Currency = "BIF", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Cambodia", Currency = "KHR", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Cameroon", Currency = "XAF", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Canada", Currency = "CAD", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Cape Verde", Currency = "CVE", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Central African Republic", Currency = "XAF", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Chad", Currency = "XAF", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Chile", Currency = "CLP", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "China", Currency = "CNY", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Colombia", Currency = "COP", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Comoros", Currency = "KMF", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Congo, Democratic Republic of the", Currency = "CDF", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Congo, Republic of the", Currency = "XAF", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Costa Rica", Currency = "CRC", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Croatia", Currency = "HRK", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Cuba", Currency = "CUP", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Cyprus", Currency = "EUR", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Czech Republic", Currency = "CZK", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Denmark", Currency = "DKK", IsAvailableForUserRegistration = true },
            new CountryModel { Name = "Djibouti", Currency = "DJF", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Dominica", Currency = "XCD", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Dominican Republic", Currency = "DOP", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "East Timor (Timor-Leste)", Currency = "USD", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Ecuador", Currency = "USD", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Egypt", Currency = "EGP", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "El Salvador", Currency = "USD", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Equatorial Guinea", Currency = "XAF", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Eritrea", Currency = "ERN", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Estonia", Currency = "EUR", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Eswatini (formerly Swaziland)", Currency = "SZL", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Ethiopia", Currency = "ETB", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Fiji", Currency = "FJD", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Finland", Currency = "EUR", IsAvailableForUserRegistration = true },
            new CountryModel { Name = "France", Currency = "EUR", IsAvailableForUserRegistration = true },
            new CountryModel { Name = "Gabon", Currency = "XAF", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Gambia", Currency = "GMD", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Georgia", Currency = "GEL", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Germany", Currency = "EUR", IsAvailableForUserRegistration = true },
            new CountryModel { Name = "Ghana", Currency = "GHS", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Greece", Currency = "EUR", IsAvailableForUserRegistration = true },
            new CountryModel { Name = "Grenada", Currency = "XCD", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Guatemala", Currency = "GTQ", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Guinea", Currency = "GNF", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Guinea-Bissau", Currency = "XOF", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Guyana", Currency = "GYD", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Haiti", Currency = "HTG", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Honduras", Currency = "HNL", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Hungary", Currency = "HUF", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Iceland", Currency = "ISK", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "India", Currency = "INR", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Indonesia", Currency = "IDR", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Iran", Currency = "IRR", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Iraq", Currency = "IQD", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Ireland", Currency = "EUR", IsAvailableForUserRegistration = true },
            new CountryModel { Name = "Israel", Currency = "ILS", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Italy", Currency = "EUR", IsAvailableForUserRegistration = true },
            new CountryModel { Name = "Jamaica", Currency = "JMD", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Japan", Currency = "JPY", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Jordan", Currency = "JOD", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Kazakhstan", Currency = "KZT", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Kenya", Currency = "KES", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Kiribati", Currency = "AUD", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Kyrgyzstan", Currency = "KGS", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Laos", Currency = "LAK", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Latvia", Currency = "EUR", IsAvailableForUserRegistration = true },
            new CountryModel { Name = "Lebanon", Currency = "LBP", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Lesotho", Currency = "LSL", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Liberia", Currency = "LRD", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Libya", Currency = "LYD", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Liechtenstein", Currency = "CHF", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Lithuania", Currency = "EUR", IsAvailableForUserRegistration = true },
            new CountryModel { Name = "Luxembourg", Currency = "EUR", IsAvailableForUserRegistration = true },
            new CountryModel { Name = "Madagascar", Currency = "MGA", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Malawi", Currency = "MWK", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Malaysia", Currency = "MYR", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Maldives", Currency = "MVR", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Mali", Currency = "XOF", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Malta", Currency = "EUR", IsAvailableForUserRegistration = true },
            new CountryModel { Name = "Marshall Islands", Currency = "USD", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Mauritania", Currency = "MRU", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Mauritius", Currency = "MUR", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Mexico", Currency = "MXN", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Micronesia", Currency = "USD", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Moldova", Currency = "MDL", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Monaco", Currency = "EUR", IsAvailableForUserRegistration = true },
            new CountryModel { Name = "Mongolia", Currency = "MNT", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Montenegro", Currency = "EUR", IsAvailableForUserRegistration = true },
            new CountryModel { Name = "Morocco", Currency = "MAD", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Mozambique", Currency = "MZN", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Myanmar (formerly Burma)", Currency = "MMK", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Namibia", Currency = "NAD", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Nauru", Currency = "AUD", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Nepal", Currency = "NPR", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Netherlands", Currency = "EUR", IsAvailableForUserRegistration = true },
            new CountryModel { Name = "New Zealand", Currency = "NZD", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Nicaragua", Currency = "NIO", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Niger", Currency = "XOF", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Nigeria", Currency = "NGN", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "North Korea", Currency = "KPW", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "North Macedonia (formerly Macedonia)", Currency = "MKD", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Norway", Currency = "NOK", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Oman", Currency = "OMR", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Pakistan", Currency = "PKR", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Palau", Currency = "USD", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Palestine", Currency = "ILS", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Panama", Currency = "PAB", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Papua New Guinea", Currency = "PGK", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Paraguay", Currency = "PYG", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Peru", Currency = "PEN", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Philippines", Currency = "PHP", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Poland", Currency = "PLN", IsAvailableForUserRegistration = true },
            new CountryModel { Name = "Portugal", Currency = "EUR", IsAvailableForUserRegistration = true },
            new CountryModel { Name = "Qatar", Currency = "QAR", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Romania", Currency = "RON", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Russia", Currency = "RUB", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Rwanda", Currency = "RWF", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Saint Kitts and Nevis", Currency = "XCD", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Saint Lucia", Currency = "XCD", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Saint Vincent and the Grenadines", Currency = "XCD", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Samoa", Currency = "WST", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "San Marino", Currency = "EUR", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Sao Tome and Principe", Currency = "STD", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Saudi Arabia", Currency = "SAR", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Senegal", Currency = "XOF", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Serbia", Currency = "RSD", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Seychelles", Currency = "SCR", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Sierra Leone", Currency = "SLL", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Singapore", Currency = "SGD", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Slovakia", Currency = "EUR", IsAvailableForUserRegistration = true },
            new CountryModel { Name = "Slovenia", Currency = "EUR", IsAvailableForUserRegistration = true },
            new CountryModel { Name = "Solomon Islands", Currency = "SBD", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Somalia", Currency = "SOS", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "South Africa", Currency = "ZAR", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "South Korea", Currency = "KRW", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "South Sudan", Currency = "SSP", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Spain", Currency = "EUR", IsAvailableForUserRegistration = true },
            new CountryModel { Name = "Sri Lanka", Currency = "LKR", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Sudan", Currency = "SDG", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Suriname", Currency = "SRD", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Sweden", Currency = "SEK", IsAvailableForUserRegistration = true },
            new CountryModel { Name = "Switzerland", Currency = "CHF", IsAvailableForUserRegistration = true },
            new CountryModel { Name = "Syria", Currency = "SYP", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Taiwan", Currency = "TWD", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Tajikistan", Currency = "TJS", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Tanzania", Currency = "TZS", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Thailand", Currency = "THB", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Togo", Currency = "XOF", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Tonga", Currency = "TOP", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Trinidad and Tobago", Currency = "TTD", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Tunisia", Currency = "TND", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Turkey", Currency = "TRY", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Turkmenistan", Currency = "TMT", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Tuvalu", Currency = "AUD", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Uganda", Currency = "UGX", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Ukraine", Currency = "UAH", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "United Arab Emirates", Currency = "AED", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "United Kingdom", Currency = "GBP", IsAvailableForUserRegistration = true },
            new CountryModel { Name = "United States of America", Currency = "USD", IsAvailableForUserRegistration = true },
            new CountryModel { Name = "Uruguay", Currency = "UYU", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Uzbekistan", Currency = "UZS", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Vanuatu", Currency = "VUV", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Vatican City (Holy See)", Currency = "EUR", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Venezuela", Currency = "VES", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Vietnam", Currency = "VND", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Yemen", Currency = "YER", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Zambia", Currency = "ZMW", IsAvailableForUserRegistration = false },
            new CountryModel { Name = "Zimbabwe", Currency = "ZWL", IsAvailableForUserRegistration = false }
        };

        // A List of all Event Types in the Database
        public static List<EventTypeModel> EventTypes = new()
        {
            new EventTypeModel() { Name = "Music Concerts"},
			new EventTypeModel() { Name = "Sports Events"},
			new EventTypeModel() { Name = "Musicals"},
			new EventTypeModel() { Name = "Food and wine tastings"},
			new EventTypeModel() { Name = "Festivals"},
			new EventTypeModel() { Name = "Conferences and trade shows"},
			new EventTypeModel() { Name = "Comedy shows"},
		};

        // Method for creating seed data for an Event
        public static void AddData(int eventId,
                                      string countryName,
                                      string eventName,
                                      string eventDescription,
                                      int eventMaxUsers,
                                      int eventPrice,
                                      DateTime eventStart,
                                      DateTime eventEnd,
                                      string eventType,
                                      List<EventModel> eventsList,
                                      List<TicketModel> ticketsList)
        {
            // Get the Country from string input (name)
            CountryModel selectedCountry = Countries.First(c => c.Name == countryName);

            // Get the EventType from string input (name)
            EventTypeModel selectedEventType = EventTypes.First(e => e.Name == eventType);

            // Create a new Event with the information from the input parameters
            EventModel newEvent = new EventModel
            {
                Id = eventId,
                Name = eventName,
                Description = eventDescription,
                ImageString = $"MicrosoftTeams-image ({new Random().Next(1, 25)}).png",
                MaxUsers = eventMaxUsers,
                Price = eventPrice,
                StartTime = eventStart,
                EndTime = eventEnd,
                SoldTickets = null,
                CountryName = countryName,
                EventTypeName = eventType,
            };
            eventsList.Add(newEvent);   // Add the Event to list of Events

            // Create as many tickets as the value of 'MaxUsers' in the Event 
            for (int i = 1; i <= newEvent.MaxUsers; i++)
            {
                var ticket = new TicketModel
                {  
                    //Id = i,
                    Id = GuidGenerator.GenerateInt(),
                    EventId = newEvent.Id,
                    Price = newEvent.Price,
                    StartTime = newEvent.StartTime,
                    EndTime = newEvent.EndTime
                };

                ticketsList.Add(ticket);    // Add each Ticket to the list of Tickets
            }
        }
    }
}
