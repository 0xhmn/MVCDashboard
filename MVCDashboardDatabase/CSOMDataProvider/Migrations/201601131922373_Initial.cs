namespace CSOMDataProvider.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TermApplyActives",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TermTitle = c.String(),
                        ProgramId = c.Int(nullable: false),
                        TermId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Programs", t => t.ProgramId, cascadeDelete: true)
                .ForeignKey("dbo.Terms", t => t.TermId, cascadeDelete: true)
                .Index(t => t.ProgramId)
                .Index(t => t.TermId);
            
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
                        Id = c.Int(nullable: false, identity: true),
                        DateStart = c.DateTime(nullable: false),
                        DateEnd = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TermApplyActives", "TermId", "dbo.Terms");
            DropForeignKey("dbo.TermApplyActives", "ProgramId", "dbo.Programs");
            DropIndex("dbo.TermApplyActives", new[] { "TermId" });
            DropIndex("dbo.TermApplyActives", new[] { "ProgramId" });
            DropTable("dbo.Terms");
            DropTable("dbo.Programs");
            DropTable("dbo.TermApplyActives");
        }
    }
}
