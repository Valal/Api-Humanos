using api.humanos.application.Interfaces.Infraestructura;
using api.humanos.application.Interfaces.Infraestructura.Context;
using api.humanos.infrastructure.BdServices;
using api.humanos.infrastructure.Context;


namespace api.humanos.infrastructure.Repositories;

public class HumanosRepositoryContext : IHumanosRepositoryContext
{
    private HumanosDbContext _humanosDB;
    private HumanosDbContextMoq _humanosMoq;
    public HumanosRepositoryContext(HumanosDbContext humanosDb){
        _humanosDB = humanosDb;
        _humanosMoq = new HumanosDbContextMoq(_humanosDB);
    }

    public IHumanosContext HumanosContext => new HumanosContext(_humanosDB);
}