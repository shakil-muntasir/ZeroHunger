namespace ZeroHunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CollectionStatusColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Collections", "Status", c => c.Int(nullable: false));
            DropColumn("dbo.Collections", "approved");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Collections", "approved", c => c.Boolean(nullable: false));
            DropColumn("dbo.Collections", "Status");
        }
    }
}
