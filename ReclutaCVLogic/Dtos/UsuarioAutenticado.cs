using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutaCVLogic.Dtos
{
    /// <summary>
    /// Información de un usuario recién autenticado en el sistema
    /// </summary>
    public class UsuarioAutenticado
    {
        public UsuarioAutenticado(
           int id,
           string nombre
       )
        {
            Id = id;
            Nombre = nombre;
        }

        public int Id { get; }
        public string Nombre { get; }
    }
}
