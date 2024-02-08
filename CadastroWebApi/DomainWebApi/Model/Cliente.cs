using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroWebApi.Model
{
    public class Cliente
    {
        
        [Key]
        public int IdCliente { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        public string Logotipo { get; set; }
        [ForeignKey("IdLogradouro")]
        public int? IdLogradouro { get; set; }

    }
}
