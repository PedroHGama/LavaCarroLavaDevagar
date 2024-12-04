using System.ComponentModel.DataAnnotations;

namespace WashCarLavaDevagar.Models
{
    public class Funcionario
    {
        [Key]
        public int FuncionarioID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "O nome não pode ter mais que 100 caracteres.")]
        public string NomeF { get; set; }

        [Required]
        [StringLength(11, ErrorMessage = "O CPF deve ter 11 caracteres.")]
        public string CPF { get; set; }

        [Required]
        public string EnderecoF { get; set; }

        [Required]
        public DateOnly DataNasc { get; set; }
    }

}
