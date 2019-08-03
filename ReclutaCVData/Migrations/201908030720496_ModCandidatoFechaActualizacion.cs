namespace ReclutaCVData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModCandidatoFechaActualizacion : DbMigration
    {
        public override void Up()
        {
            AddColumn("public.Candidato", "FechaDeActualizacion", c => c.DateTime());
            AddColumn("public.Candidato", "PropuestaEconomicaEstatus", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("public.Candidato", "PropuestaEconomicaEstatus");
            DropColumn("public.Candidato", "FechaDeActualizacion");
        }
    }
}
