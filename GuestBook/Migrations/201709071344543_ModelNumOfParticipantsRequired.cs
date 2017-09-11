namespace GuestBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelNumOfParticipantsRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.NewGuestDtoes", "PaymentTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.NewGuestDtoes", "NumberGuests", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.NewGuestDtoes", "NumberGuests", c => c.Int());
            AlterColumn("dbo.NewGuestDtoes", "PaymentTypeId", c => c.Int());
        }
    }
}
