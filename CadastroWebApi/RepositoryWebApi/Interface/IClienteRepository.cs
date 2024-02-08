using CadastroWebApi.Model;

namespace RepositoryWebApi.Interface
{
    public interface IClienteRepository
    {
        public Task<dynamic> GetCliente();
        public Task<string> PostCliente(Cliente cliente);
        public Task<string> PatchCliente(Cliente cliente);
        public Task<string> DeleteCliente(int cliente);
    }
}
