using api.humanos.domain.DTOs.Request;
using api.humanos.domain.DTOs.Responses;

namespace api.humanos.application.Interfaces.Presenters;

public interface IHumanosPresenter{
    public ErrorResponse errorResponse {get;set;}
    public ValueTask<dynamic> Get();
    public ValueTask<dynamic> Get(int? id = null);
    public ValueTask<dynamic> Post(RequestHumanos request);
    public ValueTask<dynamic> Put(RequestPutHumanos request);
}