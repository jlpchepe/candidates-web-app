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
        public Db(string connectionString) : base(connectionString){
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Db, ReclutaCVData.Migrations.Configuration>(true));
        }

        public Db()
        : this("Server=localhost;Port=5432;Database=develop_recluta_cv;User Id=postgres;Password=novutek;")
        {
        }

        public DbSet<Candidato> Candidato { get; set; }
        public DbSet<AnalisisCandidato> AnalisisCandidato { get; set; }
        public DbSet<EntrevistaCandidato> EntrevistaCandidato { get; set; }
        public DbSet<EvaluacionCurriculumCandidato> EvaluacionCurriculumCandidato { get; set; }
        public DbSet<ExamenCandidato> ExamenCandidato { get; set; }
        public DbSet<LlamadaPropuestaEconomicaCandidato> LlamadaPropuestaEconomicaCandidato { get; set; }
        public DbSet<PrimeraLlamadaCandidato> PrimeraLlamadaCandidato { get; set; }
        public DbSet<ContratacionCandidato> ContratacionCandidato { get; set; }
        public DbSet<SolicitudVacante> SolicitudVacante { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

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