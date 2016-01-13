namespace CSOMDataProvider.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewForeignKeys : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.TermApplyActives");
            AddPrimaryKey("dbo.TermApplyActives", new[] { "ProgramId", "TermId" });
            DropColumn("dbo.TermApplyActives", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TermApplyActives", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.TermApplyActives");
            AddPrimaryKey("dbo.TermApplyActives", "Id");
        }
    }
}
