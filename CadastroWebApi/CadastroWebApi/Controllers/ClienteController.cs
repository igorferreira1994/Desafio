
using CadastroWebApi.Model;
using Microsoft.AspNetCore.Mvc;
using ServiceWebApi.Interface;

namespace CadastroWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {   
        private readonly ILogger<ClienteController> _logger;
        private readonly IClienteService _clienteService;

        public ClienteController(ILogger<ClienteController> logger , IClienteService clienteService)
        {
            _logger = logger;
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<IEnumerable<Cliente>> Get()
        {
            return await _clienteService.GetCliente();
        }

        [HttpPost]
        public async Task<string> Post(Cliente cliente)
        {
            try
            {
                await _clienteService.PostCliente(cliente);
                return "Inserido com sucesso";
            }
            catch (Exception ex)
            { 
                return ex.ToString();
            }
            
        }

        [HttpPatch]
        public async Task<string> Patch(Cliente cliente)
        {
            try
            {
                await _clienteService.PatchCliente(cliente);
                return "Atualizado com sucesso";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }

        [HttpDelete]
        public async Task<string> Patch(int id)
        {
            try
            {
                await _clienteService.DeleteCliente(id);
                return "Apagado com sucesso";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }
    }
}
