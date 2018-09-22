namespace ReclutaCVData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModCambioExamenCandidatoMapeo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("public.ExamenCandidato", "PrimeraLlamadaCandidatoId", "public.PrimeraLlamadaCandidato");
            DropIndex("public.ExamenCandidato", "IX_Tipo_Candidato");
            AddColumn("public.ExamenCandidato", "CandidatoId", c => c.Int(nullable: false));
            CreateIndex("public.ExamenCandidato", new[] { "Tipo", "CandidatoId" }, unique: true, name: "IX_Tipo_Candidato");
            AddForeignKey("public.ExamenCandidato", "CandidatoId", "public.Candidato", "Id");
            DropColumn("public.ExamenCandidato", "PrimeraLlamadaCandidatoId");
        }
        
        public override void Down()
        {
            AddColumn("public.ExamenCandidato", "PrimeraLlamadaCandidatoId", c => c.Int(nullable: false));
            DropForeignKey("public.ExamenCandidato", "CandidatoId", "public.Candidato");
            DropIndex("public.ExamenCandidato", "IX_Tipo_Candidato");
            DropColumn("public.ExamenCandidato", "CandidatoId");
            CreateIndex("public.ExamenCandidato", new[] { "Tipo", "PrimeraLlamadaCandidatoId" }, unique: true, name: "IX_Tipo_Candidato");
            AddForeignKey("public.ExamenCandidato", "PrimeraLlamadaCandidatoId", "public.PrimeraLlamadaCandidato", "EvaluacionCurriculumCandidatoId");
        }
    }
}
