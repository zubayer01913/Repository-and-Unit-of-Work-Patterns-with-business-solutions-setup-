namespace Test.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class student_update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Information", c => c.String());
            AddColumn("dbo.Students", "Comment", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Comment");
            DropColumn("dbo.Students", "Information");
        }
    }
}
