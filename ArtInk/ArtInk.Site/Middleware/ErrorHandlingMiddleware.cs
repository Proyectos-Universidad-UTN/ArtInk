using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtInk.web.Middleware
{
    public class ErrorMiddlewareViewModel
    {
        public string Path { get; set; } = default!;
        public List<string> ListMessages { get; set; } = default!;
        public string IdEvent { get; set; } = default!;
    }

    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            string messagesJson, routeWhereExceptionOccured, eventId, path = "";
            StringBuilder str = new StringBuilder();
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                routeWhereExceptionOccured = context.Request.Path;
                path = JsonConvert.SerializeObject(routeWhereExceptionOccured);
                // Create Random IdEvent
                Random random = new Random();
                eventId = random.Next(1, 5000).ToString("######") + "-" + DateTime.Now.ToString("yyMMddhhmmss");
                ErrorMiddlewareViewModel result = new ErrorMiddlewareViewModel
                {
                    Path = path,
                    IdEvent = eventId
                };
                if (ex is AggregateException ae)
                {
                    result.ListMessages = ae.InnerExceptions.Select(e => e.Message).ToList();
                }
                else
                {
                    string messages = ex.Message;
                    result.ListMessages = new List<string> { messages };
                }

                str.AppendFormat("\n");
                str.AppendFormat("EventId :{0}\n", eventId);
                str.AppendFormat("ErrorList :{0}\n", string.Join(",", result.ListMessages));
                str.AppendFormat("StackTrace :{0}\n", ex.StackTrace);
                messagesJson = JsonConvert.SerializeObject(result);
                context.Items["ErrorMessagesJson"] = messagesJson;
                _logger.LogError(str.ToString());
                await HandleErrorAsync(context);
            }
        }

        private static async Task HandleErrorAsync(HttpContext context)
        {
            string redirectUrl = $"/Home/Error";
            context.Response.Redirect(redirectUrl);
            
            await Task.FromResult(1);
        }
    }
}