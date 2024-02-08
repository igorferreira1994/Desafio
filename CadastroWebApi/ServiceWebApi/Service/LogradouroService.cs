using CadastroWebApi.Model;
using RepositoryWebApi.Interface;
using ServiceWebApi.Interface;

namespace ServiceWebApi.Service
{
    public class LogradouroService : ILogradouroService
    {
        private readonly ILogradouroRepository _logradouroRepository;

        public LogradouroService(ILogradouroRepository logradouroRepository)
        {
            _logradouroRepository = logradouroRepository;
        }

        public async Task<string> DeleteLogradouro(int Logradouro)
        {
            return await _logradouroRepository.DeleteLogradouro(Logradouro);
        }

        public async Task<dynamic> GetLogradouro()
        {
            return await _logradouroRepository.GetLogradouro();
        }

        public async Task<string> PatchLogradouro(Logradouro Logradouro)
        {
            return await _logradouroRepository.PatchLogradouro(Logradouro);
        }

        public async Task<string> PostLogradouro(Logradouro Logradouro)
        {
            return await _logradouroRepository.PostLogradouro(Logradouro);
        }
    }
}
