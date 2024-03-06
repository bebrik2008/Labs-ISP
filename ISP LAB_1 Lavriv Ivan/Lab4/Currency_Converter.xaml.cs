using System;

namespace ISP_LAB_1_Lavriv_Ivan
{
    public partial class Currency_Converter : ContentPage
    {
        private readonly IRateService _rateService;

        public Currency_Converter(IRateService rateService)
        {
            InitializeComponent();
            _rateService = rateService;
        }

        public class CurrencyRateViewModel
        {
            public string Currency { get; set; }
            public decimal Rate { get; set; }
        }

        private async void OnConvertPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            // Получаем выбранную валюту из Picker
            var selectedCurrency = ConvertPicker.SelectedItem as string;

            // Проверяем, выбрана ли валюта
            if (string.IsNullOrEmpty(selectedCurrency))
                return;

            // Получаем выбранную дату из DatePicker
            var selectedDate = MyDatePicker.Date;

            try
            {
                // Получаем курсы валют на выбранную дату
                var rates = await _rateService.GetRates(selectedDate);

                // Создаем список объектов CurrencyRateViewModel для отображения в CollectionView
                var currencyRates = new List<CurrencyRateViewModel>();

                // Добавляем данные о курсах валют в список
                foreach (var rate in rates)
                {
                    currencyRates.Add(new CurrencyRateViewModel
                    {
                        Currency = rate.Cur_Abbreviation,
                        Rate = rate.Cur_OfficialRate ?? 0
                    });
                }

                // Устанавливаем источник данных для CollectionView
                CurrencyRatesCollectionView.ItemsSource = currencyRates;
            }
            catch (Exception ex)
            {
                // Обработка ошибок, если возникают проблемы при получении курсов валют
                Console.WriteLine($"Ошибка получения курсов валют: {ex.Message}");
            }
        }
    }
}
