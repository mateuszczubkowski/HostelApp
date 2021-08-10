namespace HostelApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Guests",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false),
                        SecondName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        BirthdayDate = c.DateTime(),
                        PostalCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ReservationCode = c.String(nullable: false, maxLength: 10),
                        CreatedAt = c.DateTime(nullable: false),
                        Price = c.Double(nullable: false),
                        CheckInDate = c.DateTime(nullable: false),
                        CheckOutDate = c.DateTime(nullable: false),
                        CurrencyType = c.Int(nullable: false),
                        Commission = c.Double(),
                        Source = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReservationGuests",
                c => new
                    {
                        Reservation_Id = c.Guid(nullable: false),
                        Guest_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Reservation_Id, t.Guest_Id })
                .ForeignKey("dbo.Reservations", t => t.Reservation_Id, cascadeDelete: true)
                .ForeignKey("dbo.Guests", t => t.Guest_Id, cascadeDelete: true)
                .Index(t => t.Reservation_Id)
                .Index(t => t.Guest_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReservationGuests", "Guest_Id", "dbo.Guests");
            DropForeignKey("dbo.ReservationGuests", "Reservation_Id", "dbo.Reservations");
            DropIndex("dbo.ReservationGuests", new[] { "Guest_Id" });
            DropIndex("dbo.ReservationGuests", new[] { "Reservation_Id" });
            DropTable("dbo.ReservationGuests");
            DropTable("dbo.Reservations");
            DropTable("dbo.Guests");
        }
    }
}
