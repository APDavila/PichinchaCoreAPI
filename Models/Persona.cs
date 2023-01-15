using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PichinchaCoreAPI.Entidades
{
    public class Persona
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [StringLength(50, ErrorMessage = "El nombre no puede sobrepasar los 50 caracteres.")]
        [Required(ErrorMessage = "El nombre es requerido.")]
        public string Nombre { get; set; }
        
        [StringLength(10, ErrorMessage = "El género no puede sobrepasar los 10 caracteres.")]
        [Required(ErrorMessage = "El género es requerido.")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "La edad es requerida.")]
        public int Edad { get; set; }
        
        [StringLength(13, ErrorMessage = "La identificacion no puede sobrepasar los 13 caracteres.")]
        [Required(ErrorMessage = "La identificacion es requerida.")]
        public string Identificacion { get; set; }
        
        [StringLength(100, ErrorMessage = "La dirección no puede sobrepasar los 100 caracteres.")]
        [Required(ErrorMessage = "La dirección es requerida.")]
        public string Direccion { get; set; }
        
        [StringLength(15, ErrorMessage = "El teléfono no puede sobrepasar los 15 caracteres.")]
        [Required(ErrorMessage = "El teléfono es requerido.")]
        public string Telefono { get; set; }
        
        [Required(ErrorMessage = "El estado es requerido.")]
        public bool Activo { get; set; }        

        public Cliente Cliente { get; set; }

    }
}
