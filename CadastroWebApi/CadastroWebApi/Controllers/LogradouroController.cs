using CadastroWebApi.Model;
using Microsoft.AspNetCore.Mvc;
using ServiceWebApi.Interface;

namespace CadastroWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogradouroController : ControllerBase
    {   
        private readonly ILogger<LogradouroController> _logger;
        private readonly ILogradouroService _LogradouroService;

        public LogradouroController(ILogger<LogradouroController> logger, ILogradouroService LogradouroService)
        {
            _logger = logger;
            _LogradouroService = LogradouroService;
        }

        [HttpGet]
        public async Task<IEnumerable<Logradouro>> Get()
        {
            return await _LogradouroService.GetLogradouro();
        }

        [HttpPost]
        public async Task<string> Post(Logradouro Logradouro)
        {
            try
            {
                await _LogradouroService.PostLogradouro(Logradouro);
                return "Inserido com sucesso";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }

        [HttpPatch]
        public async Task<string> Patch(Logradouro Logradouro)
        {
            try
            {
                await _LogradouroService.PatchLogradouro(Logradouro);
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
                await _LogradouroService.DeleteLogradouro(id);
                return "Apagado com sucesso";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }
    }
}
