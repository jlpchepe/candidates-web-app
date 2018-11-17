namespace ReclutaCVData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModCambiosLlavesPrimarias : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("public.PrimeraLlamadaCandidato", "EvaluacionCurriculumCandidatoId", "public.EvaluacionCurriculumCandidato");
            DropForeignKey("public.EntrevistaCandidato", "PrimeraLlamadaCandidatoId", "public.PrimeraLlamadaCandidato");
            DropForeignKey("public.AnalisisCandidato", "EntrevistaCandidatoId", "public.EntrevistaCandidato");
            DropForeignKey("public.LlamadaPropuestaEconomicaCandidato", "AnalisisCandidatoId", "public.AnalisisCandidato");
            DropIndex("public.AnalisisCandidato", new[] { "EntrevistaCandidatoId" });
            DropIndex("public.EntrevistaCandidato", new[] { "PrimeraLlamadaCandidatoId" });
            DropIndex("public.PrimeraLlamadaCandidato", new[] { "EvaluacionCurriculumCandidatoId" });
            DropIndex("public.LlamadaPropuestaEconomicaCandidato", new[] { "AnalisisCandidatoId" });
            DropPrimaryKey("public.AnalisisCandidato");
            DropPrimaryKey("public.EntrevistaCandidato");
            DropPrimaryKey("public.PrimeraLlamadaCandidato");
            DropPrimaryKey("public.LlamadaPropuestaEconomicaCandidato");
            CreateTable(
                "public.ContratacionCandidato",
                c => new
                    {
                        CandidatoId = c.Int(nullable: false),
                        FechaDeContratacion = c.DateTime(nullable: false),
                        NivelDelCandidato = c.String(),
                        Observaciones = c.String(),
                    })
                .PrimaryKey(t => t.CandidatoId)
                .ForeignKey("public.Candidato", t => t.CandidatoId)
                .Index(t => t.CandidatoId);
            
            AddColumn("public.AnalisisCandidato", "CandidatoId", c => c.Int(nullable: false));
            AddColumn("public.EntrevistaCandidato", "CandidatoId", c => c.Int(nullable: false));
            AddColumn("public.PrimeraLlamadaCandidato", "CandidatoId", c => c.Int(nullable: false));
            AddColumn("public.PrimeraLlamadaCandidato", "ContinuoConElProceso", c => c.Boolean(nullable: false));
            AddColumn("public.EvaluacionCurriculumCandidato", "CumplioConPerfil", c => c.Boolean(nullable: false));
            AddColumn("public.Candidato", "Rechazado", c => c.Boolean(nullable: false));
            AddColumn("public.LlamadaPropuestaEconomicaCandidato", "CandidatoId", c => c.Int(nullable: false));
            AddPrimaryKey("public.AnalisisCandidato", "CandidatoId");
            AddPrimaryKey("public.EntrevistaCandidato", "CandidatoId");
            AddPrimaryKey("public.PrimeraLlamadaCandidato", "CandidatoId");
            AddPrimaryKey("public.LlamadaPropuestaEconomicaCandidato", "CandidatoId");
            CreateIndex("public.AnalisisCandidato", "CandidatoId");
            CreateIndex("public.EntrevistaCandidato", "CandidatoId");
            CreateIndex("public.LlamadaPropuestaEconomicaCandidato", "CandidatoId");
            CreateIndex("public.PrimeraLlamadaCandidato", "CandidatoId");
            AddForeignKey("public.AnalisisCandidato", "CandidatoId", "public.Candidato", "Id");
            AddForeignKey("public.EntrevistaCandidato", "CandidatoId", "public.Candidato", "Id");
            AddForeignKey("public.LlamadaPropuestaEconomicaCandidato", "CandidatoId", "public.Candidato", "Id");
            AddForeignKey("public.PrimeraLlamadaCandidato", "CandidatoId", "public.Candidato", "Id");
            DropColumn("public.AnalisisCandidato", "EntrevistaCandidatoId");
            DropColumn("public.EntrevistaCandidato", "PrimeraLlamadaCandidatoId");
            DropColumn("public.PrimeraLlamadaCandidato", "EvaluacionCurriculumCandidatoId");
            DropColumn("public.LlamadaPropuestaEconomicaCandidato", "AnalisisCandidatoId");
        }
        
        public override void Down()
        {
            AddColumn("public.LlamadaPropuestaEconomicaCandidato", "AnalisisCandidatoId", c => c.Int(nullable: false));
            AddColumn("public.PrimeraLlamadaCandidato", "EvaluacionCurriculumCandidatoId", c => c.Int(nullable: false));
            AddColumn("public.EntrevistaCandidato", "PrimeraLlamadaCandidatoId", c => c.Int(nullable: false));
            AddColumn("public.AnalisisCandidato", "EntrevistaCandidatoId", c => c.Int(nullable: false));
            DropForeignKey("public.ContratacionCandidato", "CandidatoId", "public.Candidato");
            DropForeignKey("public.PrimeraLlamadaCandidato", "CandidatoId", "public.Candidato");
            DropForeignKey("public.LlamadaPropuestaEconomicaCandidato", "CandidatoId", "public.Candidato");
            DropForeignKey("public.EntrevistaCandidato", "CandidatoId", "public.Candidato");
            DropForeignKey("public.AnalisisCandidato", "CandidatoId", "public.Candidato");
            DropIndex("public.ContratacionCandidato", new[] { "CandidatoId" });
            DropIndex("public.PrimeraLlamadaCandidato", new[] { "CandidatoId" });
            DropIndex("public.LlamadaPropuestaEconomicaCandidato", new[] { "CandidatoId" });
            DropIndex("public.EntrevistaCandidato", new[] { "CandidatoId" });
            DropIndex("public.AnalisisCandidato", new[] { "CandidatoId" });
            DropPrimaryKey("public.LlamadaPropuestaEconomicaCandidato");
            DropPrimaryKey("public.PrimeraLlamadaCandidato");
            DropPrimaryKey("public.EntrevistaCandidato");
            DropPrimaryKey("public.AnalisisCandidato");
            DropColumn("public.LlamadaPropuestaEconomicaCandidato", "CandidatoId");
            DropColumn("public.Candidato", "Rechazado");
            DropColumn("public.EvaluacionCurriculumCandidato", "CumplioConPerfil");
            DropColumn("public.PrimeraLlamadaCandidato", "ContinuoConElProceso");
            DropColumn("public.PrimeraLlamadaCandidato", "CandidatoId");
            DropColumn("public.EntrevistaCandidato", "CandidatoId");
            DropColumn("public.AnalisisCandidato", "CandidatoId");
            DropTable("public.ContratacionCandidato");
            AddPrimaryKey("public.LlamadaPropuestaEconomicaCandidato", "AnalisisCandidatoId");
            AddPrimaryKey("public.PrimeraLlamadaCandidato", "EvaluacionCurriculumCandidatoId");
            AddPrimaryKey("public.EntrevistaCandidato", "PrimeraLlamadaCandidatoId");
            AddPrimaryKey("public.AnalisisCandidato", "EntrevistaCandidatoId");
            CreateIndex("public.LlamadaPropuestaEconomicaCandidato", "AnalisisCandidatoId");
            CreateIndex("public.PrimeraLlamadaCandidato", "EvaluacionCurriculumCandidatoId");
            CreateIndex("public.EntrevistaCandidato", "PrimeraLlamadaCandidatoId");
            CreateIndex("public.AnalisisCandidato", "EntrevistaCandidatoId");
            AddForeignKey("public.LlamadaPropuestaEconomicaCandidato", "AnalisisCandidatoId", "public.AnalisisCandidato", "EntrevistaCandidatoId");
            AddForeignKey("public.AnalisisCandidato", "EntrevistaCandidatoId", "public.EntrevistaCandidato", "PrimeraLlamadaCandidatoId");
            AddForeignKey("public.EntrevistaCandidato", "PrimeraLlamadaCandidatoId", "public.PrimeraLlamadaCandidato", "EvaluacionCurriculumCandidatoId");
            AddForeignKey("public.PrimeraLlamadaCandidato", "EvaluacionCurriculumCandidatoId", "public.EvaluacionCurriculumCandidato", "CandidatoId");
        }
    }
}
