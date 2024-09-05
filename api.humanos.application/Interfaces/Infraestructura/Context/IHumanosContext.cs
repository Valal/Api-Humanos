using api.humanos.domain.DTOs.Request;
using api.humanos.domain.DTOs.Responses;
using api.humanos.domain.POCOS.Context;
using api.humanos.domain.POCOS.Entities;

namespace api.humanos.application.Interfaces.Infraestructura.Context;

public interface IHumanosContext{
    public HumanosModel Get(int? id = null);
    public IEnumerable<HumanosModel> Get();
    public Task<bool> Post(RequestHumanos request);
    public Task<bool> Put(RequestPutHumanos request);
    public bool ExisteHumano(string nombre);
    public bool ExisteHumanoPorId(int id);
}