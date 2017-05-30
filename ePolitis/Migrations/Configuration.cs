namespace ePolitis.Migrations
{
    using ePolitis.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ePolitis.Models.MyModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ePolitis.Models.MyModel context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

           // context.Unemployeds.AddOrUpdate(
           //    x => x.Afm  ,
           //    new Unemployed { Afm=123456789, },
           //    new Unemployed { Email = "maritsa@gmail.com", Password = "123456", FirstName = "Marika", LastName = "Bekatorou", IsCivilServant = true },
           //    new Unemployed { Email = "ioannic@gmail.com", Password = "54321", FirstName = "Ioannis", LastName = "Chiliggiris", IsCivilServant = true }
           //);

           // context.Employees.AddOrUpdate(
           //    x => x.Email,
           //    new Employee { Email = "kaiti@gmail.com", Password = "12345", FirstName = "Kaitoula", LastName = "Kenourgiou", IsCivilServant = true },
           //    new Employee { Email = "maritsa@gmail.com", Password = "123456", FirstName = "Marika", LastName = "Bekatorou", IsCivilServant = true },
           //    new Employee { Email = "ioannic@gmail.com", Password = "54321", FirstName = "Ioannis", LastName = "Chiliggiris", IsCivilServant = true }
           //);

            context.Users.AddOrUpdate(
               x => x.Email,
               new User { Email = "kaiti@gmail.com", Password = "12345", FirstName="Kaitoula", LastName="Kenourgiou", IsCivilServant=true },
               new User { Email = "maritsa@gmail.com", Password = "123456", FirstName = "Marika", LastName = "Bekatorou", IsCivilServant = true },
               new User { Email = "ioannic@gmail.com", Password = "54321", FirstName = "Ioannis", LastName = "Chiliggiris", IsCivilServant = true }
           );

            context.SaveChanges();
        }
    }
}
