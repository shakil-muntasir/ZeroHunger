namespace ZeroHunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CollectionApproval : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Collections", "approved", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Collections", "approved");
        }
    }
}
