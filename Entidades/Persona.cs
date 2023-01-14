using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PichinchaCoreAPI.Entidades
{
    public class Persona
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [MaxLength(100)]
        public string Nombre { get; set; }
        
        [MaxLength(10)]
        public string Genero { get; set; }
        [MaxLength(2)]
        public string Edad { get; set; }
        [MaxLength(13)]
        public string Identificacion { get; set; }
        [MaxLength(100)]
        public string Direccion { get; set; }
        [MaxLength(15)]
        public string Telefono { get; set; }
        
        public bool Activo { get; set; }        

    }
}
