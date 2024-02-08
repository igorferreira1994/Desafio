using CadastroWebApi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryWebApi.Repository
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions options):
            base(options)       
        {                
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Logradouro> Logradouro { get; set; }
    }
}
