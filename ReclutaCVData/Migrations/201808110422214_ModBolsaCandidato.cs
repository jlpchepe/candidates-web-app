namespace ReclutaCVData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModBolsaCandidato : DbMigration
    {
        public override void Up()
        {
            DropColumn("public.Candidato", "Bolsa");
            AddColumn("public.Candidato", "Bolsa", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("public.Candidato", "Bolsa", c => c.String());
        }
    }
}
