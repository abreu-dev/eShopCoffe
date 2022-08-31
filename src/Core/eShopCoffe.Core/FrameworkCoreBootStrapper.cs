using eShopCoffe.Core.Domain.Repositories;
using eShopCoffe.Core.Domain.Repositories.Interfaces;
using eShopCoffe.Core.Messaging.Bus;
using eShopCoffe.Core.Messaging.Bus.Interfaces;
using eShopCoffe.Core.Messaging.Dispatchers;
using eShopCoffe.Core.Messaging.Dispatchers.Interfaces;
using eShopCoffe.Core.Messaging.Handlers;
using eShopCoffe.Core.Messaging.Handlers.Interfaces;
using eShopCoffe.Core.Security;
using eShopCoffe.Core.Security.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace eShopCoffe.Core
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
