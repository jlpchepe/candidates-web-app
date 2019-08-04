namespace ReclutaCVData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModTablaUsuarioAgregada : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Contraseña = c.String(nullable: false),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Nombre, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("public.Usuario", new[] { "Nombre" });
            DropTable("public.Usuario");
        }
    }
}
