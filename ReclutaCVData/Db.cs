using ReclutaCVData.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutaCVData
{
    /// <summary>
    /// Contexto para controlar las entidades del sistema
    /// </summary>
    [DbConfigurationType(typeof(DbConfig))]
    public class Db : DbContext
    {

        public Db()
        //: base("Data Source=localhost;Initial Catalog=develop_reclutacv;Integrated Security=False;User Id=sa;Password=N0vut3k$C;")
        : base("Server=localhost;Port=5432;Database=develop_recluta_cv;User Id=postgres;Password=novutek;")
        {
        }

        public DbSet<Candidato> Candidato { get; set; }

        public static void InitMigrations()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Db, ReclutaCVData.Migrations.Configuration>(true));
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //El esquema predeterminado en PostgreSQL es public
            modelBuilder.HasDefaultSchema("public");

            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
       
            base.OnModelCreating(modelBuilder);
        }
    }
}