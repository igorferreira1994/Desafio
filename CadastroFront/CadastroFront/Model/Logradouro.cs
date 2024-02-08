using System.ComponentModel.DataAnnotations;

namespace CadastroFront.Model
{
    public class Logradouros
    {
        [Key]
        public int IdLogradouro { get; set; }
        [Required]
        public string Descricao { get; set; }
    }
}
