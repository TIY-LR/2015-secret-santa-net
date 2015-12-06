namespace SecretSantaSurvey.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cascadedelete : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questions", "ParentSurvey_Id", "dbo.Surveys");
            DropIndex("dbo.Questions", new[] { "ParentSurvey_Id" });
            AlterColumn("dbo.Questions", "ParentSurvey_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Questions", "ParentSurvey_Id");
            AddForeignKey("dbo.Questions", "ParentSurvey_Id", "dbo.Surveys", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "ParentSurvey_Id", "dbo.Surveys");
            DropIndex("dbo.Questions", new[] { "ParentSurvey_Id" });
            AlterColumn("dbo.Questions", "ParentSurvey_Id", c => c.Int());
            CreateIndex("dbo.Questions", "ParentSurvey_Id");
            AddForeignKey("dbo.Questions", "ParentSurvey_Id", "dbo.Surveys", "Id");
        }
    }
}
