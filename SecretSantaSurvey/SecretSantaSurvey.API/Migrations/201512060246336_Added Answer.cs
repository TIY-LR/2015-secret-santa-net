namespace SecretSantaSurvey.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAnswer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "Answer", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questions", "Answer");
        }
    }
}
