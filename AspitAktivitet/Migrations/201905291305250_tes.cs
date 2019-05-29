namespace AspitAktivitet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Planneds", "WeekNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Planneds", "WeekNumber");
        }
    }
}
