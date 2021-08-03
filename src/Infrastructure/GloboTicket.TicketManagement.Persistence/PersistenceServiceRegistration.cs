using GloboTicket.TicketManagement.Application.Contracts;
using GloboTicket.TicketManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace GloboTicket.TicketManagement.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            var builder = new NpgsqlConnectionStringBuilder(configuration.GetConnectionString("DefaultConnection"));

            builder.Username = builder.Username ?? configuration["Connection:DefaultConnection:UserId"];
            builder.Password = builder.Password ?? configuration["Connection:DefaultConnection:Password"];

            services.AddDbContext<GloboTicketDbContext>(options => options.UseNpgsql(builder.ConnectionString));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            return services;
        }

    }
}