namespace ReclutaCVData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModCambioSexoSolicitudVacante : DbMigration
    {
        public override void Up()
        {
            AlterColumn("public.SolicitudVacante", "SexoDelCandidato", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("public.SolicitudVacante", "SexoDelCandidato", c => c.Int());
        }
    }
}
