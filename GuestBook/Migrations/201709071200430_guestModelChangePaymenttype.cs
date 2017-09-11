namespace GuestBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class guestModelChangePaymenttype : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GuestFormViewModels", "PaymentTypeId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GuestFormViewModels", "PaymentTypeId");
        }
    }
}
