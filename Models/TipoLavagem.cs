using System.ComponentModel.DataAnnotations;

namespace WashCarLavaDevagar.Models
{
    public class TipoLavagem
    {
        [Key]
        public int IDTipoLavagem { get; set; }

        [Required]
        [StringLength(50)]
        public string Descricao { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double ValorBase { get; set; }

        public ICollection<TipoLavagem> tipoLavagems { get; set; }
    }

}

