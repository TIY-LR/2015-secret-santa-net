namespace SecretSantaSurvey.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedRelationship : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "Answers", c => c.String());
            DropColumn("dbo.Surveys", "Relationship");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Surveys", "Relationship", c => c.Int(nullable: false));
            DropColumn("dbo.Questions", "Answers");
        }
    }
}
