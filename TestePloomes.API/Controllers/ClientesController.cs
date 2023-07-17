using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TestePloomes.Domain.DTOS;
using TestePloomes.Domain.Interfaces;

namespace TestePloomes.API.Controllers {

    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : Controller {

        private readonly IClientesService _clientesService;

        public ClientesController(IClientesService clientesService) {

            _clientesService = clientesService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Busca todos os clientes cadastrados.")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ClientesDTO>>> GetClientes() {

            try {
                return Ok(await _clientesService.SelecionarTodos());
            } catch (Exception e) {
                return BadRequest(e.Message);
            }

        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra um novo cliente.")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CadastrarCliente(ClientesDTO clientesDTO) {

            try {
                await _clientesService.Incluir(clientesDTO);
                return Ok("Cliente cadastrado com sucesso!");
            } catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Altera dados de um cliente cadastrado.")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AlterarCliente(ClientesDTO clientesDTO) {

            try 
            {
                await _clientesService.Alterar(clientesDTO);
                return Ok("Cliente alterado com sucesso!");
            } 
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Deleta um cliente cadastrado.")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeletarCliente(int id) {

            try {
                await _clientesService.Excluir(id);
                 return Ok("Cliente excluído com sucesso!");
            } catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Busca um cliente pelo Id.")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> SelecionarCliente(int id) {

            try {
                var cliente = await _clientesService.GetById(id);
                return Ok(cliente);
            } catch (Exception e) {
                return BadRequest(e.Message);
            }
        }
    }
}
