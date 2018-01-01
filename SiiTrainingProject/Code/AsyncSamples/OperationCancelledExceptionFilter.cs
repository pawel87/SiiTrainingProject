using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiiTrainingProject.Code.AsyncSamples
{
    public class OperationCancelledExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger logger;

        public OperationCancelledExceptionFilter(ILoggerFactory loggerFactory)
        {
            logger = loggerFactory.CreateLogger<OperationCancelledExceptionFilter>();
        }

        public override void OnException(ExceptionContext context)
        {
            if(context.Exception is OperationCanceledException)
            {
                //optional...
                logger.LogInformation("Handled cancelled request");

                context.ExceptionHandled = true;
                context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
        }

    }
}
