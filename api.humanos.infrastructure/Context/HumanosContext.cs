using api.humanos.application.Interfaces.Infraestructura.Context;
using api.humanos.domain.DTOs.Request;
using api.humanos.domain.POCOS.Context;
using api.humanos.domain.POCOS.Entities;
using api.humanos.infrastructure.BdServices;
using System.Data;
using System.Net;

namespace api.humanos.infrastructure.Context;

public class HumanosContext : IHumanosContext
{
    private readonly HumanosDbContext _db;
    public HumanosContext(HumanosDbContext dbContext){
        _db = dbContext;
    }

    public IEnumerable<HumanosModel> Get() => _db.Humanos.ToList();
    public HumanosModel Get(int? id = null){
        if(_db.Humanos.Where(w => w.id == id).Select(s => s).Any())
            return _db.Humanos.Where(w => w.id == id).Select(s => s).FirstOrDefault();
        return null;
    }

    public async Task<bool> Post(RequestHumanos request){
        var humanos = _db.Set<HumanosModel>();
        
        humanos.Add(new HumanosModel(){
            nombre = request.nombre,
            edad = request.edad,
            sexo = request.sexo,
            altura = request.altura,
            peso = request.peso,
            id = humanos.Count() + 1
        });

        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Put(RequestPutHumanos request)
    {
        var humano = _db.Humanos.SingleOrDefault(h => h.id == request.id);
        humano.id = request.id;
        humano.nombre = request.nombre;
        humano.sexo = request.sexo;
        humano.edad = request.edad;
        humano.altura = request.altura;
        humano.peso = request.peso;

        await _db.SaveChangesAsync();
        return true;
    }

    public bool ExisteHumano(string nombre)
    {
        var humanos = _db.Set<HumanosModel>();
        if (humanos.Where(w => w.nombre == nombre).Select(s => s).Any())
            return true;
        return false;
    }
    public bool ExisteHumanoPorId(int id)
    {
        var humanos = _db.Set<HumanosModel>();
        if (humanos.Where(w => w.id == id).Select(s => s).Any())
            return true;
        return false;
    }
}