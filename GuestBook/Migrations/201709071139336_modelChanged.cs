namespace GuestBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelChanged : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GuestFormViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Code = c.String(nullable: false),
                        Information = c.String(),
                        GuestTypeId = c.Int(nullable: false),
                        NumberGuests = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GuestFormViewModels");
        }
    }
}
