using System.ComponentModel.DataAnnotations;

namespace WashCarLavaDevagar.Models
{
    public class Carro
    {
        [Key]
        public int IDCarro { get; set; }

        [Required]
        public string Placa { get; set; }

        [Required]
        public string Modelo { get; set; }

        [Required]
        public string Marca { get; set; }

        [Required]
        public string Ano { get; set; }

        [Required]
        public int ClienteID { get; set; }
        public Cliente Cliente { get; set; }

        // Relacionamento com Lavagens
        public ICollection<Lavagem> Lavagens { get; set; }
    }
}
