namespace CSOMLocalDataProvider.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestM : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Programs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProgramTitle = c.String(),
                        ProgramDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Terms",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ProgramId = c.Int(nullable: false),
                        TermTitle = c.String(),
                        DateStart = c.DateTime(),
                        DateEnd = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.Id, t.ProgramId })
                .ForeignKey("dbo.Programs", t => t.ProgramId, cascadeDelete: true)
                .Index(t => t.ProgramId);
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TestTille = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Terms", "ProgramId", "dbo.Programs");
            DropIndex("dbo.Terms", new[] { "ProgramId" });
            DropTable("dbo.Tests");
            DropTable("dbo.Terms");
            DropTable("dbo.Programs");
        }
    }
}
