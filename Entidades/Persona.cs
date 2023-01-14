using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PichinchaCoreAPI.Entidades
{
    public class Persona
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [MaxLength(100)]
        [Required]
        public string Nombre { get; set; }
        
        [MaxLength(10)]
        [Required]
        public string Genero { get; set; }
        [MaxLength(2)]
        [Required]
        public string Edad { get; set; }
        [MaxLength(13)]
        [Required]
        public string Identificacion { get; set; }
        [MaxLength(100)]
        [Required]
        public string Direccion { get; set; }
        [MaxLength(15)]
        [Required]
        public string Telefono { get; set; }
        [Required]
        public bool Activo { get; set; }        

        public Cliente Cliente { get; set; }

    }
}
