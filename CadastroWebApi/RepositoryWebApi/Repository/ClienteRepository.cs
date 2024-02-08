using CadastroWebApi.Model;
using Microsoft.EntityFrameworkCore;
using RepositoryWebApi.Interface;

namespace RepositoryWebApi.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        public readonly ApiDbContext _context;
        public ClienteRepository(ApiDbContext context)
        {
            _context = context;
        }
        public async Task<string> DeleteCliente(int cliente)
        {
            try
            {
                Cliente c = await _context.Cliente.FirstOrDefaultAsync(x => x.IdCliente == cliente);
                if (c != null)
                {
                    _context.Remove(c);
                    _context.SaveChanges();
                    return "Cliente removido.";
                }
                return "Cliente não encontrado!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<dynamic> GetCliente()
        {
            try
            {
                return await _context.Cliente.ToListAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> PatchCliente(Cliente cliente)
        {
            try
            {
                Cliente c = await _context.Cliente.FirstOrDefaultAsync(x => x.IdCliente == cliente.IdCliente);
                if (c != null)
                {
                    c.Email = cliente.Email;
                    c.Nome = cliente.Nome;
                    c.Logotipo = cliente.Logotipo;
                    c.Nome = c.Nome;
                    c.IdLogradouro = cliente.IdLogradouro;
                    _context.SaveChanges();
                    return "Dados gravados com sucesso";
                }
                return "Cliente não encontrado!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public async Task<string> PostCliente(Cliente cliente)
        {
            _context.Cliente.Add(cliente);
            _context.SaveChanges();
            return "Dados gravados com sucesso";
        }
    }
}
