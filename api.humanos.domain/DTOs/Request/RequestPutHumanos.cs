namespace api.humanos.domain.DTOs.Request;

public class RequestPutHumanos {
    public int id {get;set;}
    public string? nombre {get;set;}
    public string? sexo {get;set;}
    public double altura {get;set;}
    public double peso {get;set;}
    public int edad {get;set;}
    
}