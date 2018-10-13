namespace ReclutaCVData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModSolicitudVacante1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("public.SolicitudVacante", "NombreDelSolicitante", c => c.String());
            AddColumn("public.SolicitudVacante", "AreaDelSolicitante", c => c.Int(nullable: false));
            AddColumn("public.SolicitudVacante", "PuestoSolicitado", c => c.Int(nullable: false));
            AddColumn("public.SolicitudVacante", "CantidadDePersonal", c => c.Int(nullable: false));
            AddColumn("public.SolicitudVacante", "NivelIdiomaIngles", c => c.Int(nullable: false));
            AddColumn("public.SolicitudVacante", "EstadoCivil", c => c.Int(nullable: false));
            AddColumn("public.SolicitudVacante", "EdadRango", c => c.Int(nullable: false));
            AddColumn("public.SolicitudVacante", "SexoDelCandidato", c => c.Int());
            AddColumn("public.SolicitudVacante", "Proyecto", c => c.String());
            AddColumn("public.SolicitudVacante", "FechaEstimadaDeIngreso", c => c.DateTime(nullable: false));
            AddColumn("public.SolicitudVacante", "ExperienciaLaboral", c => c.String());
            AddColumn("public.SolicitudVacante", "CompetenciasOHabilidades", c => c.String());
            AddColumn("public.SolicitudVacante", "CertificacionesNecesarias", c => c.String());
            AddColumn("public.SolicitudVacante", "AplicacionDeInstrumentoDeEvaluacion", c => c.Int(nullable: false));
            AddColumn("public.SolicitudVacante", "Sueldo", c => c.Int(nullable: false));
            AddColumn("public.SolicitudVacante", "Observaciones", c => c.String());
            DropColumn("public.SolicitudVacante", "RolVacante");
        }
        
        public override void Down()
        {
            AddColumn("public.SolicitudVacante", "RolVacante", c => c.Int(nullable: false));
            DropColumn("public.SolicitudVacante", "Observaciones");
            DropColumn("public.SolicitudVacante", "Sueldo");
            DropColumn("public.SolicitudVacante", "AplicacionDeInstrumentoDeEvaluacion");
            DropColumn("public.SolicitudVacante", "CertificacionesNecesarias");
            DropColumn("public.SolicitudVacante", "CompetenciasOHabilidades");
            DropColumn("public.SolicitudVacante", "ExperienciaLaboral");
            DropColumn("public.SolicitudVacante", "FechaEstimadaDeIngreso");
            DropColumn("public.SolicitudVacante", "Proyecto");
            DropColumn("public.SolicitudVacante", "SexoDelCandidato");
            DropColumn("public.SolicitudVacante", "EdadRango");
            DropColumn("public.SolicitudVacante", "EstadoCivil");
            DropColumn("public.SolicitudVacante", "NivelIdiomaIngles");
            DropColumn("public.SolicitudVacante", "CantidadDePersonal");
            DropColumn("public.SolicitudVacante", "PuestoSolicitado");
            DropColumn("public.SolicitudVacante", "AreaDelSolicitante");
            DropColumn("public.SolicitudVacante", "NombreDelSolicitante");
        }
    }
}
