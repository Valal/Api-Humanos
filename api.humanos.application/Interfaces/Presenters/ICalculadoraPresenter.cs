using api.humanos.domain.DTOs.Request;
using api.humanos.domain.DTOs.Responses;

namespace api.humanos.application.Interfaces.Presenters;

public interface ICalculadoraPresenter
{
    public ErrorResponse errorResponse {get;set;}
    public Task<dynamic> Calcular(CalculadoraRequest calcular);
}