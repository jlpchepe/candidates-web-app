namespace ReclutaCVData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModCurriculumAgregado : DbMigration
    {
        public override void Up()
        {
            AddColumn("public.Candidato", "Curriculum", c => c.Binary());
            AddColumn("public.Candidato", "CurriculumFileName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("public.Candidato", "CurriculumFileName");
            DropColumn("public.Candidato", "Curriculum");
        }
    }
}
