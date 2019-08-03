namespace ReclutaCVData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModSolicitudVacanteCampoAgregados : DbMigration
    {
        public override void Up()
        {
            AddColumn("public.SolicitudVacante", "FolioCapitalHumano", c => c.Int(nullable: false));
            AddColumn("public.SolicitudVacante", "Motivo", c => c.Int(nullable: false));
            AddColumn("public.SolicitudVacante", "EspecifiqueMotivo", c => c.String());
            AddColumn("public.SolicitudVacante", "PuestoDelSolicitante", c => c.String());
            AddColumn("public.SolicitudVacante", "EspecifiqueAreaDelSolicitante", c => c.String());
            AddColumn("public.SolicitudVacante", "TipoDeContrato", c => c.Int(nullable: false));
            AddColumn("public.SolicitudVacante", "EspecifiqueTipoDeContrato", c => c.String());
            AddColumn("public.SolicitudVacante", "Estatus", c => c.Int());
            AddColumn("public.SolicitudVacante", "EspecifiquePuestoSolicitado", c => c.String());
            AddColumn("public.SolicitudVacante", "PuestoSolicitadoNivel", c => c.Int());
            AddColumn("public.SolicitudVacante", "NombreDelJefeInmediato", c => c.String());
            AddColumn("public.SolicitudVacante", "TipoDeEvaluacion", c => c.String());
            AlterColumn("public.SolicitudVacante", "NivelIdiomaIngles", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("public.SolicitudVacante", "EstadoCivil", c => c.String());
            AlterColumn("public.SolicitudVacante", "FechaEstimadaDeIngreso", c => c.DateTime());
            AlterColumn("public.SolicitudVacante", "Sueldo", c => c.Int());
            DropColumn("public.SolicitudVacante", "CantidadDeVacantes");
            DropColumn("public.SolicitudVacante", "CantidadDePersonal");
            DropColumn("public.SolicitudVacante", "SexoDelCandidato");
            DropColumn("public.SolicitudVacante", "AplicacionDeInstrumentoDeEvaluacion");
        }
        
        public override void Down()
        {
            AddColumn("public.SolicitudVacante", "AplicacionDeInstrumentoDeEvaluacion", c => c.Int(nullable: false));
            AddColumn("public.SolicitudVacante", "SexoDelCandidato", c => c.Int(nullable: false));
            AddColumn("public.SolicitudVacante", "CantidadDePersonal", c => c.Int(nullable: false));
            AddColumn("public.SolicitudVacante", "CantidadDeVacantes", c => c.Int(nullable: false));
            AlterColumn("public.SolicitudVacante", "Sueldo", c => c.Int(nullable: false));
            AlterColumn("public.SolicitudVacante", "FechaEstimadaDeIngreso", c => c.DateTime(nullable: false));
            AlterColumn("public.SolicitudVacante", "EstadoCivil", c => c.Int(nullable: false));
            AlterColumn("public.SolicitudVacante", "NivelIdiomaIngles", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("public.SolicitudVacante", "TipoDeEvaluacion");
            DropColumn("public.SolicitudVacante", "NombreDelJefeInmediato");
            DropColumn("public.SolicitudVacante", "PuestoSolicitadoNivel");
            DropColumn("public.SolicitudVacante", "EspecifiquePuestoSolicitado");
            DropColumn("public.SolicitudVacante", "Estatus");
            DropColumn("public.SolicitudVacante", "EspecifiqueTipoDeContrato");
            DropColumn("public.SolicitudVacante", "TipoDeContrato");
            DropColumn("public.SolicitudVacante", "EspecifiqueAreaDelSolicitante");
            DropColumn("public.SolicitudVacante", "PuestoDelSolicitante");
            DropColumn("public.SolicitudVacante", "EspecifiqueMotivo");
            DropColumn("public.SolicitudVacante", "Motivo");
            DropColumn("public.SolicitudVacante", "FolioCapitalHumano");
        }
    }
}
