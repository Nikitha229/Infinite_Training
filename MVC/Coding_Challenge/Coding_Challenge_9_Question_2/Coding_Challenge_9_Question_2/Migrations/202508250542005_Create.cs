namespace Coding_Challenge_9_Question_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MID = c.Int(nullable: false, identity: true),
                        MovieName = c.String(),
                        DirectorName = c.String(),
                        DateofRelease = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Movies");
        }
    }
}
