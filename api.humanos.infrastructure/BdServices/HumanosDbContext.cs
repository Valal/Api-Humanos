using api.humanos.domain.POCOS.Context;
using Microsoft.EntityFrameworkCore;

namespace api.humanos.infrastructure.BdServices;

public class HumanosDbContext : DbContext{
    public HumanosDbContext(DbContextOptions options) : base(options){}
    public DbSet<HumanosModel> Humanos {get;set;}
}