using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using SiiTrainingProject.Code.AsyncSamples;
using System.Collections.Generic;

namespace SiiTrainingProject.Controllers
{
    [Route("api/[controller]")]
    [ApiExplorerSettings(IgnoreApi = false, GroupName = nameof(AsyncSampleController))]
    public class AsyncSampleController : Controller
    {
        private readonly ILogger logger;
        private readonly ReportGenerator reportGenerator;

        public AsyncSampleController(ILogger<AsyncSampleController> logger, ILoggerFactory loggerFactory)
        {
            this.logger = logger;
            reportGenerator = new ReportGenerator(loggerFactory);
        }

        [HttpGet("report")]
        public async Task<string> Report()
        {
            logger.LogInformation("Begin request - generate report...");

            //await Task.Delay(TimeSpan.FromSeconds(10));
            await reportGenerator.GenerateReportAsync();

            var messageDone = "Request finished. Report is ready to download";

            logger.LogInformation(messageDone);

            return messageDone;
        }

        [HttpGet("reportv2")]
        public async Task<string> ReportVersion2(CancellationToken cancellationToken)
        {
            logger.LogInformation("Begin request - generate report...");

            //await Task.Delay(TimeSpan.FromSeconds(10), cancellationToken);
            await reportGenerator.GenerateReportAsync(cancellationToken);

            var messageDone = "Request finished. Report is ready to download";

            logger.LogInformation(messageDone);

            return messageDone;
        }

        [HttpGet("list.{format}"), FormatFilter]
        public List<string> GetList()
        {
            return new List<string> { "lorem", "ipsum", "dolor" };
        }

    }
}