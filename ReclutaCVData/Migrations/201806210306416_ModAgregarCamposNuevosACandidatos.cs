namespace ReclutaCVData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModAgregarCamposNuevosACandidatos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidato", "Carrera", c => c.String());
            AddColumn("dbo.Candidato", "Universidad", c => c.String());
            AddColumn("dbo.Candidato", "NivelDeInglesHablado", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Candidato", "NivelDeInglesEscrito", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Candidato", "NivelDeInglesLectura", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Candidato", "Cursos", c => c.String());
            AddColumn("dbo.Candidato", "Certificaciones", c => c.String());
            AddColumn("dbo.Candidato", "Telefono", c => c.String());
            AddColumn("dbo.Candidato", "Correo", c => c.String());
            AddColumn("dbo.Candidato", "EstatusAcademico", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Candidato", "EstatusAcademico");
            DropColumn("dbo.Candidato", "Correo");
            DropColumn("dbo.Candidato", "Telefono");
            DropColumn("dbo.Candidato", "Certificaciones");
            DropColumn("dbo.Candidato", "Cursos");
            DropColumn("dbo.Candidato", "NivelDeInglesLectura");
            DropColumn("dbo.Candidato", "NivelDeInglesEscrito");
            DropColumn("dbo.Candidato", "NivelDeInglesHablado");
            DropColumn("dbo.Candidato", "Universidad");
            DropColumn("dbo.Candidato", "Carrera");
        }
    }
}
