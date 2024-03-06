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
            // �������� ��������� ������ �� Picker
            var selectedCurrency = ConvertPicker.SelectedItem as string;

            // ���������, ������� �� ������
            if (string.IsNullOrEmpty(selectedCurrency))
                return;

            // �������� ��������� ���� �� DatePicker
            var selectedDate = MyDatePicker.Date;

            try
            {
                // �������� ����� ����� �� ��������� ����
                var rates = await _rateService.GetRates(selectedDate);

                // ������� ������ �������� CurrencyRateViewModel ��� ����������� � CollectionView
                var currencyRates = new List<CurrencyRateViewModel>();

                // ��������� ������ � ������ ����� � ������
                foreach (var rate in rates)
                {
                    currencyRates.Add(new CurrencyRateViewModel
                    {
                        Currency = rate.Cur_Abbreviation,
                        Rate = rate.Cur_OfficialRate ?? 0
                    });
                }

                // ������������� �������� ������ ��� CollectionView
                CurrencyRatesCollectionView.ItemsSource = currencyRates;
            }
            catch (Exception ex)
            {
                // ��������� ������, ���� ��������� �������� ��� ��������� ������ �����
                Console.WriteLine($"������ ��������� ������ �����: {ex.Message}");
            }
        }
    }
}
