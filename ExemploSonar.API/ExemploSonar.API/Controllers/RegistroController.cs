using AutoMapper;
using ExemploSonar.API.DTOs.Requests;
using ExemploSonar.API.DTOs.Responses;
using ExemploSonar.API.Entities;
using ExemploSonar.API.Interfaces.Services;
using ExemploSonar.API.Services.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ExemploSonar.API.Controllers
{
    [ApiController]
    [Route("registros")]
    public class RegistroController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRegistroService _service;
        public RegistroController(IRegistroService service,
            IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Registra as informações de uma nova pessoa.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Os dados cadastrados ou erros.</returns>
        /// <response code="201">Sucesso na criação.</response>
        /// <response code="400">Dados de entrada inválidos.</response>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(RegistroResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ServiceResponse<Registro>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ArmazenarRegistro([FromBody] RegistroRequest request)
        {

            var serviceResponse = await _service.ArmazenarRegistro(_mapper.Map<Registro>(request));

            if (serviceResponse.HasErrors()) return BadRequest(serviceResponse.Erros);
           

            return CreatedAtAction(nameof(RecuperarRegistroPorId), new { Id = serviceResponse.ResponseData.Id },
                _mapper.Map<RegistroResponse>(serviceResponse.ResponseData));
        }

        /// <summary>
        /// Retorna os dados do cadastro vinculado ao Id informado.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>O Registro buscado.</returns>
        /// <response code="200">Sucesso na Busca.</response>
        /// <response code="404">Registro não encontrado.</response>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(RegistroResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(EmptyResult), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RegistroResponse>> RecuperarRegistroPorId(int id)
        {
            var serviceResponse = await _service.RecuperarRegistroPorId(id);

            if (serviceResponse.Erros.ContainsKey("NotFound")) return NotFound();
            
            return Ok(_mapper.Map<RegistroResponse>(serviceResponse.ResponseData));
        }
    }
}
