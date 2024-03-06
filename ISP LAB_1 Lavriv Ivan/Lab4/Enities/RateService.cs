using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ISP_LAB_1_Lavriv_Ivan
{
    public class RateService : IRateService
    {
        private readonly HttpClient _httpClient;

        public RateService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Rate>> GetRates(DateTime date)
        {
            var dateString = date.ToString("MM-dd-yyyy");
            var response = await _httpClient.GetFromJsonAsync<Rate[]>($"https://www.nbrb.by/api/exrates/rates?ondate={dateString}");

            return response;
        }
    }
}
