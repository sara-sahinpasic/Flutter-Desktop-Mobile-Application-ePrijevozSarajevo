using Microsoft.EntityFrameworkCore;
using System.Net;
using System;

namespace ePrijevozSarajevo.Services.Database
{
    public sealed class DataContext : DbContext
    {
        public DataContext()
        {

        }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<Ticket> Tickets { get; set; } = null!;
        public DbSet<PaymentMethod> PaymentOptions { get; set; } = null!;
        public DbSet<Status> Statuses { get; set; } = null!;
        public DbSet<IssuedTicket> IssuedTickets { get; set; } = null!;
        public DbSet<Station> Stations { get; set; } = null!;
        public DbSet<Vehicle> Vehicles { get; set; } = null!;
        public DbSet<VehicleType> VehicleTypes { get; set; } = null!;
        public DbSet<Manufacturer> Manufacturers { get; set; } = null!;
        public DbSet<Route> Routes { get; set; } = null!;
        public DbSet<Request> Requests { get; set; } = null!;
        public DbSet<UserRole> UserRoles { get; set; } = null!;

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    if (!options.IsConfigured)
        //    {
        //        options.UseSqlServer("Server=.;Database=140261;Trusted_Connection=True;Encrypt=False;");
        //    }
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Data Source=localhost; Initial Catalog=140261; user=sa; Password=ePrijevoz123!;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }

      
        //   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //=> optionsBuilder.UseSqlServer("Data Source=localhost; Initial Catalog=140261; user=sa; Password=QWEasd123!;" +
        //    "Trusted_Connection=True;TrustServerCertificate=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vehicle>()
                .HasIndex(v => v.RegistrationNumber)
                .IsUnique();

            modelBuilder.Entity<User>()
               .HasIndex(u => u.Email)
               .IsUnique();

            /*modelBuilder.Entity<User>()
                .HasOne(user => user.Role)
                .WithMany()
                .HasForeignKey(r => r.RoleId);*/

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

            //BuildPaymentOptions(modelBuilder);

            BuildUserRoles(modelBuilder);
            BuildUsers(modelBuilder);
            BuildRoles(modelBuilder);
            BuildUserStatus(modelBuilder);
            BuildTicketData(modelBuilder);
        }
        /*private static void BuildPaymentOptions(ModelBuilder modelBuilder)
        {
            List<PaymentMethod> paymentOptions = new()
        {
            new()
            {
                PaymentMethodId = 1,
                Name = "PayPal"
            },
            new()
            {
                PaymentMethodId = 2,
                Name = "Stripe"
            }
        };

            modelBuilder.Entity<PaymentMethod>()
                .HasData(paymentOptions);
        }*/
        private static void BuildUserRoles(ModelBuilder modelBuilder)
        {
            List<UserRole> userRoles = new()
        {
            new()
            {
                UserRoleId=1,
                UserId=1,
                RoleId = 1,
                ModificationDate = DateTime.Now
            },
            new()
            {
                UserRoleId=2,
                UserId=2,
                RoleId = 2,
                ModificationDate = DateTime.Now
            }
        };
            modelBuilder.Entity<UserRole>()
                    .HasData(userRoles);
        }
        private const string DefaultUserPassword = "test";

        private static void BuildUsers(ModelBuilder modelBuilder)
        {
            List<User> users = new()
            {
               new()
               {
                UserId = 1,
                FirstName = "Neko",
                LastName = "Nekić",
                UserName = "admin",
                Email = "admin@mail.ba",
                //Password = DefaultUserPassword,
                PasswordSalt = UserService.GenerateSalt(),
                DateOfBirth = new DateTime(1988, 09, 25),
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
                FirstName = "Neka",
                LastName = "Nekić",
                UserName = "user",
                Email = "user@mail.ba",
               // Password = DefaultUserPassword,
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
            // users.PasswordHash = UserService.GenerateHash(users.PasswordSalt, users.Password);

            modelBuilder.Entity<User>()
                .HasData(users);
        }
        private static void BuildRoles(ModelBuilder modelBuilder)
        {
            List<Role> roles = new()
        {
            new()
            {
                RoleId = 1,
                Name = "Admin"
            },
            new()
            {
                RoleId = 2,
                Name = "User"
            }
        };

            modelBuilder.Entity<Role>()
                .HasData(roles);
        }


        private static void BuildUserStatus(ModelBuilder modelBuilder)
        {
            List<Status> statuses = new()
        {

            new()
            {
                StatusId = 1,
                Name = "Student",
                Discount = 0.3,

            },
            new()
            {
                StatusId = 2,
                Name = "Pensioner",
                Discount = 0.5
            },
            new()
            {
                StatusId = 3,
                Name = "Employed",
                Discount = 0.15
            },
            new()
            {
                StatusId = 4,
                Name = "Unemployed",
                Discount = 0.4
            }
        };

            modelBuilder.Entity<Status>()
                .HasData(statuses);
        }

        private static void BuildTicketData(ModelBuilder modelBuilder)
        {
            List<Ticket> tickets = new()
        {
            new()
            {
                TicketId = 1,
                Name = "Jednosmjerna",
                Price = 1.80,
                StateMachine = "draft"
            },
            new()
            {
                TicketId = 2,
                Name = "Povratna",
                Price = 3.20,
                StateMachine = "draft"
            },
            new()
            {
                TicketId = 3,
                Name = "Jednosmjerna dječija",
                Price = 0.80,
                StateMachine = "draft"
            },
            new()
            {
                TicketId = 4,
                Name = "Povratna dječija",
                Price = 1.20,
                StateMachine = "draft"
            },
            new()
            {
                TicketId = 5,
                Name = "Mjesečna",
                Price = 75,
                StateMachine = "draft"
            }
        };
            modelBuilder.Entity<Ticket>()
                 .HasData(tickets);

        }
    }
}
