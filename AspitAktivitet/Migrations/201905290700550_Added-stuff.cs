namespace AspitAktivitet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedstuff : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Planneds",
                c => new
                    {
                        Date = c.DateTime(nullable: false),
                        ActivtyID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Date, t.ActivtyID });
            
            CreateTable(
                "dbo.Registers",
                c => new
                    {
                        UserID = c.Int(nullable: false),
                        ActivityID = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserID, t.ActivityID, t.Date });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Registers");
            DropTable("dbo.Planneds");
        }
    }
}
