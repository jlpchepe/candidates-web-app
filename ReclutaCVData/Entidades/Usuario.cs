using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutaCVData.Entidades
{
    /// <summary>
    /// Un usuario del sistema
    /// </summary>
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Contraseña { get; set; }
        public bool Activo { get; set; }
    }
}
