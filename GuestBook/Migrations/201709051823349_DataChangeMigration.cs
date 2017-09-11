namespace GuestBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataChangeMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NewGuestDtoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Code = c.String(nullable: false),
                        Information = c.String(),
                        PaymentTypeId = c.Int(),
                        GuestTypeId = c.Int(),
                        NumberGuests = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NewGuestDtoes");
        }
    }
}
