namespace SecretSantaSurvey.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questions", "ParentSurvey_Id", "dbo.Surveys");
            DropForeignKey("dbo.Surveys", "User_Id", "dbo.Users");
            DropIndex("dbo.Surveys", new[] { "User_Id" });
            DropIndex("dbo.Questions", new[] { "ParentSurvey_Id" });
            DropTable("dbo.Surveys");
            DropTable("dbo.Questions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        ParentSurvey_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Surveys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Relationship = c.Int(nullable: false),
                        Name = c.String(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Questions", "ParentSurvey_Id");
            CreateIndex("dbo.Surveys", "User_Id");
            AddForeignKey("dbo.Surveys", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Questions", "ParentSurvey_Id", "dbo.Surveys", "Id");
        }
    }
}
