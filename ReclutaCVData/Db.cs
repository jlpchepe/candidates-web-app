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
    public class Db : DbContext
    {

        public Db() 
            : base("Data Source=localhost;Initial Catalog=develop_reclutacv;Integrated Security=False;User Id=sa;Password=N0vut3k$C;")
        {
        }

        public DbSet<Candidato> Candidato { get; set; }

        public static void InitMigrations()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Db, ReclutaCVData.Migrations.Configuration>(true));
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
