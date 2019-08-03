namespace ReclutaCVData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModCandidatoInstitucion : DbMigration
    {
        public override void Up()
        {
            AddColumn("public.Candidato", "Institucion", c => c.String());
            DropColumn("public.Candidato", "Universidad");
        }
        
        public override void Down()
        {
            AddColumn("public.Candidato", "Universidad", c => c.String());
            DropColumn("public.Candidato", "Institucion");
        }
    }
}
