using api.humanos.application.Interfaces.Infraestructura;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using api.humanos.infrastructure.BdServices;
using api.humanos.infrastructure.Repositories;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;

namespace api.humanos.infrastructure;

public static class DependencyContainer
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection service, IConfiguration configuration){
        service.AddDbContext<HumanosDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("humanosDb"))
        //options.UseInMemoryDatabase("Humanos")
        );

        service.AddScoped<IHumanosRepositoryContext, HumanosRepositoryContext>();
        return service;
    }
}
