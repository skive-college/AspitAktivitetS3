namespace AspitAktivitet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addActivity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Name, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Activities", new[] { "Name" });
            DropTable("dbo.Activities");
        }
    }
}
