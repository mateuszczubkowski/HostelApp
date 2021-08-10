namespace HostelApp.Migrations
{
    using Bogus;
    using Bogus.Extensions;
    using HostelApp.Helpers.Enums;
    using HostelApp.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HostelApp.Data.HostelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HostelApp.Data.HostelContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            var guestGenerator = new Faker<Guest>()
                .RuleFor(g => g.Id, f => Guid.NewGuid())
                .RuleFor(g => g.FirstName, f => f.Name.FirstName())
                .RuleFor(g => g.SecondName, f => f.Name.LastName())
                .RuleFor(g => g.Email, (f, g) => f.Internet.Email(g.FirstName, g.SecondName))
                .RuleFor(g => g.BirthdayDate, f => f.Date.Between(new DateTime(1960, 1, 1), new DateTime(2001, 12, 31)).OrNull(f, .5f))
                .RuleFor(g => g.PostalCode, f => f.Address.ZipCode().OrNull(f, .5f))
                //After model update
                .RuleFor(g => g.PhoneNumber, f => f.Person.Phone.OrNull(f, .6f))
                .RuleFor(g => g.Address, f => f.Address.StreetAddress().OrNull(f, .5f))
                .RuleFor(g => g.City, f => f.Address.City().OrNull(f, .5f));

            var reservationGenerator = new Faker<Reservation>()
                .RuleFor(r => r.Id, f => Guid.NewGuid())
                .RuleFor(r => r.ReservationCode, f => f.Random.String(f.Random.Number(6, 10)))
                .RuleFor(r => r.CreatedAt, f => f.Date.Recent())
                .RuleFor(r => r.Price, f => f.Random.Double(50, 1000))
                .RuleFor(r => r.CheckInDate, f => f.Date.Between(new DateTime(2020, 1, 1), new DateTime(2022, 12, 31)))
                .RuleFor(r => r.CheckOutDate, (f, r) => f.Date.Between(r.CheckInDate, r.CheckInDate.AddDays(f.Random.Int(1, 14))))
                .RuleFor(r => r.CurrencyType, f => f.PickRandom<CurrencyType>())
                .RuleFor(r => r.Commission, f => f.Random.Double(0, 15).OrNull(f, .5f))
                .RuleFor(r => r.Source, f => f.Random.String(12).OrNull(f, .5f));

            var guests = guestGenerator.Generate(20);
            //For future method
            guests.Add(new Guest() { Id = Guid.NewGuid(), FirstName = "Piotr", SecondName = "Nowak", BirthdayDate = new DateTime(1990, 4, 17), Email = "p.nowak@mail.com" });

            var reservations = reservationGenerator.Generate(40);

            //Relations
            var i = 0;
            foreach (var guest in guests)
            {
                var reservationsToAdd = reservations.GetRange(i, 2);

                i++;
                if (i + 2 > 40) i = 0;

                foreach (var reservation in reservationsToAdd)
                {
                    guest.Reservations.Add(reservation);
                }
            }

            context.Guests.AddRange(guests);
            context.Reservations.AddRange(reservations);

            context.SaveChanges();
        }
    }
}
