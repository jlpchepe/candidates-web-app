namespace ReclutaCVData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModSolicitudVacante : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.SolicitudVacante",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CantidadDeVacantes = c.Int(nullable: false),
                        RolVacante = c.Int(nullable: false),
                        FechaDeSolicitud = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("public.SolicitudVacante");
        }
    }
}
