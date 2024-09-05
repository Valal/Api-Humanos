using System.ComponentModel.DataAnnotations;

namespace api.humanos.domain.POCOS.Context;

public class HumanosModel
{
        [Key]
        public int id {get;set;}
        public string? nombre {get;set;}
        public string? sexo {get;set;}
        public int edad {get;set;}
        public double altura {get;set;}
        public double peso {get;set;}
}