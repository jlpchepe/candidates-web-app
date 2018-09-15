namespace ReclutaCVData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModEtapasCandidato : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.AnalisisCandidato",
                c => new
                    {
                        EntrevistaCandidatoId = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        ObservacionesRecursosHumanos = c.String(),
                        ObservacionesTecnicas = c.String(),
                        Aceptado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EntrevistaCandidatoId)
                .ForeignKey("public.EntrevistaCandidato", t => t.EntrevistaCandidatoId)
                .Index(t => t.EntrevistaCandidatoId);
            
            CreateTable(
                "public.EntrevistaCandidato",
                c => new
                    {
                        PrimeraLlamadaCandidatoId = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        Observaciones = c.String(),
                    })
                .PrimaryKey(t => t.PrimeraLlamadaCandidatoId)
                .ForeignKey("public.PrimeraLlamadaCandidato", t => t.PrimeraLlamadaCandidatoId)
                .Index(t => t.PrimeraLlamadaCandidatoId);
            
            CreateTable(
                "public.PrimeraLlamadaCandidato",
                c => new
                    {
                        EvaluacionCurriculumCandidatoId = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        Observaciones = c.String(),
                    })
                .PrimaryKey(t => t.EvaluacionCurriculumCandidatoId)
                .ForeignKey("public.EvaluacionCurriculumCandidato", t => t.EvaluacionCurriculumCandidatoId)
                .Index(t => t.EvaluacionCurriculumCandidatoId);
            
            CreateTable(
                "public.EvaluacionCurriculumCandidato",
                c => new
                    {
                        CandidatoId = c.Int(nullable: false),
                        FechaEvaluacion = c.DateTime(nullable: false),
                        Observaciones = c.String(),
                    })
                .PrimaryKey(t => t.CandidatoId)
                .ForeignKey("public.Candidato", t => t.CandidatoId)
                .Index(t => t.CandidatoId);
            
            CreateTable(
                "public.ExamenCandidato",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PrimeraLlamadaCandidatoId = c.Int(nullable: false),
                        Tipo = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        Calificacion = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Observaciones = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.PrimeraLlamadaCandidato", t => t.PrimeraLlamadaCandidatoId)
                .Index(t => new { t.Tipo, t.PrimeraLlamadaCandidatoId }, unique: true, name: "IX_Tipo_Candidato");
            
            CreateTable(
                "public.LlamadaPropuestaEconomicaCandidato",
                c => new
                    {
                        AnalisisCandidatoId = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        Observaciones = c.String(),
                        CandidatoAcepto = c.Boolean(),
                        SueldoOfrecido = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.AnalisisCandidatoId)
                .ForeignKey("public.AnalisisCandidato", t => t.AnalisisCandidatoId)
                .Index(t => t.AnalisisCandidatoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("public.LlamadaPropuestaEconomicaCandidato", "AnalisisCandidatoId", "public.AnalisisCandidato");
            DropForeignKey("public.ExamenCandidato", "PrimeraLlamadaCandidatoId", "public.PrimeraLlamadaCandidato");
            DropForeignKey("public.AnalisisCandidato", "EntrevistaCandidatoId", "public.EntrevistaCandidato");
            DropForeignKey("public.EntrevistaCandidato", "PrimeraLlamadaCandidatoId", "public.PrimeraLlamadaCandidato");
            DropForeignKey("public.PrimeraLlamadaCandidato", "EvaluacionCurriculumCandidatoId", "public.EvaluacionCurriculumCandidato");
            DropForeignKey("public.EvaluacionCurriculumCandidato", "CandidatoId", "public.Candidato");
            DropIndex("public.LlamadaPropuestaEconomicaCandidato", new[] { "AnalisisCandidatoId" });
            DropIndex("public.ExamenCandidato", "IX_Tipo_Candidato");
            DropIndex("public.EvaluacionCurriculumCandidato", new[] { "CandidatoId" });
            DropIndex("public.PrimeraLlamadaCandidato", new[] { "EvaluacionCurriculumCandidatoId" });
            DropIndex("public.EntrevistaCandidato", new[] { "PrimeraLlamadaCandidatoId" });
            DropIndex("public.AnalisisCandidato", new[] { "EntrevistaCandidatoId" });
            DropTable("public.LlamadaPropuestaEconomicaCandidato");
            DropTable("public.ExamenCandidato");
            DropTable("public.EvaluacionCurriculumCandidato");
            DropTable("public.PrimeraLlamadaCandidato");
            DropTable("public.EntrevistaCandidato");
            DropTable("public.AnalisisCandidato");
        }
    }
}
