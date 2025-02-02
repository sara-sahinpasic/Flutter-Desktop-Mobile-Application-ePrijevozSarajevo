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
                    UserId = 1,
                    UserStatusId = 2,
                    DateCreated = DateTime.Now,
                    Active = true,
                    Approved = false,
                    RejectionReason = "",
                },
                new Request()
                {
                    RequestId = 6,
                    UserId = 6,
                    UserStatusId = 3,
                    DateCreated = DateTime.Now,
                    Active = true,
                    Approved = false,
                    RejectionReason = "",
                }
            ); //5
            modelBuilder.Entity<Station>().HasData
            (
                new Station()
                {
                    StationId = 1,
                    Name = "Ilidža",
                    ModifiedDate = DateTime.Now,
                    DateCreated = DateTime.Now,
                },
                new Station()
                {
                    StationId = 2,
                    Name = "Stup",
                    ModifiedDate = DateTime.Now,
                    DateCreated = DateTime.Now,

                },
                new Station()
                {
                    StationId = 3,
                    Name = "Nedžarići",
                    DateCreated = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                },
                new Station()
                {
                    StationId = 4,
                    Name = "Socijalno",
                    DateCreated = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                },
                new Station()
                {
                    StationId = 5,
                    Name = "Malta",
                    DateCreated = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                },
                new Station()
                {
                    StationId = 6,
                    Name = "Baščaršija",
                    DateCreated = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                },
                new Station()
                {
                    StationId = 7,
                    Name = "Otoka",
                    DateCreated = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                },
                new Station()
                {
                    StationId = 8,
                    Name = "Skenderija",
                    DateCreated = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                },
                new Station()
                {
                    StationId = 9,
                    Name = "Drvenija",
                    DateCreated = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                },
                new Station()
                {
                    StationId = 10,
                    Name = "Dobrinja",
                    DateCreated = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                },
                new Station()
                {
                    StationId = 11,
                    Name = "Grbavica",
                    DateCreated = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                },
                new Station()
                {
                    StationId = 12,
                    Name = "Hrasno",
                    DateCreated = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                },
                new Station()
                {
                    StationId = 13,
                    Name = "Aneks",
                    DateCreated = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                },
                new Station()
                {
                    StationId = 14,
                    Name = "Alipašino polje",
                    DateCreated = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                },
                 new Station()
                 {
                     StationId = 15,
                     Name = "Švrakino selo",
                     DateCreated = DateTime.Now,
                     ModifiedDate = DateTime.Now,
                 }
            ); //6
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
                    Number = 40,
                    RegistrationNumber = "A16-G-195",
                    BuildYear = 2011,
                    ManufacturerId = 3,
                    TypeId = 2,
                }
            ); //7
            modelBuilder.Entity<Manufacturer>().HasData
            (
                new Manufacturer()
                {
                    ManufacturerId = 1,
                    Name = "MAN",
                    ModifiedDate = DateTime.Now,
                    ManufacturerCountryId = 1,
                },
                new Manufacturer()
                {
                    ManufacturerId = 2,
                    Name = "Solaris",
                    ModifiedDate = DateTime.Now,
                    ManufacturerCountryId = 2,
                },
                new Manufacturer()
                {
                    ManufacturerId = 3,
                    Name = "Volvo",
                    ModifiedDate = DateTime.Now,
                    ManufacturerCountryId = 3,
                },
                new Manufacturer()
                {
                    ManufacturerId = 4,
                    Name = "Mercedes",
                    ModifiedDate = DateTime.Now,
                    ManufacturerCountryId = 4,
                },
                new Manufacturer()
                {
                    ManufacturerId = 5,
                    Name = "Setra",
                    ModifiedDate = DateTime.Now,
                    ManufacturerCountryId = 5,
                },
                new Manufacturer()
                {
                    ManufacturerId = 6,
                    Name = "Neoplan",
                    ModifiedDate = DateTime.Now,
                    ManufacturerCountryId = 6,
                },
                new Manufacturer()
                {
                    ManufacturerId = 7,
                    Name = "Siemens",
                    ModifiedDate = DateTime.Now,
                    ManufacturerCountryId = 7,
                },
                new Manufacturer()
                {
                    ManufacturerId = 8,
                    Name = "Traton",
                    ModifiedDate = DateTime.Now,
                    ManufacturerCountryId = 8,
                },
                new Manufacturer()
                {
                    ManufacturerId = 9,
                    Name = "Tesla",
                    ModifiedDate = DateTime.Now,
                    ManufacturerCountryId = 9,
                }
            ); //8
            modelBuilder.Entity<Type>().HasData
            (
                new Type()
                {
                    TypeId = 1,
                    Name = "Trolejbus",
                    ModifiedDate = DateTime.Now,
                },
                new Type()
                {
                    TypeId = 2,
                    Name = "Tramvaj",
                    ModifiedDate = DateTime.Now,
                },
                new Type()
                {
                    TypeId = 3,
                    Name = "Minibus",
                    ModifiedDate = DateTime.Now,
                },
                new Type()
                {
                    TypeId = 4,
                    Name = "Autobus",
                    ModifiedDate = DateTime.Now,
                },
                new Type()
                {
                    TypeId = 5,
                    Name = "Kombi",
                    ModifiedDate = DateTime.Now,
                }
            ); //9
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
                    RoleId = 2,
                }
            ); //10 
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
            ); //11
            modelBuilder.Entity<Status>().HasData
            (
                  new Status()
                  {
                      StatusId = 1,
                      Name = "Default",
                      Discount = 0.0,
                      ModifiedDate = DateTime.Now,

                  },
                 new Status()
                 {
                     StatusId = 2,
                     Name = "Student",
                     Discount = 0.3,
                     ModifiedDate = DateTime.Now,

                 },
                new Status()
                {
                    StatusId = 3,
                    Name = "Penzioner",
                    Discount = 0.5,
                    ModifiedDate = DateTime.Now,
                },
                 new Status()
                 {
                     StatusId = 4,
                     Name = "Zaposlenik",
                     Discount = 0.15,
                     ModifiedDate = DateTime.Now,
                 },
                 new Status()
                 {
                     StatusId = 5,
                     Name = "Nezaposlen",
                     Discount = 0.4,
                     ModifiedDate = DateTime.Now,
                 }
            ); //12
            modelBuilder.Entity<Ticket>().HasData
            (
                 new Ticket()
                 {
                     TicketId = 1,
                     Name = "Jednosmjerna",
                     Price = 1.80,
                     StateMachine = "draft",
                     ModifiedDate = DateTime.Now,
                 },
                new Ticket()
                {
                    TicketId = 2,
                    Name = "Povratna",
                    Price = 3.20,
                    StateMachine = "draft",
                    ModifiedDate = DateTime.Now,
                },
                new Ticket()
                {
                    TicketId = 3,
                    Name = "Jednosmjerna dječija",
                    Price = 0.80,
                    StateMachine = "draft",
                    ModifiedDate = DateTime.Now,
                },
                new Ticket()
                {
                    TicketId = 4,
                    Name = "Povratna dječija",
                    Price = 1.20,
                    StateMachine = "draft",
                    ModifiedDate = DateTime.Now,
                },
                new Ticket()
                {
                    TicketId = 5,
                    Name = "Mjesečna",
                    Price = 75,
                    StateMachine = "draft",
                    ModifiedDate = DateTime.Now,
                }
            ); //13
            modelBuilder.Entity<Malfunction>().HasData
            (
               new Malfunction()
               {
                   MalfunctionId = 1,
                   Description = "Opis kvara: Test 1",
                   DateOfMalufunction = DateTime.Now,
                   Fixed = true,
                   VehicleId = 1,
                   StationId = 1,
                   ModifiedDate = DateTime.Now,

               },
                new Malfunction()
                {
                    MalfunctionId = 2,
                    Description = "Opis kvara: Test 2",
                    DateOfMalufunction = DateTime.Now,
                    Fixed = false,
                    VehicleId = 2,
                    StationId = 2,
                    ModifiedDate = DateTime.Now,

                },
                 new Malfunction()
                 {
                     MalfunctionId = 3,
                     Description = "Opis kvara: Test 3",
                     DateOfMalufunction = DateTime.Now,
                     Fixed = true,
                     VehicleId = 3,
                     StationId = 3,
                     ModifiedDate = DateTime.Now,

                 }
            );//14
            modelBuilder.Entity<Delay>().HasData
           (
              new Delay()
              {
                  DelayId = 1,
                  Reason = "Gužva",
                  RouteId = 1,
                  DelayAmountMinutes = 30,
                  TypeId = 1,
                  ModifiedDate = DateTime.Now,

              },
               new Delay()
               {
                   DelayId = 2,
                   Reason = "Udes",
                   RouteId = 2,
                   DelayAmountMinutes = 60,
                   TypeId = 2,
                   ModifiedDate = DateTime.Now,

               }, new Delay()
               {
                   DelayId = 3,
                   Reason = "Led",
                   RouteId = 3,
                   DelayAmountMinutes = 15,
                   TypeId = 1,
                   ModifiedDate = DateTime.Now,

               }
           );//15
             //-------------
            modelBuilder.Entity<VrijednostRaspolozenja>().HasData
        (
           new VrijednostRaspolozenja()
           {
               VrijednostRaspolozenjaId = 1,
               Naziv = "Sretan"
           },
            new VrijednostRaspolozenja()
            {
                VrijednostRaspolozenjaId = 2,
                Naziv = "Tuzan"
            }, new VrijednostRaspolozenja()
            {
                VrijednostRaspolozenjaId = 3,
                Naziv = "Pod stresom"
            },
             new VrijednostRaspolozenja()
             {
                 VrijednostRaspolozenjaId = 4,
                 Naziv = "Uzbuđen"
             }, new VrijednostRaspolozenja()
             {
                 VrijednostRaspolozenjaId = 5,
                 Naziv = "Umoran"
             }
           );

            modelBuilder.Entity<MoodTracker30012025>().HasData
       (
          new MoodTracker30012025()
          {
              MoodTracker30012025Id = 1,
              UserId = 1,
              VrijednostRaspolozenjaId = 1,
              Opis = "Test",
              DatumEvidencije = DateTime.Now,
          },
           new MoodTracker30012025()
           {
               MoodTracker30012025Id = 2,
               UserId = 2,
               VrijednostRaspolozenjaId = 2,
               Opis = "Test",
               DatumEvidencije = DateTime.Now,
           }, new MoodTracker30012025()
           {
               MoodTracker30012025Id = 3,
               UserId = 3,
               VrijednostRaspolozenjaId = 3,
               Opis = "Test",
               DatumEvidencije = DateTime.Now,
           }
           );


        }
    }
}
