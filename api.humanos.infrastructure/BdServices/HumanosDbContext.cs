using api.humanos.domain.POCOS.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace api.humanos.infrastructure.BdServices;

public class HumanosDbContext : DbContext
{
    private readonly IConfiguration config;
    public HumanosDbContext(DbContextOptions options, IConfiguration configuration) : base(options){
        config = configuration;
    }
    public DbSet<HumanosModel> Humanos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HumanosModel>(entity =>
        {

            entity.ToTable("Humanos");
            entity.HasKey(p => p.id).HasName("PK_User");

            entity.Property(p => p.id)

                    .HasColumnName("id")

                    .HasColumnType("int").ValueGeneratedNever();

            entity.Property(p => p.nombre).HasColumnName("nombre").HasColumnType("string");
            entity.Property(p => p.sexo).HasColumnName("sexo").HasColumnType("string");
            entity.Property(p => p.altura).HasColumnName("altura").HasColumnType("double");
            entity.Property(p => p.peso).HasColumnName("peso").HasColumnType("double");
            entity.Property(p => p.edad).HasColumnName("edad").HasColumnType("int");
        });
    }
}