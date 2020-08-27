using Infotech.TestTask.Webapi.Models;
using Microsoft.EntityFrameworkCore;

namespace Infotech.TestTask.Webapi.EntityFrameworkCore
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Person> People {get;set;}
        public DbSet<Car> Cars {get;set;}
        public DbSet<PersonCar> PersonCars {get;set;}

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            //іменування моделей та їх полів дозволяє використати автоконфігурацію зв'язку "множини до множин"
            modelBuilder.Entity<PersonCar>().HasKey(pc => new { pc.PersonId, pc.CarId});
            //або у довгий спосіб (fluent api)
            // modelBuilder.Entity<PersonCar>().HasKey(pc => new { pc.PersonId, pc.CarId});
            // modelBuilder.Entity<PersonCar>()
            //     .HasOne(pc => pc.Person)
            //     .WithMany(p => p.PersonCars)
            //     .HasForeignKey(pc => pc.PersonId);
            // modelBuilder.Entity<PersonCar>()
            //     .HasOne(pc=>pc.Car)
            //     .WithMany(c=>c.PersonCars)
            //     .HasForeignKey(pc=>pc.CarId);
        }
    }
}