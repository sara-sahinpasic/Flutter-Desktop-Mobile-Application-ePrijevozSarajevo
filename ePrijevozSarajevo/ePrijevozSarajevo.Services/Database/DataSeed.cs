using ePrijevozSarajevo.Model;
using Microsoft.EntityFrameworkCore;

namespace ePrijevozSarajevo.Services.Database
{
    partial class DataContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Request>().HasData
            (
                new Request()
                {
                    RequestId = 1,
                    UserId = 2,
                    UserStatusId = 3,
                    DateCreated = DateTime.Now,
                    Active = true,
                    Approved = false,
                    RejectionReason = "",
                },
                new Request()
                {
                    RequestId = 2,
                    UserId = 3,
                    UserStatusId = 5,
                    DateCreated = DateTime.Now,
                    Active = true,
                    Approved = false,
                    RejectionReason = "",
                },
                new Request()
                {
                    RequestId = 3,
                    UserId = 4,
                    UserStatusId = 2,
                    DateCreated = DateTime.Now,
                    Active = true,
                    Approved = false,
                    RejectionReason = "",
                },
                new Request()
                {
                    RequestId = 4,
                    UserId = 5,
                    UserStatusId = 4,
                    DateCreated = DateTime.Now,
                    Active = true,
                    Approved = false,
                    RejectionReason = "",
                },
                new Request()
                {
                    RequestId = 5,
                    UserId = 6,
                    UserStatusId = 2,
                    DateCreated = DateTime.Now,
                    Active = true,
                    Approved = false,
                    RejectionReason = "",
                }
             ); //4
            modelBuilder.Entity<Station>().HasData
            (
                new Station()
                {
                    StationId = 1,
                    Name = "Ilidža"
                },
                new Station()
                {
                    StationId = 2,
                    Name = "Stup"
                },
                new Station()
                {
                    StationId = 3,
                    Name = "Nedžarići"
                },
                new Station()
                {
                    StationId = 4,
                    Name = "Socijalno"
                },
                new Station()
                {
                    StationId = 5,
                    Name = "Malta"
                },
                new Station()
                {
                    StationId = 6,
                    Name = "Baščaršija"
                },
                //
                new Station()
                {
                    StationId = 7,
                    Name = "Otoka"
                },

                new Station()
                {
                    StationId = 8,
                    Name = "Skenderija"
                },
                new Station()
                {
                    StationId = 9,
                    Name = "Drvenija"
                },
                //
                new Station()
                {
                    StationId = 10,
                    Name = "Dobrinja"
                },
                new Station()
                {
                    StationId = 11,
                    Name = "Grbavica"
                },
                new Station()
                {
                    StationId = 12,
                    Name = "Hrasno"
                },
                new Station()
                {
                    StationId = 13,
                    Name = "Aneks"
                },
                new Station()
                {
                    StationId = 14,
                    Name = "Alipašino polje"
                },
                 new Station()
                 {
                     StationId = 15,
                     Name = "Švrakino selo"
                 }
            ); //5
            modelBuilder.Entity<Vehicle>().HasData
            (
                new Vehicle()
                {
                    VehicleId = 1,
                    Number = 15,
                    RegistrationNumber = "A10-B-123",
                    BuildYear = 2005,
                    ManufacturerId = 1,
                    TypeId = 1,
                },
                new Vehicle()
                {
                    VehicleId = 2,
                    Number = 20,
                    RegistrationNumber = "A11-C-124",
                    BuildYear = 2015,
                    ManufacturerId = 2,
                    TypeId = 2,
                },
                new Vehicle()
                {
                    VehicleId = 3,
                    Number = 25,
                    RegistrationNumber = "A12-D-154",
                    BuildYear = 2010,
                    ManufacturerId = 3,
                    TypeId = 1,
                },
                new Vehicle()
                {
                    VehicleId = 4,
                    Number = 30,
                    RegistrationNumber = "A14-E-174",
                    BuildYear = 2007,
                    ManufacturerId = 4,
                    TypeId = 2,
                },
                new Vehicle()
                {
                    VehicleId = 5,
                    Number = 35,
                    RegistrationNumber = "A15-F-183",
                    BuildYear = 2014,
                    ManufacturerId = 4,
                    TypeId = 1,
                },
                new Vehicle()
                {
                    VehicleId = 6,
                    Number = 35,
                    RegistrationNumber = "A16-G-195",
                    BuildYear = 2011,
                    ManufacturerId = 3,
                    TypeId = 2,
                }
            ); //6
            modelBuilder.Entity<Manufacturer>().HasData
            (
                new Manufacturer()
                {
                    ManufacturerId = 1,
                    Name = "MAN"
                },
                new Manufacturer()
                {
                    ManufacturerId = 2,
                    Name = "Solaris"
                },
                new Manufacturer()
                {
                    ManufacturerId = 3,
                    Name = "Volvo"
                },
                new Manufacturer()
                {
                    ManufacturerId = 4,
                    Name = "Mercedes"
                }
            ); //7
            modelBuilder.Entity<Type>().HasData
            (
                new Type()
                {
                    TypeId = 1,
                    Name = "Trolleybus"
                },
                new Type()
                {
                    TypeId = 2,
                    Name = "Tram"
                }
            ); //8
            modelBuilder.Entity<UserRole>().HasData
            (
                new UserRole()
                {
                    UserRoleId = 1,
                    UserId = 1,
                    RoleId = 1,
                },
                new UserRole()
                {
                    UserRoleId = 2,
                    UserId = 2,
                    RoleId = 2,
                },
                new UserRole()
                {
                    UserRoleId = 3,
                    UserId = 3,
                    RoleId = 2,
                }, new UserRole()
                {
                    UserRoleId = 4,
                    UserId = 4,
                    RoleId = 1,
                }, new UserRole()
                {
                    UserRoleId = 5,
                    UserId = 5,
                    RoleId = 2,
                },
                new UserRole()
                {
                    UserRoleId = 6,
                    UserId = 6,
                    RoleId = 1,
                }
            ); //9 
            modelBuilder.Entity<Role>().HasData
            (
                 new Role()
                 {
                     RoleId = 1,
                     Name = "Admin"
                 },
                new Role()
                {
                    RoleId = 2,
                    Name = "User"
                }
            ); //10
            modelBuilder.Entity<Status>().HasData
            (
                  new Status()
                  {
                      StatusId = 1,
                      Name = "Default",
                      Discount = 0.0,

                  },
                 new Status()
                 {
                     StatusId = 2,
                     Name = "Student",
                     Discount = 0.3,

                 },
                new Status()
                {
                    StatusId = 3,
                    Name = "Penzioner",
                    Discount = 0.5
                },
                 new Status()
                 {
                     StatusId = 4,
                     Name = "Zaposlenik",
                     Discount = 0.15
                 },
                 new Status()
                 {
                     StatusId = 5,
                     Name = "Nezaposlen",
                     Discount = 0.4
                 }
            ); //11
            modelBuilder.Entity<Ticket>().HasData
            (
                 new Ticket()
                 {
                     TicketId = 1,
                     Name = "Jednosmjerna",
                     Price = 1.80,
                     StateMachine = "draft"
                 },
                new Ticket()
                {
                    TicketId = 2,
                    Name = "Povratna",
                    Price = 3.20,
                    StateMachine = "draft"
                },
                new Ticket()
                {
                    TicketId = 3,
                    Name = "Jednosmjerna dječija",
                    Price = 0.80,
                    StateMachine = "draft"
                },
                new Ticket()
                {
                    TicketId = 4,
                    Name = "Povratna dječija",
                    Price = 1.20,
                    StateMachine = "draft"
                },
                new Ticket()
                {
                    TicketId = 5,
                    Name = "Mjesečna",
                    Price = 75,
                    StateMachine = "draft"
                }
            ); //12
            modelBuilder.Entity<Country>().HasData
            (
               new Country()
               {
                   CountryId = 1,
                   Name = "Bosnia and Herzegovina",
               },
               new Country()
               {
                    CountryId = 2,
                    Name = "Germany",
               },
               new Country()
               {
                     CountryId = 3,
                     Name = "Austria",
               },
               new Country()
               {
                     CountryId = 4,
                     Name = "Croatia",
               },
               new Country()
               {
                     CountryId = 5,
                     Name = "Serbia",
               }, 
               new Country()
               {
                    CountryId = 6,
                    Name = "Slovenia",
               },
               new Country()
               {
                    CountryId = 7,
                    Name = "Montenegro",
               },
               new Country()
                {
                    CountryId = 8,
                    Name = "Albania",
               },
               new Country()
               {
                    CountryId = 9,
                    Name = "China",
               },
               new Country()
               {
                    CountryId = 10,
                    Name = "Japan",
               }
          ); //13

        }
    }
}
