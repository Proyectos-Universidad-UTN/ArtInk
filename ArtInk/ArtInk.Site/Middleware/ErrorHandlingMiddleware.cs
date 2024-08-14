using ArtInk.Site.Models;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace ArtInk.Site.Middleware;

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

            str.AppendLine();
            str.AppendFormat("EventId :{0}\n", eventId);
            string listMessages = string.Join(",", result.ListMessages);
            str.AppendFormat("ErrorList :{0}\n", listMessages);
            str.AppendFormat("StackTrace :{0}\n", ex.StackTrace);
            messagesJson = JsonConvert.SerializeObject(result);
            context.Items["ErrorMessagesJson"] = messagesJson;
            _logger.LogError("{0}", str.ToString());

            var artInkException = ex as ArtInkApiClientException;

            await HandleErrorAsync(context, artInkException!.HttpStatusCode);
        }
    }

    private static async Task HandleErrorAsync(HttpContext context, HttpStatusCode httpStatusCode)
    {
        string redirectUrl = $"/Home/Error";
        if(httpStatusCode == HttpStatusCode.Forbidden)
        {
            redirectUrl = $"/Home?errorCode=1";
        }
        if(httpStatusCode == HttpStatusCode.Unauthorized)
        {
            redirectUrl = $"/Home/InicioSesion?errorCode=2";
        }
        context.Response.Redirect(redirectUrl);

        await Task.FromResult(1);
    }
}