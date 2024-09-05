using api.humanos.application.Interfaces.Infraestructura;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using api.humanos.infrastructure.BdServices;
using api.humanos.infrastructure.Repositories;

namespace api.humanos.infrastructure;

public static class DependencyContainer
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection service){
        service.AddDbContext<HumanosDbContext>(options =>
            options.UseInMemoryDatabase("Humanos")
        );

        service.AddScoped<IHumanosRepositoryContext, HumanosRepositoryContext>();
        return service;
    }
}
