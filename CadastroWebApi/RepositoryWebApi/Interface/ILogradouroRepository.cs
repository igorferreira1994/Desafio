using CadastroWebApi.Model;

namespace RepositoryWebApi.Interface
{
    public interface ILogradouroRepository
    {
        public Task<dynamic> GetLogradouro();
        public Task<string> PostLogradouro(Logradouro Logradouro);
        public Task<string> PatchLogradouro(Logradouro Logradouro);
        public Task<string> DeleteLogradouro(int Logradouro);
    }
}
