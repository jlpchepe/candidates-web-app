using AppPersistence.Enums;

namespace ReclutaCVApi.Dtos
{
    /// <summary>
    /// Petición para cambiar el estatus de un usuario
    /// </summary>
    public class UserChangeStatusRequest
    {
        public int Id { get; set; }
        public bool Active { get; set; }
    }

    public class UserInsertable
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public bool? Active { get; set; }
    }

    public class UserUpdatable 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool? Active { get; set; }
    }

    public class UserListable {

        public UserListable (int id, string name, bool active)
        {
            Id = id;
            Name = name;
            Active = active;
        }
        
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
    }

    public class UserConsultable : UserListable
    {
        public UserConsultable(int id, string name, bool active)
             : base(id, name, active)
        {
        }
    }
}