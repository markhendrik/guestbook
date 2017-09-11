namespace GuestBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedGuestTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO GuestTypes (name) VALUES('Private client')");
            Sql("INSERT INTO GuestTypes (name) VALUES('Business client')");
        }
        
        public override void Down()
        {
        }
    }
}
