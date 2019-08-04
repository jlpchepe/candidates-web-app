using AppPersistence.Enums;

namespace ReclutaCVApi.Dtos
{
    /// <summary>
    /// Petición para cambiar el estatus de un usuario
    /// </summary>
    public class UsuarioChangeStatusRequest
    {
        public int Id { get; set; }
        public bool Active { get; set; }
    }

    public class UsuarioInsertable
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public bool? Active { get; set; }
    }

    public class UsuarioUpdatable 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool? Active { get; set; }
    }

    public class UsuarioListable {

        public UsuarioListable (int id, string name, bool active)
        {
            Id = id;
            Name = name;
            Active = active;
        }
        
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
    }

    public class UsuarioConsultable : UsuarioListable
    {
        public UsuarioConsultable(int id, string name, bool active)
             : base(id, name, active)
        {
        }
    }
}