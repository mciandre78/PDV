using System.ComponentModel.DataAnnotations;

namespace pdv.Models
{
    public class Pdv {
        [Key]
        public int Id { get; set; }

        [Required (ErrorMessage = "Este campo é obrigatório")]
        public string Description { get; set; }

        [Required (ErrorMessage = "Este campo é obrigatório")]
        [Range(0.1, 9999.99, ErrorMessage = "Valor informado inválido")]
        public decimal Price { get; set; }

        [Required (ErrorMessage = "Este campo é obrigatório")]
        [Range(0.1, 9999.99, ErrorMessage = "Valor informado inválido")]
        public decimal AmountPaid { get; set; }
    }
}