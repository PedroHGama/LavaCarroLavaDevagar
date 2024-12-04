using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WashCarLavaDevagar.Models
{
    public class Lavagem
    {
        [Key]
        public int IDLavagem { get; set; }

        [Required]
        public int TipoLavagemID { get; set; }
        public TipoLavagem TipoLavagem { get; set; }

        [Required]
        public DateTime DataLavagem { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double ValorLavagem { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double DescontoLavagem { get; set; }

        [Required]
        public int CarroID { get; set; }
        public Carro Carro { get; set; }

        public enum Status
        {
            Andamento, // Lavagem está em progresso.
            Finalizada,  // Lavagem foi concluída.
            Agendada     // Lavagem está agendada para uma data futura.
        }
        // Campo calculado para o valor total após desconto
        [NotMapped]
        public double ValorTotal => ValorLavagem - DescontoLavagem;
    }
}
