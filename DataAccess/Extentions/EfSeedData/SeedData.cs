using Entities.Concreate;
using Entitites.Concreate;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Extentions.EfSeedData
{
    public static class SeedData
    {
        public static void SeedCity(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(

                new City() { CityID=01,Name="Adana"},
                 new City() { CityID = 02, Name = "Ankara" },
                  new City() { CityID = 03, Name = "İzmir" },
                   new City() { CityID = 04, Name = "Muğla" },
                   new City() { CityID = 05, Name = "İstanbul" },
                   new City() { CityID = 06, Name = "Eskişehir" },
                   new City() { CityID = 07, Name = "Edirne" }




                );

        }

        public static void SeedCategory(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    CategoryID = 1,
                    CategoryName = "Konserler",
                },
              new Category()
              {
                  CategoryID = 2,
                  CategoryName = "Tiyatro Oyunları"
              },
                    new Category()
                    {
                        CategoryID = 3,
                        CategoryName = "Bisiklet Turları"
                    },
                        new Category()
                        {
                            CategoryID = 4,
                            CategoryName = "Piknikler"
                        }


                );

        }

        //public static void SeedEvent(this ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Event>().HasData(
        //       new Event()
        //       {
        //           EvenetID = 1,
        //           CategoryID = 1,
        //           Name = "Tarkan Konseri",
        //           DateTime = new DateTime(2023, 12, 25),
        //           Description = "Muhteşem bir konser seni bekliyor",
        //           Quoto=3000,
        //           CityID = 01,
        //           Id= "6efaf626-cc7b-4916-8134-2baeee988b70",
        //           IsConfirmed= false,
        //           LeftTickets=3000


        //       });
        //}
        public static void SeedUser(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().HasData(
               new UserRole()
               {
                   Id = "fab4fac1-c546-41de-aebc-a14da6895711",
                   Name = "Admin",
                   ConcurrencyStamp = "1",
                   NormalizedName = "Admin"
               },
                new UserRole()
                {
                    Id = "c7b013f0-5201-4317-abd8-c211f91b7330",
                    Name = "User",
                    ConcurrencyStamp = "2",
                    NormalizedName = "User"
                }
               );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(

                new IdentityUserRole<string>()
                {
                    RoleId = "fab4fac1-c546-41de-aebc-a14da6895711",
                    UserId = "b74ddd14-6340-4840-95c2-db12554843e5"
                }

                );

            User user = new User()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                FirstName = "Admin",
                LastName = "Admin",
                Email = "omfasaglam@gmail.com",
                NormalizedEmail = "OMFASAGLAM@GMAIL.COM"


            };
            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            user.PasswordHash = passwordHasher.HashPassword(user, "Admin*123");


            modelBuilder.Entity<User>().HasData(user);



        }
    }
    
}
