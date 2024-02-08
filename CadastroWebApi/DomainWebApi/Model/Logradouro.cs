using System.ComponentModel.DataAnnotations;

namespace CadastroWebApi.Model
{
    public class Logradouro
    {
        [Key]
        public int IdLogradouro { get; set; }
        [Required]
        public string Descricao { get; set; }
    }
}
