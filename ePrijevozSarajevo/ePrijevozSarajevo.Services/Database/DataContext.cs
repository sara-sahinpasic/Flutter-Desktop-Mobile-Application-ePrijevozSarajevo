using Microsoft.EntityFrameworkCore;
using System.Net;
using System;
using ePrijevozSarajevo.Model;

namespace ePrijevozSarajevo.Services.Database
{
    public partial class DataContext : DbContext
    {
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<Ticket> Tickets { get; set; } = null!;
        public DbSet<Status> Statuses { get; set; } = null!;
        public DbSet<IssuedTicket> IssuedTickets { get; set; } = null!;
        public DbSet<Station> Stations { get; set; } = null!;
        public DbSet<Route> Routes { get; set; } = null!;
        public DbSet<Request> Requests { get; set; } = null!;
        public DbSet<UserRole> UserRoles { get; set; } = null!;
        public DbSet<Vehicle> Vehicles { get; set; } = null!;
        public DbSet<Manufacturer> Manufacturers { get; set; } = null!;
        public DbSet<Type> Types { get; set; } = null!;
        public DbSet<Country> Countries { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Data Source=localhost; Initial Catalog=140261; user=sa; Password=ePrijevoz123!;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
     => optionsBuilder.UseSqlServer("Data Source=localhost; Initial Catalog=140261; user=sa; Password=QWEasd123!;" +
         "Trusted_Connection=True;TrustServerCertificate=True");
        */

        protected override void OnModelCreating(ModelBuilder modelBuilder) //10
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vehicle>()
                .HasIndex(v => v.RegistrationNumber)
                .IsUnique();

            modelBuilder.Entity<User>()
               .HasIndex(u => u.Email)
               .IsUnique();

            modelBuilder.Entity<User>()
               .HasIndex(u => u.UserName)
               .IsUnique();

            modelBuilder.Entity<Status>()
                .Property(p => p.Discount)
                .HasPrecision(5, 2);

            modelBuilder.Entity<User>()
                .HasOne(user => user.UserStatus)
                .WithMany()
                .HasForeignKey(user => user.UserStatusId);

            modelBuilder.Entity<Request>()
                .HasOne(request => request.UserStatus)
                .WithMany()
                .HasForeignKey(r => r.UserStatusId);

            modelBuilder.Entity<Route>()
                .HasOne(r => r.StartStation)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Route>()
                .HasOne(r => r.EndStation)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            BuildIssuedTickets(modelBuilder);
            BuildRoutes(modelBuilder);
            BuildUsers(modelBuilder);
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        private const string DefaultUserPassword = "test";
        private static void BuildUsers(ModelBuilder modelBuilder)
        {
            List<User> users = new()
            {
               new()
               {
                UserId = 1,
                FirstName = "Sara",
                LastName = "Šahinpašić",
                UserName = "desktop",
                Email = "sara.sahinpasic@edu.fit.ba",
                PasswordSalt = UserService.GenerateSalt(),
                DateOfBirth = new DateTime(1998, 03, 25),
                PhoneNumber = "061222333",
                Address = "Adresa 11",
                ZipCode="71000",
                City ="Sarajevo",
                UserCountryId =1,
                RegistrationDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                UserStatusId = 4,
                ProfileImage = null,
                StatusExpirationDate = new DateTime(2025, 12, 31)
               },
               new()
               {
                UserId = 2,
                FirstName = "Senada",
                LastName = "Šahinpašić",
                UserName = "mobile",
                Email = "sara.sahinpasic@hotmail.com",
                PasswordSalt = UserService.GenerateSalt(),
                DateOfBirth = new DateTime(1988, 10, 26),
                PhoneNumber = "061222444",
                Address = "Adresa 12",
                ZipCode="72000",
                City ="Zenica",
                UserCountryId =1,
                RegistrationDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                UserStatusId = 4,
                ProfileImage = null,
                StatusExpirationDate = new DateTime(2025, 12, 31)
               },
               new()
               {
                UserId = 3,
                FirstName = "Test",
                LastName = "Testni",
                UserName = "mobile1",
                Email = "neki@mail.com",
                PasswordSalt = UserService.GenerateSalt(),
                DateOfBirth = new DateTime(1975, 05, 06),
                PhoneNumber = "061222555",
                Address = "Adresa 14",
                ZipCode="90408",
                City ="Nürnberg",
                UserCountryId =2,
                RegistrationDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                UserStatusId = 1,
                ProfileImage = null,
                StatusExpirationDate = new DateTime(2025, 12, 31)
               },
               new()
               {
                UserId = 4,
                FirstName = "Testni",
                LastName = "Test",
                UserName = "mobile2",
                Email = "neko@mail.com",
                PasswordSalt = UserService.GenerateSalt(),
                DateOfBirth = new DateTime(1965, 07, 14),
                PhoneNumber = "061222666",
                Address = "Adresa 15",
                ZipCode="1010",
                City ="Wien",
                UserCountryId =3,
                RegistrationDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                UserStatusId = 1,
                ProfileImage = null,
                StatusExpirationDate = new DateTime(2025, 12, 31)
               },
               new()
               {
                UserId = 5,
                FirstName = "Proba",
                LastName = "Probni",
                UserName = "mobile3",
                Email = "proba@mail.com",
                PasswordSalt = UserService.GenerateSalt(),
                DateOfBirth = new DateTime(1982, 04, 27),
                PhoneNumber = "061222777",
                Address = "Adresa 16",
                ZipCode="1160",
                City ="Wien",
                UserCountryId =3,
                RegistrationDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                UserStatusId = 1,
                ProfileImage = null,
                StatusExpirationDate = new DateTime(2025, 12, 31)
               },
               new()
               {
                UserId = 6,
                FirstName = "Probe",
                LastName = "Probno",
                UserName = "mobile4",
                Email = "probe@mail.com",
                PasswordSalt = UserService.GenerateSalt(),
                DateOfBirth = new DateTime(1996, 02, 07),
                PhoneNumber = "061222888",
                Address = "Adresa 17",
                ZipCode="80331",
                City ="Munich",
                UserCountryId =2,
                RegistrationDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                UserStatusId = 1,
                ProfileImage = null,
                StatusExpirationDate = new DateTime(2025, 12, 31)
               },
            };

            foreach (var user in users)
            {
                user.PasswordHash = UserService.GenerateHash(user.PasswordSalt, DefaultUserPassword);

            }

            modelBuilder.Entity<User>()
                .HasData(users);
        } //1
        private static void BuildIssuedTickets(ModelBuilder modelBuilder)
        {
            List<IssuedTicket> issuedTickets = new();
            var random = new Random();
            int totalIssuedTickets = 100;
            int maxUsers = 6;
            int maxTickets = 5;
            int maxRoutes = 100;

            for (int i = 1; i <= totalIssuedTickets; i++)
            {
                int userId = random.Next(1, maxUsers + 1);
                int ticketId = random.Next(1, maxTickets + 1);
                int routeId = random.Next(1, maxRoutes + 1);

                int year = DateTime.Now.Year - random.Next(0, 2); // current year or last year
                int month = random.Next(1, 13);
                int day = random.Next(1, DateTime.DaysInMonth(year, month) + 1);

                DateTime issuedDate = new DateTime(year, month, day);
                DateTime validFrom = issuedDate;
                DateTime validTo;

                switch (ticketId)
                {
                    case 1: // 60 minutes
                    case 3: // 60 minutes
                        validTo = validFrom.AddMinutes(60);
                        break;
                    case 2: // 180 minutes
                    case 4: // 180 minutes
                        validTo = validFrom.AddMinutes(180);
                        break;
                    case 5: // 1 month (31 days)
                        validTo = validFrom.AddDays(31);
                        break;
                    default:
                        validTo = validFrom.AddHours(random.Next(60, 731)); // default range: 1 day to 1 month
                        break;
                }
                issuedTickets.Add(new IssuedTicket()
                {
                    IssuedTicketId = i,
                    UserId = userId,
                    TicketId = ticketId,
                    ValidFrom = validFrom,
                    ValidTo = validTo,
                    IssuedDate = issuedDate,
                    Amount = random.Next(1, 20),
                    RouteId = routeId
                });
            }
            modelBuilder.Entity<IssuedTicket>()
              .HasData(issuedTickets);
        } //2
         private static void BuildRoutes(ModelBuilder modelBuilder)
         {
             List<Route> routes = new();
             var random = new Random();

             int totalRoutes = 100;
             int totalStations = 15;
             int totalVehicles = 6;

             for (int i = 1; i <= totalRoutes; i++)
             {
                 int startStationId = random.Next(1, totalStations + 1);
                 int endStationId;
                 do
                 {
                     endStationId = random.Next(1, totalStations + 1);
                 } while (endStationId == startStationId);

                 DateTime startDate = new DateTime(2024, 11, 01);
                 DateTime endDate = new DateTime(2024, 12, 31);

                 int range = (endDate - startDate).Days;
                 DateTime randomDate = startDate.AddDays(random.Next(range));

                 int departureHour = random.Next(5, 24);
                 int departureMinute = random.Next(0, 60);
                 DateTime departure = new DateTime(randomDate.Year, randomDate.Month, randomDate.Day, departureHour, departureMinute, 0);

                 DateTime arrival = departure.AddMinutes(random.Next(10, 60)); // between 10 minutes and 1 hour after departure

                 routes.Add(new Route()
                 {
                     RouteId = i,
                     StartStationId = startStationId,
                     EndStationId = endStationId,
                     VehicleId = random.Next(1, totalVehicles + 1),
                     Departure = departure,
                     Arrival = arrival
                 });
             }
             modelBuilder.Entity<Route>()
                .HasData(routes);
         } //3
        /* private static void BuildRoutes(ModelBuilder modelBuilder)
         {
             List<Route> routes = new();
             var random = new Random();

             int totalStations = 15;
             int totalVehicles = 6;
             int routeId = 1;

             // allowed departure days of the month
             int[] allowedDays = { 5, 10, 15, 20, 25 };

             DateTime startDate = new DateTime(2024, 12, 01);
             DateTime endDate = new DateTime(2025, 03, 01); 

             foreach (var month in Enumerable.Range(startDate.Month, endDate.Month - startDate.Month + 1))
             {
                 foreach (var day in allowedDays)
                 {
                     foreach (int startStationId in Enumerable.Range(1, totalStations))
                     {
                         foreach (int endStationId in Enumerable.Range(1, totalStations))
                         {
                             if (startStationId == endStationId) continue; // skip if stations are the same

                             DateTime departureDate;
                             try
                             {
                                 departureDate = new DateTime(startDate.Year, month, day);
                             }
                             catch
                             {
                                 // skip invalid days like Feb 30
                                 continue;
                             }

                             int departureHour = random.Next(5, 24);
                             int departureMinute = random.Next(0, 60);
                             DateTime departure = new DateTime(departureDate.Year, departureDate.Month, departureDate.Day, departureHour, departureMinute, 0);

                             DateTime arrival = departure.AddMinutes(random.Next(10, 60)); // between 10 minutes and 1 hour after departure

                             routes.Add(new Route()
                             {
                                 RouteId = routeId++,
                                 StartStationId = startStationId,
                                 EndStationId = endStationId,
                                 VehicleId = random.Next(1, totalVehicles + 1),
                                 Departure = departure,
                                 Arrival = arrival
                             });
                         }
                     }
                 }
             }

             modelBuilder.Entity<Route>().HasData(routes);
         }//3*/
       /* private static void BuildRoutes(ModelBuilder modelBuilder)
        {
            List<Route> routes = new();
            var random = new Random();

            int totalStations = 15;
            int totalVehicles = 6;
            int routeId = 1;

            // Define the allowed departure days of the month
            int[] allowedDays = { 5, 10, 15, 20, 25 };

            DateTime startDate = new DateTime(2024, 12, 01);
            DateTime endDate = new DateTime(2025, 02, 29); // Leap year ensures February 29 exists

            for (var currentDate = startDate; currentDate <= endDate; currentDate = currentDate.AddMonths(1))
            {
                foreach (var day in allowedDays)
                {
                    // Ensure the day exists in the current month
                    if (day > DateTime.DaysInMonth(currentDate.Year, currentDate.Month)) continue;

                    foreach (int startStationId in Enumerable.Range(1, totalStations))
                    {
                        foreach (int endStationId in Enumerable.Range(1, totalStations))
                        {
                            if (startStationId == endStationId) continue; // Skip if stations are the same

                            // Safely create a departure date
                            DateTime departureDate = new DateTime(currentDate.Year, currentDate.Month, day);

                            // Generate random departure time
                            int departureHour = random.Next(5, 24);
                            int departureMinute = random.Next(0, 60);
                            DateTime departure = new DateTime(departureDate.Year, departureDate.Month, departureDate.Day, departureHour, departureMinute, 0);

                            // Generate random arrival time between 10 minutes and 1 hour after departure
                            DateTime arrival = departure.AddMinutes(random.Next(10, 60));

                            routes.Add(new Route()
                            {
                                RouteId = routeId++,
                                StartStationId = startStationId,
                                EndStationId = endStationId,
                                VehicleId = random.Next(1, totalVehicles + 1),
                                Departure = departure,
                                Arrival = arrival
                            });
                        }
                    }
                }
            }

            modelBuilder.Entity<Route>().HasData(routes);
        }*/



    }
}
