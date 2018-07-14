namespace ReclutaCVData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModAgregarAtributosNuevosACandidatos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidato", "Nivel", c => c.Int(nullable: false));
            AddColumn("dbo.Candidato", "Bolsa", c => c.String());
            AddColumn("dbo.Candidato", "FechaDeContacto", c => c.DateTime(nullable: false));
            AddColumn("dbo.Candidato", "QuienLoContacto", c => c.String());
            AddColumn("dbo.Candidato", "Rol", c => c.Int(nullable: false));
            AddColumn("dbo.Candidato", "FechaDeExamen", c => c.DateTime(nullable: false));
            AddColumn("dbo.Candidato", "HoraDeExamen", c => c.DateTime(nullable: false));
            AddColumn("dbo.Candidato", "CalificacionDelExamen", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Candidato", "FechaDeEntrevista", c => c.DateTime(nullable: false));
            AddColumn("dbo.Candidato", "PropuestaEconomicaMonto", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Candidato", "FechaDeIngresoALaEmpresa", c => c.DateTime(nullable: false));
            AddColumn("dbo.Candidato", "Estatus", c => c.Int(nullable: false));
            AddColumn("dbo.Candidato", "Comentarios", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Candidato", "Comentarios");
            DropColumn("dbo.Candidato", "Estatus");
            DropColumn("dbo.Candidato", "FechaDeIngresoALaEmpresa");
            DropColumn("dbo.Candidato", "PropuestaEconomicaMonto");
            DropColumn("dbo.Candidato", "FechaDeEntrevista");
            DropColumn("dbo.Candidato", "CalificacionDelExamen");
            DropColumn("dbo.Candidato", "HoraDeExamen");
            DropColumn("dbo.Candidato", "FechaDeExamen");
            DropColumn("dbo.Candidato", "Rol");
            DropColumn("dbo.Candidato", "QuienLoContacto");
            DropColumn("dbo.Candidato", "FechaDeContacto");
            DropColumn("dbo.Candidato", "Bolsa");
            DropColumn("dbo.Candidato", "Nivel");
        }
    }
}
