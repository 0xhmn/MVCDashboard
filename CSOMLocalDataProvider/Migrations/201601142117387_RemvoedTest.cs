namespace CSOMLocalDataProvider.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemvoedTest : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Tests");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TestTille = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
