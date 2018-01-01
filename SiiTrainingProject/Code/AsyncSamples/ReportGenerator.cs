using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SiiTrainingProject.Code.AsyncSamples
{
    public class ReportGenerator
    {
        private readonly ILogger logger;

        public ReportGenerator(ILoggerFactory loggerFactory)
        {
            this.logger = loggerFactory.CreateLogger<ReportGenerator>();
        }

        public async Task GenerateReportAsync()
        {
            for(var i = 0; i < 10; i++)
            {
                //do some work
                logger.LogInformation($"Iteration {i}...");
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
        }

        public async Task GenerateReportAsync(CancellationToken cancellationToken)
        {
            for (var i = 0; i < 10; i++)
            {
                cancellationToken.ThrowIfCancellationRequested();

                //do some work
                logger.LogInformation($"Iteration {i}...");
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
        }
    }
}
