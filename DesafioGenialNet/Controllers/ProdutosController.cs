using Application.DTOs.Produtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DesafioGenialNet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutosController : ControllerBase
    {
        private IMediator _mediator;

        private readonly ILogger<ProdutosController> _logger;

        public ProdutosController(ILogger<ProdutosController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] ProdutoDTO produtoDto)
        {
            try
            {
                if (produtoDto == null) return BadRequest();
                if (!ModelState.IsValid) return BadRequest();

                var command = new CreateProdutoCommand(produtoDto);
                await _mediator.Send(command);
                return Ok(produtoDto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<ProdutoDTO>>> GetAllAsync()
        {
            var query = new GetAllProdutosQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoDTO>> FindByIdAsync(Guid id)
        {
            var query = new GetProdutoByIdQuery(id);
            var fornecedor = await _mediator.Send(query);

            if (fornecedor == null)
            {
                return NotFound();
            }

            return Ok(fornecedor);
        }

        [HttpPut]
        public async Task<ActionResult<IActionResult>> Update([FromBody] ProdutoEditDTO produtoDto)
        {
            try
            {
                if (produtoDto == null) return BadRequest();
                var command = await _mediator.Send(produtoDto);
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
                var command = new DeleteProdutoCommand(id);
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
