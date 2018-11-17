namespace ReclutaCVData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModCambioEdadRango : DbMigration
    {
        public override void Up()
        {
            AlterColumn("public.SolicitudVacante", "EdadRango", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("public.SolicitudVacante", "EdadRango", c => c.Int(nullable: false));
        }
    }
}
