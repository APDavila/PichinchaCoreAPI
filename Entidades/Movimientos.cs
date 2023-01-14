using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PichinchaCoreAPI.Entidades
{
    public class Movimientos
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column(TypeName = "DateTime")]
        [Required]
        public DateTime Fecha { get; set; }
        [MaxLength(20)]
        [Required]
        public string TipoMovimiento { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        [Required]
        public Double Valor { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        [Required]
        public Double Saldo { get; set; }
        public int CuentaId { get; set; }

    }
}
