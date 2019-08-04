using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutaCVData.Entidades
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Index(IsUnique = true)]
        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Contraseña { get; set; }

        /// <summary>
        /// Determina si el usuario está activo
        /// </summary>
        public bool Activo { get; set; }
    }
}
