using System;
using System.Threading;
using System.Threading.Tasks;
using ISP_LAB_1_Lavriv_Ivan.Lab2;
using Microsoft.Maui.Controls;

namespace ISP_LAB_1_Lavriv_Ivan
{
    public partial class Progress : ContentPage
    {
        private IntegralSin integralsin;
        private CancellationTokenSource cancellationTokenSource;
        public Progress()
        {
            InitializeComponent();
            integralsin = new IntegralSin();
            cancellationTokenSource = new CancellationTokenSource();

        }

        private async void OnStartClicked(object sender, EventArgs e)
        {
            ProgressBar progress = this.FindByName("Bar") as ProgressBar;
            Label label = this.FindByName("StatusInfo") as Label;
            label.Text = "Вычисление...";

            Progress<double> progressReporter = new Progress<double>(value =>
            {
                ProgressInfo.Text = $"Процент вычисления: {value * 100:0.##}%";
                progress.Progress = value;
            });

            try
            {
                double result = await integralsin.CalculateIntegralAsync(progressReporter, cancellationTokenSource.Token);
                label.Text = $"Результат: {result}";
            }
            catch (OperationCanceledException)
            {
                label.Text = "Задание отменено";
            }
        }

        private void OnCancelClicked(object sender, EventArgs e) { 
        
            cancellationTokenSource.Cancel();
        }
    }
}
