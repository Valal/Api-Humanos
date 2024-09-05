using System.Net;
using api.humanos.application.Interfaces.Presenters;
using api.humanos.domain.DTOs.Request;
using api.humanos.domain.DTOs.Responses;
using api.humanos.domain.POCOS.Entities;

namespace api.humanos.application.Presenters;

public class CalculadoraPresenter : ICalculadoraPresenter
{
    public ErrorResponse errorResponse {get;set;}
    public CalculadoraPresenter(){
        errorResponse = new ErrorResponse(){ _errors = new List<Errors>() };
    }

    public async Task<dynamic> Calcular(CalculadoraRequest calcular)
    {
        double result = 0;
        switch(calcular.operando){
            case "+": result = await Task.Run(() => Suma(calcular.operador1, calcular.operador2)); break;
            case "-": result = await Task.Run(() => Resta(calcular.operador1, calcular.operador2)); break;
            case "*": result = await Task.Run(() => Multiplicacion(calcular.operador1, calcular.operador2)); break;
            case "/": result = await Task.Run(() => Division(calcular.operador1, calcular.operador2)); break;
            default:  errorResponse._errors.Add(new Errors {  detail = "No es posible realizar alguna operación disponible", title = "Operación no disponible", code = (int)HttpStatusCode.NotFound, status = HttpStatusCode.NotFound.ToString() }); break;
        }

        if(errorResponse._errors.Count == 0)
            return new { type = "Calculadora", attributes = new { expresion = calcular.operador1.ToString()+" "+calcular.operando+" "+calcular.operador2.ToString()+" = "+result.ToString(),  resultado = result }};
        return null;
    }

    private double Suma(double operador1, double operador2) => operador1 + operador2;
    private double Resta(double operador1, double operador2) => operador1 - operador2;
    private double Multiplicacion(double operador1, double operador2) => operador1 * operador2;
    private double Division(double operador1, double operador2){
        if(operador1 == 0)
        {
            errorResponse._errors.Add(new Errors {  detail = "Resultado infinito agregar un valor mayor a cero", title = "Operación no disponible", code = (int)HttpStatusCode.NotFound, status = HttpStatusCode.NotFound.ToString() });
            return 0;
        }    
        return operador1 / operador2;
    } 
}