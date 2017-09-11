namespace GuestBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGuestVer2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Guests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Code = c.String(nullable: false),
                        Information = c.String(),
                        NumberGuests = c.Int(),
                        GuestType_Id = c.Int(nullable: false),
                        PaymenType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GuestTypes", t => t.GuestType_Id, cascadeDelete: true)
                .ForeignKey("dbo.PaymenTypes", t => t.PaymenType_Id)
                .Index(t => t.GuestType_Id)
                .Index(t => t.PaymenType_Id);
            
            CreateTable(
                "dbo.GuestTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PaymenTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Guests", "PaymenType_Id", "dbo.PaymenTypes");
            DropForeignKey("dbo.Guests", "GuestType_Id", "dbo.GuestTypes");
            DropIndex("dbo.Guests", new[] { "PaymenType_Id" });
            DropIndex("dbo.Guests", new[] { "GuestType_Id" });
            DropTable("dbo.PaymenTypes");
            DropTable("dbo.GuestTypes");
            DropTable("dbo.Guests");
        }
    }
}
