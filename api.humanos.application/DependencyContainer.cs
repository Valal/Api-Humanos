using api.humanos.application.Interfaces.Presenters;
using api.humanos.application.Mapper;
using api.humanos.application.Presenters;
using Microsoft.Extensions.DependencyInjection;

namespace api.humanos.application;

public static class DependencyContainer
{
    public static IServiceCollection AddApplication(this IServiceCollection service){
        service.AddAutoMapper(typeof(AutoMapperProfile));
        service.AddScoped<IHumanosPresenter, HumanosPresenter>();
        service.AddScoped<ICalculadoraPresenter, CalculadoraPresenter>();
        return service;
    }
}
