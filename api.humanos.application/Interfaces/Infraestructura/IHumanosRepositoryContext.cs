using api.humanos.application.Interfaces.Infraestructura.Context;

namespace api.humanos.application.Interfaces.Infraestructura;

public interface IHumanosRepositoryContext{
    public IHumanosContext HumanosContext {get;}
}