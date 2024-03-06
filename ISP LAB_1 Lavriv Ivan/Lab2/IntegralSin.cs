using System;
using System.Threading;
using System.Threading.Tasks;

namespace ISP_LAB_1_Lavriv_Ivan.Lab2
{
    public class IntegralSin
    {
        public async Task<double> CalculateIntegralAsync(IProgress<double> progress, CancellationToken cancellationToken)
        {
            const double step = 0.0001; 
            double sum = 0.0;
            int totalSteps = (int)(1.0 / step);
            int completedSteps = 0;

            for (double x = 0.0; x < 1.0; x += step)
            {
                cancellationToken.ThrowIfCancellationRequested();

                double y = Math.Sin(x);
                double rectangleArea = y * step;
                sum += rectangleArea;

                completedSteps++;
                double currentProgress = (double)completedSteps / totalSteps;

                progress.Report(currentProgress);

                await Task.Delay(1); 
            }

            return sum;
        }
    }
}
