namespace SecretSantaSurvey.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SurveysAndUsers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Surveys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Relationship = c.Int(nullable: false),
                        Name = c.String(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        ParentSurvey_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Surveys", t => t.ParentSurvey_Id)
                .Index(t => t.ParentSurvey_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Surveys", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Questions", "ParentSurvey_Id", "dbo.Surveys");
            DropIndex("dbo.Questions", new[] { "ParentSurvey_Id" });
            DropIndex("dbo.Surveys", new[] { "User_Id" });
            DropTable("dbo.Questions");
            DropTable("dbo.Surveys");
        }
    }
}
