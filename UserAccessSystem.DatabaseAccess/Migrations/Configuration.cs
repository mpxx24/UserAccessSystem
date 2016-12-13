using System;
using System.Data.Entity.Migrations;
using UserAccessSystem.DatabaseAccess.Models;

namespace UserAccessSystem.DatabaseAccess.Migrations {
    internal sealed class Configuration : DbMigrationsConfiguration<AppContext> {
        public Configuration() {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AppContext context) {
            //  This method will be called after migrating to the latest version.

            context.Users.AddOrUpdate(new User
            {
                Id = 1,
                FirstName = "Mariusz",
                LastName = "Pi¹tkowski",
                DateOfBirth = new DateTime(1991, 3, 1),
                Nationality = "Poland",
                IsActiveAccount = true,
                IsSuperUser = true,
                LastSubscription = DateTime.Today
            });
            context.Users.AddOrUpdate(new User
            {
                Id = 2,
                FirstName = "Harry",
                LastName = "Hole",
                DateOfBirth = new DateTime(1981, 10, 12),
                Nationality = "Norway",
                IsActiveAccount = true,
                IsSuperUser = false,
                LastSubscription = DateTime.Today.AddDays(-14)
            });
            context.Users.AddOrUpdate(new User
            {
                Id = 3,
                FirstName = "Scot",
                LastName = "Harvath",
                DateOfBirth = new DateTime(1979, 1, 2),
                IsActiveAccount = false,
                IsSuperUser = false,
                LastSubscription = DateTime.Today.AddYears(-2).AddDays(-46)
            });
        }
    }
}