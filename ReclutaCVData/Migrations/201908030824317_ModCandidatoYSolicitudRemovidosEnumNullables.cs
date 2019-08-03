namespace ReclutaCVData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModCandidatoYSolicitudRemovidosEnumNullables : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM \"Candidato\"");
            Sql("DELETE FROM \"SolicitudVacante\"");

            AlterColumn("public.Candidato", "EstatusAcademico", c => c.Int(nullable: false));
            AlterColumn("public.Candidato", "Bolsa", c => c.Int(nullable: false));
            AlterColumn("public.Candidato", "Rol", c => c.Int(nullable: false));
            AlterColumn("public.Candidato", "Estatus", c => c.Int(nullable: false));
            AlterColumn("public.Candidato", "VeredictoFinal", c => c.Int(nullable: false));
            AlterColumn("public.Candidato", "PropuestaEconomicaEstatus", c => c.Int(nullable: false));
            AlterColumn("public.SolicitudVacante", "Estatus", c => c.Int(nullable: false));
            AlterColumn("public.SolicitudVacante", "PuestoSolicitadoNivel", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("public.SolicitudVacante", "PuestoSolicitadoNivel", c => c.Int());
            AlterColumn("public.SolicitudVacante", "Estatus", c => c.Int());
            AlterColumn("public.Candidato", "PropuestaEconomicaEstatus", c => c.Int());
            AlterColumn("public.Candidato", "VeredictoFinal", c => c.Int());
            AlterColumn("public.Candidato", "Estatus", c => c.Int());
            AlterColumn("public.Candidato", "Rol", c => c.Int());
            AlterColumn("public.Candidato", "Bolsa", c => c.Int());
            AlterColumn("public.Candidato", "EstatusAcademico", c => c.Int());
        }
    }
}
