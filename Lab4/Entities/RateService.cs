using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Net.Http;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Globalization;
using Lab4.API;

namespace Lab4.Entities
{
    public class RateService : IRateService
    {
        private readonly HttpClient _client;

        public RateService(HttpClient client)
        {
            _client = client;
            //_client.BaseAddress = new Uri("https://api.nbrb.by/");
        }

        public async Task<IEnumerable<Rate>> GetRates(DateTime date)
        {
            string StringDate = date.ToString("yyyy-MM-dd");
            var rates = await _client.GetFromJsonAsync<List<Rate>>
                ($"{_client.BaseAddress}?ondate={StringDate}&periodicity=0");
            return rates;
        }
    }
}

