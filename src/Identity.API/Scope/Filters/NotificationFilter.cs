using Framework.Core.Messaging.Handlers.Interfaces;
using Framework.Core.Messaging.Requests.Interfaces;
using Identity.Api.Scope.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Identity.Api.Scope.Filters
{
    public class NotificationFilter : IAsyncResultFilter
    {
        private readonly INotificationHandler _notificationHandler;

        public NotificationFilter(INotificationHandler notificationHandler)
        {
            _notificationHandler = notificationHandler;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (_notificationHandler.HasNotifications)
            {
                context.Result = GetBadRequestObjectResult(_notificationHandler.GetNotifications(), context.HttpContext.Request.Path.Value);
            }

            await next();
        }

        public BadRequestObjectResult GetBadRequestObjectResult(IEnumerable<INotification> notifications, string? instance)
        {
            var response = new BadRequestResponse(instance);

            notifications.ToList().ForEach(notification =>
            {
                response.Errors.Add(new BadRequestResponseError(notification.Key, notification.Value));
            });

            return new BadRequestObjectResult(response);
        }
    }
}
