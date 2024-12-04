using System.ComponentModel.DataAnnotations;

namespace WashCarLavaDevagar.Models
{
    public class Cliente
    {
        [Key]
        public int IDCliente { get; set; }

        [Required]
        public string NomeCliente { get; set; }

        [Required]
        public string EnderecoCliente { get; set; }

        [Required]
        public string FoneCliente { get; set; }

        // Relacionamentos
        public ICollection<Carro> Carros { get; set; }
    }
}
