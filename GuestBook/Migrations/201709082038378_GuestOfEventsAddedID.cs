namespace GuestBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GuestOfEventsAddedID : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        DateBeg = c.DateTime(nullable: false),
                        DateEnd = c.DateTime(nullable: false),
                        Address = c.String(nullable: false),
                        Information = c.String(),
                        NumberGuestsTotal = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GuestOfEvents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Event_Id = c.Int(nullable: false),
                        Guest_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.Event_Id, cascadeDelete: true)
                .ForeignKey("dbo.Guests", t => t.Guest_Id, cascadeDelete: true)
                .Index(t => t.Event_Id)
                .Index(t => t.Guest_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GuestOfEvents", "Guest_Id", "dbo.Guests");
            DropForeignKey("dbo.GuestOfEvents", "Event_Id", "dbo.Events");
            DropIndex("dbo.GuestOfEvents", new[] { "Guest_Id" });
            DropIndex("dbo.GuestOfEvents", new[] { "Event_Id" });
            DropTable("dbo.GuestOfEvents");
            DropTable("dbo.Events");
        }
    }
}
