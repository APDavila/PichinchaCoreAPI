using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PichinchaCoreAPI.Entidades
{
    public class Cuenta
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(20, ErrorMessage = "El número de cuenta no puede sobrepasar los 20 caracteres.")]
        [Required(ErrorMessage = "El número de cuenta es requerido.")]
        public string NumeroCuenta{ get; set; }

        [MaxLength(10, ErrorMessage = "El tipo de cuenta no puede sobrepasar los 10 caracteres.")]
        [Required(ErrorMessage = "El nombre es requerido.")]
        public string TipoCuenta{ get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Required(ErrorMessage = "El saldo inicial es requerido.")]
        public Double SaldoInicial { get; set; }
        [Column(TypeName = "decimal(18, 2)")]        
        public Double CupoDiario { get; set; }

        [Required]
        public bool Activo { get; set; }
        public int ClienteId { get; set; }
        public List<Movimientos> Movimientos { get; set; }
    }
}
