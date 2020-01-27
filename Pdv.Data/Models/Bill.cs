using pdv.Enums;
using System.ComponentModel.DataAnnotations;

namespace pdv.Models {
    public class Bill {
        
        [Key]
        public int Id { get; set; }

        [Required (ErrorMessage = "Este campo é obrigatório")]
        public string Description { get; set; }

        [Required (ErrorMessage = "Este campo é obrigatório")]
        [Range (0.1, 100, ErrorMessage = "Valor informado inválido")]
        public decimal Value { get; set; }

        public EnumBillType.EBillType EBillType { get; set; }

        public int Quantity { get; set; }
    }
}