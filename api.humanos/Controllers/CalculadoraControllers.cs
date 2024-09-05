using System.Net.Mime;
using api.humanos.application.Interfaces.Presenters;
using api.humanos.domain.DTOs.Request;
using Microsoft.AspNetCore.Mvc;

namespace api.humanos.Controller;

    [ApiController]
    [Route("/api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class CalculadoraController : ControllerBase
    {
        private readonly ICalculadoraPresenter _calculadora;
        public CalculadoraController(ICalculadoraPresenter calculadora){
            _calculadora = calculadora;
        }

        [HttpGet]
        public async Task<IActionResult> Get(){

            Dictionary<string, string> headers = Request.Headers.ToDictionary(a => a.Key, a => string.Join(";", a.Value));
            CalculadoraRequest calcular = new CalculadoraRequest(){
                operador1 = Convert.ToDouble(headers["operador1"]),
                operador2 = Convert.ToDouble(headers["operador2"]),
                operando = headers["operando"]
            };
            var result = await _calculadora.Calcular(calcular);
            return _calculadora.errorResponse._errors.Count > 0 ? BadRequest(_calculadora.errorResponse) : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CalculadoraRequest operacion){
            var result = await _calculadora.Calcular(operacion);
            return _calculadora.errorResponse._errors.Count > 0 ? BadRequest(_calculadora.errorResponse) : Ok(result);
        }
    }