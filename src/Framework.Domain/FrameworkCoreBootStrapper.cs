using Framework.Core.Domain.Repositories;
using Framework.Core.Domain.Repositories.Interfaces;
using Framework.Core.Messaging.Bus;
using Framework.Core.Messaging.Bus.Interfaces;
using Framework.Core.Messaging.Dispatchers;
using Framework.Core.Messaging.Dispatchers.Interfaces;
using Framework.Core.Messaging.Handlers;
using Framework.Core.Messaging.Handlers.Interfaces;
using Framework.Core.Security;
using Framework.Core.Security.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.Core
{
    public static class FrameworkCoreBootStrapper
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            Bus(services);
            Dispatchers(services);
            Notifications(services);
            Session(services);
            Repositories(services);
        }

        public static void Bus(IServiceCollection services)
        {
            services.AddScoped<IBus, Bus>();
        }

        public static void Dispatchers(IServiceCollection services)
        {
            services.AddScoped<ICommandDispatcher, CommandDispatcher>();
            services.AddScoped<IQueryDispatcher, QueryDispatcher>();
            services.AddScoped<IEventDispatcher, EventDispatcher>();
        }

        public static void Notifications(IServiceCollection services)
        {
            services.AddScoped<INotificationHandler, NotificationHandler>();
        }

        public static void Session(IServiceCollection services)
        {
            services.AddScoped<ISessionAccessor, SessionAccessor>();
        }

        public static void Repositories(IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
        }
    }
}
