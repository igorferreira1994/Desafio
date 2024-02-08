using CadastroWebApi.Model;
using RepositoryWebApi.Interface;
using ServiceWebApi.Interface;

namespace ServiceWebApi.Service
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<string> DeleteCliente(int Cliente)
        {
            return await _clienteRepository.DeleteCliente(Cliente);
        }

        public async Task<dynamic> GetCliente()
        {
            return await _clienteRepository.GetCliente();
        }

        public async Task<string> PatchCliente(Cliente Cliente)
        {
            return await _clienteRepository.PatchCliente(Cliente);
        }

        public async Task<string> PostCliente(Cliente Cliente)
        {
            return await _clienteRepository.PostCliente(Cliente);
        }
    }
}
