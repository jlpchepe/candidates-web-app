namespace ReclutaCVData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModAgregarTablaCandidato : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Candidato",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AñosDeExperiencia = c.Int(nullable: false),
                        Nombre = c.String(),
                        FechaDeNacimiento = c.DateTime(nullable: false),
                        ApellidoPaterno = c.String(),
                        ApellidoMaterno = c.String(),
                        CiudadResidencia = c.String(),
                        SueldoActual = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SueldoEsperado = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Candidato");
        }
    }
}
