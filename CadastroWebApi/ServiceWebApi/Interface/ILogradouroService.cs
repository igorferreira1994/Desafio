using CadastroWebApi.Model;

namespace ServiceWebApi.Interface
{
    public interface ILogradouroService
    {
        public Task<dynamic> GetLogradouro();
        public Task<string> PostLogradouro(Logradouro Logradouro);
        public Task<string> PatchLogradouro(Logradouro Logradouro);
        public Task<string> DeleteLogradouro(int Logradouro);
    }
}
