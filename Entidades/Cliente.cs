﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PichinchaCoreAPI.Entidades
{
    public class Cliente
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(20)]
        [Required]
        public string Contrasenia { get; set; }
        [Required]
        public bool Activo { get; set; }
        public List<Cuenta> Cuentas { get; set; }
        public int PersonaId { get; set; }

    }
}
