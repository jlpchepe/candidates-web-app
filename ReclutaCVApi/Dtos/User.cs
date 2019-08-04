using AppPersistence.Enums;

namespace ReclutaCVApi.Dtos
{
    /// <summary>
    /// Petición para cambiar el estatus de un usuario
    /// </summary>
    public class UsuarioChangeStatusRequest
    {
        public int Id { get; set; }
        public bool Activo { get; set; }
    }

    public class UsuarioInsertable
    {
        public string Nombre { get; set; }
        public string Contraseña { get; set; }
        public bool? Activo { get; set; }
    }

    public class UsuarioUpdatable 
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool? Activo { get; set; }
    }

    public class UsuarioListable {

        public UsuarioListable (int id, string nombre, bool activo)
        {
            Id = id;
            Nombre = nombre;
            Activo = activo;
        }
        
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
    }

    public class UsuarioConsultable : UsuarioListable
    {
        public UsuarioConsultable(int id, string name, bool active)
             : base(id, name, active)
        {
        }
    }
}