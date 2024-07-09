using Microsoft.EntityFrameworkCore;

namespace ePrijevozSarajevo.Services.Database
{
    partial class DataContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Station>().HasData //1
            (
                new Station()
                {
                    StationId = 1,
                    Name="Ilidža"
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
            );
            modelBuilder.Entity<Holiday>().HasData //2
            (
                new Holiday()
                {
                    HolidayId = 1,
                    Name = "Bajram",
                    Date = new DateTime(2024, 04, 10)
                },
                new Holiday()
                {
                    HolidayId = 2,
                    Name = "Nova godina",
                    Date = new DateTime(2024, 01, 01)
                },
                new Holiday()
                {
                    HolidayId = 3,
                    Name = "Božić",
                    Date = new DateTime(2024, 12, 25)
                }
            );
            modelBuilder.Entity<Vehicle>().HasData //3
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
            );
            modelBuilder.Entity<Manufacturer>().HasData //4
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
            );
            modelBuilder.Entity<Type>().HasData //5
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
            );
            modelBuilder.Entity<UserRole>().HasData //6 nereferentna
            (
                new UserRole()
                {
                    UserRoleId = 1,
                    UserId = 1,
                    RoleId = 1,
                    ModificationDate = DateTime.Now
                },
                new UserRole()
                {
                    UserRoleId = 2,
                    UserId = 2,
                    RoleId = 2,
                    ModificationDate = DateTime.Now
                }
            );
            modelBuilder.Entity<Role>().HasData //7
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
            );
            modelBuilder.Entity<Status>().HasData //8
            (
                 new Status()
                 {
                     StatusId = 1,
                     Name = "Student",
                     Discount = 0.3,

                 },
                new Status()
                {
                   StatusId = 2,
                   Name = "Pensioner",
                   Discount = 0.5
                },
                 new Status()
                 {
                     StatusId = 3,
                     Name = "Employed",
                     Discount = 0.15
                 },
                 new Status()
                 {
                     StatusId = 4,
                     Name = "Unemployed",
                     Discount = 0.4
                 }
            );
            modelBuilder.Entity<Ticket>().HasData //9
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
            );

        }
    }
}
