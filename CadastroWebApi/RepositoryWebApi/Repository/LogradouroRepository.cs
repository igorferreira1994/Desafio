using CadastroWebApi.Model;
using Microsoft.EntityFrameworkCore;
using RepositoryWebApi.Interface;

namespace RepositoryWebApi.Repository
{
    public class LogradouroRepository : ILogradouroRepository
    {
        public readonly ApiDbContext _context;
        public LogradouroRepository(ApiDbContext context)
        {
            _context = context;
        }
        public async Task<string> DeleteLogradouro(int Logradouro)
        {
            try
            {
                Logradouro c = await _context.Logradouro.FirstOrDefaultAsync(x => x.IdLogradouro == Logradouro);
                if (c != null)
                {
                    _context.Remove(c);
                    _context.SaveChanges();
                    return "Logradouro removido.";
                }
                return "Logradouro não encontrado!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<dynamic> GetLogradouro()
        {
            try
            {
                return await _context.Logradouro.ToListAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> PatchLogradouro(Logradouro Logradouro)
        {
            try
            {
                Logradouro c = await _context.Logradouro.FirstOrDefaultAsync(x => x.IdLogradouro == Logradouro.IdLogradouro);
                if (c != null)
                {
                    c.Descricao = Logradouro.Descricao;
                    _context.SaveChanges();
                    return "Dados gravados com sucesso";
                }
                return "Logradouro não encontrado!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public async Task<string> PostLogradouro(Logradouro Logradouro)
        {
            _context.Logradouro.Add(Logradouro);
            _context.SaveChanges();
            return "Dados gravados com sucesso";
        }
    }
}
