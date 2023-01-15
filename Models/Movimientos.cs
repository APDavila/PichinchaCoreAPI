using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PichinchaCoreAPI.Entidades
{
    public class Movimientos
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column(TypeName = "DateTime")]        
        public DateTime Fecha { get; set; }

        [MaxLength(20, ErrorMessage = "El tipo de movimiento no puede sobrepasar los 20 caracteres.")]
        [Required(ErrorMessage = "El tipo de movimiento es requerido.")]
        public string TipoMovimiento { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        [Required(ErrorMessage = "El valor de movimiento es requerido.")]
        public Double Valor { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        [Required]
        public Double Saldo { get; set; }
        public int CuentaId { get; set; }

    }
}
