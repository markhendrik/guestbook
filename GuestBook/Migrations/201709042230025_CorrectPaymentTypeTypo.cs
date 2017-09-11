namespace GuestBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectPaymentTypeTypo : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.PaymenTypes", newName: "PaymentTypes");
            RenameColumn(table: "dbo.Guests", name: "PaymenType_Id", newName: "PaymentType_Id");
            RenameIndex(table: "dbo.Guests", name: "IX_PaymenType_Id", newName: "IX_PaymentType_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Guests", name: "IX_PaymentType_Id", newName: "IX_PaymenType_Id");
            RenameColumn(table: "dbo.Guests", name: "PaymentType_Id", newName: "PaymenType_Id");
            RenameTable(name: "dbo.PaymentTypes", newName: "PaymenTypes");
        }
    }
}
