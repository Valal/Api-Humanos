using System.Net;
using api.humanos.application.Interfaces.Infraestructura;
using api.humanos.application.Interfaces.Presenters;
using api.humanos.domain.DTOs;
using api.humanos.domain.DTOs.Request;
using api.humanos.domain.DTOs.Responses;
using api.humanos.domain.POCOS.Entities;
using AutoMapper;

namespace api.humanos.application.Presenters;

public class HumanosPresenter : IHumanosPresenter
{
    private readonly IHumanosRepositoryContext _db;
    private readonly IMapper _mapper;
    public ErrorResponse errorResponse {get;set;}
    public HumanosPresenter(IHumanosRepositoryContext context, IMapper mapper){
        _mapper = mapper;
        _db = context;
        errorResponse = new ErrorResponse(){ _errors = new List<Errors>() };
    }

    public async ValueTask<dynamic> Get(){
        var humanos = await Task.Run(() => _db.HumanosContext.Get());
        List<HumanosDto> dto = _mapper.Map<List<HumanosDto>>(humanos);
        return new { data = new { type = "humanos", attributes = dto } };
    }

    public async ValueTask<dynamic> Get(int? id = null){
        if(id > 0){
            var humano = _db.HumanosContext.Get(id);
            if(humano != null){
                HumanosDto dto = _mapper.Map<HumanosDto>(humano);
                return new { data = new { type = "humanos", attributes = dto } };
            }
            errorResponse._errors.Add(new Errors { detail = "No existe información de ese humano", title = "El humano no existe", code = (int)HttpStatusCode.NotFound, status = HttpStatusCode.NotFound.ToString() });
        }
        else
            errorResponse._errors.Add(new Errors {  detail = "No existe un humano con ese Id", title = "El humano no existe", code = (int)HttpStatusCode.NotFound, status = HttpStatusCode.NotFound.ToString() });
    
        return null;
    }

    public async ValueTask<dynamic> Post(RequestHumanos request){
        if(IsValidRequest(request))
        {
            if (_db.HumanosContext.ExisteHumano(request.nombre))
            {
                errorResponse._errors.Add(new Errors {  detail = "Ya existe el humano", title = "El humano ya existe", code = (int)HttpStatusCode.BadRequest, status = HttpStatusCode.BadRequest.ToString() });
                return null;
            }
            
            if (await _db.HumanosContext.Post(request))
                return new { type = "humano", attribute = new { mensaje = "Humano creado de forma exitosa."}};
        }
        return null;
    }
    public async ValueTask<dynamic> Put(RequestPutHumanos request){
        if(IsValidPutRequest(request))
        {
            if(!_db.HumanosContext.ExisteHumanoPorId(request.id))
            {
                errorResponse._errors.Add(new Errors {  detail = "No existe el humano", title = "El humano no existe", code = (int)HttpStatusCode.BadRequest, status = HttpStatusCode.BadRequest.ToString() });
                return null;
            }
            if (await _db.HumanosContext.Put(request))
                return new { type = "humano", attribute = new { mensaje = "Humano modificado de forma exitosa."}};
        }
        return null;
    }
    private bool IsValidRequest(RequestHumanos request){
        if(string.IsNullOrEmpty(request.nombre))
            errorResponse._errors.Add(new Errors {  detail = "atributo nombre vacío", title = "atributos vacíos", code = (int)HttpStatusCode.BadRequest, status = HttpStatusCode.BadRequest.ToString() });
        if(request.edad <= 0)
            errorResponse._errors.Add(new Errors {  detail = "atributo edad vacío", title = "atributos vacíos", code = (int)HttpStatusCode.BadRequest, status = HttpStatusCode.BadRequest.ToString() });
        if(string.IsNullOrEmpty(request.sexo))
            errorResponse._errors.Add(new Errors {  detail = "atributo sexo vacío", title = "atributos vacíos", code = (int)HttpStatusCode.BadRequest, status = HttpStatusCode.BadRequest.ToString() });
        if(request.altura <= 0)
            errorResponse._errors.Add(new Errors {  detail = "atributo altura vacía", title = "atributos vacíos", code = (int)HttpStatusCode.BadRequest, status = HttpStatusCode.BadRequest.ToString() });
        if(request.peso <= 0)
            errorResponse._errors.Add(new Errors {  detail = "atributo peso vacío", title = "atributos vacíos", code = (int)HttpStatusCode.BadRequest, status = HttpStatusCode.BadRequest.ToString() });

        return errorResponse._errors.Count == 0;    
    }
    private bool IsValidPutRequest(RequestPutHumanos request){
        if(string.IsNullOrEmpty(request.nombre))
            errorResponse._errors.Add(new Errors {  detail = "atributo nombre vacío", title = "atributos vacíos", code = (int)HttpStatusCode.BadRequest, status = HttpStatusCode.BadRequest.ToString() });
        if(request.edad <= 0)
            errorResponse._errors.Add(new Errors {  detail = "atributo edad vacío", title = "atributos vacíos", code = (int)HttpStatusCode.BadRequest, status = HttpStatusCode.BadRequest.ToString() });
        if(string.IsNullOrEmpty(request.sexo))
            errorResponse._errors.Add(new Errors {  detail = "atributo sexo vacío", title = "atributos vacíos", code = (int)HttpStatusCode.BadRequest, status = HttpStatusCode.BadRequest.ToString() });
        if(request.altura <= 0)
            errorResponse._errors.Add(new Errors {  detail = "atributo altura vacía", title = "atributos vacíos", code = (int)HttpStatusCode.BadRequest, status = HttpStatusCode.BadRequest.ToString() });
        if(request.peso <= 0)
            errorResponse._errors.Add(new Errors {  detail = "atributo peso vacío", title = "atributos vacíos", code = (int)HttpStatusCode.BadRequest, status = HttpStatusCode.BadRequest.ToString() });

        return errorResponse._errors.Count == 0;    
    }
}