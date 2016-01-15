namespace CSOMLocalDataProvider.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Programs",
                c => new
                    {
                        ProgramId = c.Int(nullable: false, identity: true),
                        ProgramTitle = c.String(),
                        ProgramDescription = c.String(),
                    })
                .PrimaryKey(t => t.ProgramId);
            
            CreateTable(
                "dbo.Terms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TermIdNumber = c.Int(nullable: false),
                        TermTitle = c.String(),
                        DateStart = c.DateTime(),
                        DateEnd = c.DateTime(),
                        ProgramId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Programs", t => t.ProgramId, cascadeDelete: true)
                .Index(t => t.ProgramId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Terms", "ProgramId", "dbo.Programs");
            DropIndex("dbo.Terms", new[] { "ProgramId" });
            DropTable("dbo.Terms");
            DropTable("dbo.Programs");
        }
    }
}
