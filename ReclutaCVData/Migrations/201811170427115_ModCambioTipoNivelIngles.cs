namespace ReclutaCVData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModCambioTipoNivelIngles : DbMigration
    {
        public override void Up()
        {
            AlterColumn("public.SolicitudVacante", "NivelIdiomaIngles", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("public.SolicitudVacante", "NivelIdiomaIngles", c => c.Int(nullable: false));
        }
    }
}
