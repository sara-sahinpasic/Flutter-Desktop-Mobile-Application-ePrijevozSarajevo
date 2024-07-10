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
        public DbSet<PaymentMethod> PaymentOptions { get; set; } = null!;
        public DbSet<Status> Statuses { get; set; } = null!;
        public DbSet<IssuedTicket> IssuedTickets { get; set; } = null!;
        public DbSet<Station> Stations { get; set; } = null!;
        public DbSet<Route> Routes { get; set; } = null!;
        public DbSet<Request> Requests { get; set; } = null!;
        public DbSet<UserRole> UserRoles { get; set; } = null!;
        public DbSet<Vehicle> Vehicles { get; set; } = null!;
        public DbSet<Manufacturer> Manufacturers { get; set; } = null!;
        public DbSet<Type> Types { get; set; } = null!;
        public DbSet<Holiday> Holidays { get; set; } = null!;



        /* protected override void OnConfiguring(DbContextOptionsBuilder options)
         {
             if (!options.IsConfigured)
             {
                 options.UseSqlServer("Server=.;Database=140261;Trusted_Connection=True;Encrypt=False;");
             }
         }
        */
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
                .HasOne(user => user.UserStatus)
                .WithMany()
                .HasForeignKey(user => user.UserStatusId);

            modelBuilder.Entity<Request>()
                .HasOne(request => request.UserStatus)
                .WithMany()
                .HasForeignKey(r => r.UserStatusId);

            modelBuilder.Entity<Status>()
                .Property(p => p.Discount)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Route>()
                .HasOne(r => r.StartStation)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Route>()
                .HasOne(r => r.EndStation)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            /*modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.UserRoleId);

                entity.ToTable("KorisniciUloge");

                entity.Property(e => e.UserRoleId).HasColumnName("UserRoleId");
                entity.Property(e => e.ModificationDate).HasColumnType("datetime");
                entity.Property(e => e.User).HasColumnName("UserId");
                entity.Property(e => e.Role).HasColumnName("RoleId");

                entity.HasOne(d => d.User).WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRole_User");

                entity.HasOne(d => d.Role).WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRole_Role");
            });*/

            BuildRoutes(modelBuilder);
            BuildUsers(modelBuilder);
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        private const string DefaultUserPassword = "test";
        private static void BuildUsers(ModelBuilder modelBuilder) //11
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
                RegistrationDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                Active = true,
                UserStatusId = 3,
                ProfileImagePath = "",
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
                RegistrationDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                Active = true,
                UserStatusId = 3,
                ProfileImagePath = "",
                StatusExpirationDate = new DateTime(2025, 12, 31)
               },
            };

            foreach (var user in users)
            {
                user.PasswordHash = UserService.GenerateHash(user.PasswordSalt, DefaultUserPassword);

            }

            modelBuilder.Entity<User>()
                .HasData(users);
        }


        private static void BuildRoutes(ModelBuilder modelBuilder) //4
        {
            //TimeSpan timeOfDeparture = TimeSpan.FromHours(Random.Shared.Next(0, 24));
            //TimeSpan timeOfDeparture=null;
            List<Route> routes = new()
            {
                new Route()
                {
                    RouteId=1,
                    StartStationId = 1,
                    EndStationId = 6,
                    VehicleId = 2,
                    //TimeOfArrival=timeOfDeparture.Add(TimeSpan.FromMinutes(30)),
                    //TimeOfDeparture=timeOfDeparture,
                    Active=true,
                    ActiveOnHolidays=true,
                    ActiveOnWeekends=true,
                },
                new Route()
                {
                    RouteId=2,
                    StartStationId = 1,
                    EndStationId = 8,
                    VehicleId = 4,
                    //TimeOfArrival=timeOfDeparture.Add(TimeSpan.FromMinutes(30)),
                    //TimeOfDeparture=timeOfDeparture,
                    Active=true,
                    ActiveOnHolidays=true,
                    ActiveOnWeekends=true,
                },
                new Route()
                {
                    RouteId=3,
                    StartStationId = 1,
                    EndStationId = 6,
                    VehicleId = 6,
                    //TimeOfArrival=timeOfDeparture.Add(TimeSpan.FromMinutes(30)),
                    //TimeOfDeparture=timeOfDeparture,
                    Active=true,
                    ActiveOnHolidays=true,
                    ActiveOnWeekends=true,
                },
                new Route()
                {
                    RouteId=4,
                    StartStationId = 2,
                    EndStationId = 7,
                    VehicleId = 4,
                    //TimeOfArrival=timeOfDeparture.Add(TimeSpan.FromMinutes(30)),
                    //TimeOfDeparture=timeOfDeparture,
                    Active=true,
                    ActiveOnHolidays=true,
                    ActiveOnWeekends=true,
                },
                new Route()
                {
                    RouteId=5,
                    StartStationId = 7,
                    EndStationId = 3,
                    VehicleId = 2,
                    //TimeOfArrival=timeOfDeparture.Add(TimeSpan.FromMinutes(30)),
                    //TimeOfDeparture=timeOfDeparture,
                    Active=true,
                    ActiveOnHolidays=true,
                    ActiveOnWeekends=true,
                },
                new Route()
                {
                    RouteId=6,
                    StartStationId = 8,
                    EndStationId = 1,
                    VehicleId = 6,
                    //TimeOfArrival=timeOfDeparture.Add(TimeSpan.FromMinutes(30)),
                    //TimeOfDeparture=timeOfDeparture,
                    Active=true,
                    ActiveOnHolidays=true,
                    ActiveOnWeekends=true,
                },
                new Route()
                {
                    RouteId=7,
                    StartStationId = 9,
                    EndStationId = 15,
                    VehicleId = 1,
                    //TimeOfArrival=timeOfDeparture.Add(TimeSpan.FromMinutes(30)),
                    //TimeOfDeparture=timeOfDeparture,
                    Active=true,
                    ActiveOnHolidays=true,
                    ActiveOnWeekends=true,
                },
                new Route()
                {
                    RouteId=8,
                    StartStationId = 11,
                    EndStationId = 8,
                    VehicleId = 3,
                    //TimeOfArrival=timeOfDeparture.Add(TimeSpan.FromMinutes(30)),
                    //TimeOfDeparture=timeOfDeparture,
                    Active=true,
                    ActiveOnHolidays=true,
                    ActiveOnWeekends=true,
                },
                new Route()
                {
                    RouteId=9,
                    StartStationId = 10,
                    EndStationId = 14,
                    VehicleId = 5,
                    //TimeOfArrival=timeOfDeparture.Add(TimeSpan.FromMinutes(30)),
                    //TimeOfDeparture=timeOfDeparture,
                    Active=true,
                    ActiveOnHolidays=true,
                    ActiveOnWeekends=true,
                },
                new Route()
                {
                    RouteId=10,
                    StartStationId = 13,
                    EndStationId = 7,
                    VehicleId = 1,
                    //TimeOfArrival=timeOfDeparture.Add(TimeSpan.FromMinutes(30)),
                    //TimeOfDeparture=timeOfDeparture,
                    Active=true,
                    ActiveOnHolidays=true,
                    ActiveOnWeekends=true,
                },
                new Route()
                {
                    RouteId=11,
                    StartStationId = 7,
                    EndStationId = 15,
                    VehicleId = 1,
                    Arrival=DateTime.Now,
                    Departure=DateTime.Now,
                    Active=true,
                    ActiveOnHolidays=true,
                    ActiveOnWeekends=true,
                },
                 new Route()
                {
                    RouteId=12,
                    StartStationId = 8,
                    EndStationId = 6,
                    VehicleId = 2,
                    Arrival=DateTime.Now,
                    Departure=DateTime.Now,
                    Active=true,
                    ActiveOnHolidays=true,
                    ActiveOnWeekends=true,
                },
                  new Route()
                {
                    RouteId=13,
                    StartStationId = 7,
                    EndStationId = 4,
                    VehicleId = 5,
                    Arrival=DateTime.Now,
                    Departure=DateTime.Now,
                    Active=true,
                    ActiveOnHolidays=true,
                    ActiveOnWeekends=true,
                },
                  new Route()
                {
                    RouteId=14,
                    StartStationId = 8,
                    EndStationId = 13,
                    VehicleId = 3,
                    Arrival=DateTime.Now,
                    Departure=DateTime.Now,
                    Active=true,
                    ActiveOnHolidays=true,
                    ActiveOnWeekends=true,
                },
                  new Route()
                {
                    RouteId=15,
                    StartStationId = 7,
                    EndStationId = 2,
                    VehicleId = 4,
                    Arrival=DateTime.Now,
                    Departure=DateTime.Now,
                    Active=true,
                    ActiveOnHolidays=true,
                    ActiveOnWeekends=true,
                },
             };

            var random = new Random();
            foreach (var route in routes)
            {
                if (route.RouteId >= 11 && route.RouteId <= 15)
                {
                    route.Departure = DateTime.Now;
                    route.Arrival = DateTime.Now;
                }
                else if (route.RouteId >= 1 && route.RouteId <= 10)
                {
                    DateTime startDate = new DateTime(2024, 01, 01);
                    DateTime endDate = new DateTime(2024, 12, 31);

                    int range = (endDate - startDate).Days;
                    DateTime randomDate = startDate.AddDays(random.Next(range));

                    int hour = random.Next(5, 24);
                    int minute = random.Next(0, 60);
                    DateTime timeOfDeparture = new DateTime(randomDate.Year, randomDate.Month, randomDate.Day, hour, minute, 0);

                    DateTime timeOfArrival = timeOfDeparture.AddMinutes(random.Next(5, 50));

                    route.Departure = timeOfDeparture;
                    route.Arrival = timeOfArrival;
                }
            }

            modelBuilder.Entity<Route>()
               .HasData(routes);
        }
    }
}
