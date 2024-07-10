using Application.Commands.Fornecedores.CreateFornecedor;
using Application.Commands.Fornecedores.DeleteFornecedor;
using Application.DTOs.Fornecedores;
using Application.Queries.GetFornecedorById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DesafioGenialNet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FornecedoresController : ControllerBase
    {
        private IMediator _mediator;

        private readonly ILogger<FornecedoresController> _logger;

        public FornecedoresController(ILogger<FornecedoresController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] FornecedorDTO fornecedorDto)
        {
            try
            {
                if (fornecedorDto == null) return BadRequest();
                if (!ModelState.IsValid) return BadRequest();

                var command = new CreateFornecedorCommand(fornecedorDto);
                await _mediator.Send(command);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<FornecedorDTO>>> GetAllAsync()
        {
            var query = new GetAllFornecedoresQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FornecedorDTO>> FindByIdAsync(Guid id)
        {
            var query = new GetFornecedorByIdQuery(id);
            var fornecedor = await _mediator.Send(query);

            if (fornecedor == null)
            {
                return NotFound();
            }

            return Ok(fornecedor);
        }

        [HttpPut]
        public async Task<ActionResult<IActionResult>> Update([FromBody] FornecedorEditDTO fornecedorDto)
        {
            try
            {
                if (fornecedorDto == null) return BadRequest();
                var command = await _mediator.Send(fornecedorDto);
                return Ok(command);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                var command = new DeleteFornecedorCommand(id);
                var status = await _mediator.Send(command);
                if (!status) return BadRequest();
                return Ok(status);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
    }
}
