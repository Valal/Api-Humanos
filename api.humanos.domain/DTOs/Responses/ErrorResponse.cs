using api.humanos.domain.POCOS.Entities;

namespace api.humanos.domain.DTOs.Responses;

public class ErrorResponse{
    public List<Errors> _errors {get;set;}
}