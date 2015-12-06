namespace SecretSantaSurvey.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserPost : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Surveys", name: "User_Id", newName: "UserID_Id");
            RenameIndex(table: "dbo.Surveys", name: "IX_User_Id", newName: "IX_UserID_Id");
            DropColumn("dbo.Surveys", "Name");
            DropColumn("dbo.Questions", "Answers");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "Answers", c => c.String());
            AddColumn("dbo.Surveys", "Name", c => c.String());
            RenameIndex(table: "dbo.Surveys", name: "IX_UserID_Id", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Surveys", name: "UserID_Id", newName: "User_Id");
        }
    }
}
