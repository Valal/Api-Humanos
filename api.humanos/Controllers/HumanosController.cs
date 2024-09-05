using System.Net;
using System.Net.Mime;
using api.humanos.application.Interfaces.Presenters;
using api.humanos.domain.DTOs.Request;
using Microsoft.AspNetCore.Mvc;

namespace api.humanos.Controller;

    [ApiController]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public class HumanosController : ControllerBase
    {
        private readonly IHumanosPresenter _h;
        public HumanosController(IHumanosPresenter humanos){
            _h = humanos;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [Route("/api/[controller]")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _h.Get());
        }

        [HttpGet]
        [Route("/api/[controller]/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get(int? id = null){
            var result = await _h.Get(id);
            return _h.errorResponse._errors.Count() > 0 ? BadRequest(_h.errorResponse) : Ok(result);
        }

        [HttpPost]
        [Route("/api/[controller]")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post(RequestHumanos request){
            string uri = Request.Scheme + "://" + Request.Host.Value + Request.Path.Value;
            var result = await _h.Post(request);
            return _h.errorResponse._errors.Count > 0 ? BadRequest(_h.errorResponse) : Created("", result);
        }
        
        [HttpPut]
        [Route("/api/[controller]")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put(RequestPutHumanos request){
            string uri = Request.Scheme + "://" + Request.Host.Value + Request.Path.Value;
            var result = await _h.Put(request);
            return _h.errorResponse._errors.Count > 0 ? BadRequest(_h.errorResponse) : Created("", result);
        }
    }