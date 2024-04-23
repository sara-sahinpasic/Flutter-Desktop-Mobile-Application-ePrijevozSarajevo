using Microsoft.EntityFrameworkCore;

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

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Server=.;Database=140261;Trusted_Connection=True;Encrypt=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vehicle>()
                .HasIndex(v => v.RegistrationNumber)
                .IsUnique();

            modelBuilder.Entity<User>()
               .HasIndex(u => u.Email)
               .IsUnique();

            modelBuilder.Entity<User>()
                .HasOne(user => user.Role)
                .WithMany()
                .HasForeignKey(r => r.RoleId);

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

            BuildPaymentOptions(modelBuilder);
            BuildUserRoles(modelBuilder);
            BuildUserStatus(modelBuilder);
            BuildTicketData(modelBuilder);
        }

        private static void BuildPaymentOptions(ModelBuilder modelBuilder)
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
        }

        private static void BuildUserRoles(ModelBuilder modelBuilder)
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
                Discount = 0.3

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
                StateMachine = null
            },
            new()
            {
                TicketId = 2,
                Name = "Povratna",
                Price = 3.20
            },
            new()
            {
                TicketId = 3,
                Name = "Jednosmjerna dječija",
                Price = 0.80
            },
            new()
            {
                TicketId = 4,
                Name = "Povratna dječija",
                Price = 1.20
            },
            new()
            {
                TicketId = 5,
                Name = "Mjesečna",
                Price = 75
            }
        };
            modelBuilder.Entity<Ticket>()
                 .HasData(tickets);

        }
    }
}
