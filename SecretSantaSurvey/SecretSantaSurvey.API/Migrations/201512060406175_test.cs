namespace SecretSantaSurvey.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Surveys", name: "UserID_Id", newName: "User_Id");
            RenameIndex(table: "dbo.Surveys", name: "IX_UserID_Id", newName: "IX_User_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Surveys", name: "IX_User_Id", newName: "IX_UserID_Id");
            RenameColumn(table: "dbo.Surveys", name: "User_Id", newName: "UserID_Id");
        }
    }
}
