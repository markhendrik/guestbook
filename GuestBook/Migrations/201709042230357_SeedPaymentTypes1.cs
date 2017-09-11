namespace GuestBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedPaymentTypes1 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO PaymentTypes (name) VALUES('Bank transfer')");
            Sql("INSERT INTO PaymentTypes (name) VALUES('Cash')");
        }
        
        public override void Down()
        {
        }
    }
}
