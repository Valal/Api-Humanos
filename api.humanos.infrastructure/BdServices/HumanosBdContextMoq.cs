using api.humanos.domain.POCOS.Context;
using api.humanos.extension.Utilities.Helper;

namespace api.humanos.infrastructure.BdServices;

public class HumanosDbContextMoq{
    public HumanosDbContextMoq(HumanosDbContext context){
        if(!context.Humanos.Any()){
            context.Humanos.AddRange(Seed.SeedData<HumanosModel>("Humanos.json", "Seeds", true));
        }

        context.SaveChanges();
    }
}