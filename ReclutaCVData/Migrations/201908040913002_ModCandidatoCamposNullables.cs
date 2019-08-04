namespace ReclutaCVData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModCandidatoCamposNullables : DbMigration
    {
        public override void Up()
        {
            AlterColumn("public.Candidato", "EstatusAcademico", c => c.Int());
            AlterColumn("public.Candidato", "Bolsa", c => c.Int());
            AlterColumn("public.Candidato", "Rol", c => c.Int());
            AlterColumn("public.Candidato", "Estatus", c => c.Int());
            AlterColumn("public.Candidato", "VeredictoFinal", c => c.Int());
            AlterColumn("public.Candidato", "PropuestaEconomicaEstatus", c => c.Int());
            AlterColumn("public.SolicitudVacante", "PuestoSolicitadoNivel", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("public.SolicitudVacante", "PuestoSolicitadoNivel", c => c.Int(nullable: false));
            AlterColumn("public.Candidato", "PropuestaEconomicaEstatus", c => c.Int(nullable: false));
            AlterColumn("public.Candidato", "VeredictoFinal", c => c.Int(nullable: false));
            AlterColumn("public.Candidato", "Estatus", c => c.Int(nullable: false));
            AlterColumn("public.Candidato", "Rol", c => c.Int(nullable: false));
            AlterColumn("public.Candidato", "Bolsa", c => c.Int(nullable: false));
            AlterColumn("public.Candidato", "EstatusAcademico", c => c.Int(nullable: false));
        }
    }
}
