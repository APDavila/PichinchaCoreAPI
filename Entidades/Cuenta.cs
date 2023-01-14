using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PichinchaCoreAPI.Entidades
{
    public class Cuenta
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(20)]
        [Required]
        public string NumeroCuenta{ get; set; }
        [MaxLength(10)]
        [Required]
        public string TipoCuenta{ get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        [Required]
        public Double SaldoInicial { get; set; }
        [Required]
        public bool Activo { get; set; }
        public int ClienteId { get; set; }
        public List<Movimientos> Movimientos { get; set; }
    }
}
