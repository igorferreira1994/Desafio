using CadastroWebApi.Model;

namespace ServiceWebApi.Interface
{
    public interface IClienteService
    {
        public Task<dynamic> GetCliente();
        public Task<string> PostCliente(Cliente cliente);
        public Task<string> PatchCliente(Cliente cliente);
        public Task<string> DeleteCliente(int cliente);
    }
}
