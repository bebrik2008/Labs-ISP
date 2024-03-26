using Microsoft.Maui.Controls;
using Lab4.API;
using Lab4.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4
{
    public partial class MainPage : ContentPage
    {
        private readonly RateService _rateService;

        public MainPage(RateService rateService)
        {
            _rateService = rateService;
            InitializeComponent();
            // Initialize default values for entry fields if necessary
            Countity.Text = "1"; // Assuming 1 is the default multiplier
            MyDatePicker.Date = DateTime.Now;
            LoadRatesAsync(1, DateTime.Now);
        }

        private async Task LoadRatesAsync(double Multiplier, DateTime date)
        {
            try
            {
                var rateTask = await _rateService.GetRates(date);
                List<Rate> rateList = rateTask.ToList();
                Ruble.Text = $"Российский рубль: {Multiplier * (double)(rateList.FirstOrDefault(r => r.Cur_ID == 21)?.Cur_OfficialRate / 100)}";
                Euro.Text = $"Евро: {Multiplier * (double)(rateList.FirstOrDefault(r => r.Cur_ID == 292)?.Cur_OfficialRate)}"; // Assuming Euro Cur_ID is 292
                USD.Text = $"Доллар США: {Multiplier * (double)(rateList.FirstOrDefault(r => r.Cur_ID == 145)?.Cur_OfficialRate)}"; // Assuming USD Cur_ID is 145
                Swlnd.Text = $"Швейцарский франк: {Multiplier * (double)(rateList.FirstOrDefault(r => r.Cur_ID == 23)?.Cur_OfficialRate)}";
                China.Text = $"Китайский юань: {Multiplier * (double)(rateList.FirstOrDefault(r => r.Cur_ID == 156)?.Cur_OfficialRate / 10)}"; // Assuming Chinese yuan Cur_ID is 156
                UK.Text = $"Фунт стерлинг: {Multiplier * (double)(rateList.FirstOrDefault(r => r.Cur_ID == 143)?.Cur_OfficialRate)}"; // Assuming UK pound Cur_ID is 143
            }
            catch (Exception ex)
            {
                // Handle exceptions properly, like logging or showing error message
                Console.WriteLine($"Error loading rates: {ex.Message}");
            }
        }

        private async void OnEnterClicked(object sender, EventArgs e)
        {
            try
            {
                DateTime date = MyDatePicker.Date;
                double multiplier = Convert.ToDouble(Countity.Text);
                await LoadRatesAsync(multiplier, date);
            }
            catch (FormatException)
            {
                // Handle invalid input for multiplier
                Console.WriteLine("Invalid input for multiplier.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
