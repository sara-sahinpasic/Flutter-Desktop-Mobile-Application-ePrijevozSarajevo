using Microsoft.EntityFrameworkCore;

namespace ePrijevozSarajevo.Services.Database
{
    public class DataContext : DbContext
    {
        public DataContext()
        {

        }
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Status> Statuses { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<Route> Routes { get; set; } = null!;
        public DbSet<Station> Stations { get; set; } = null!;
        public DbSet<Vehicle> Vehicles { get; set; } = null!;
        public DbSet<VehicleType> VehicleTypes { get; set; } = null!;
        public DbSet<Manufacturer> Manufacturers { get; set; } = null!;


        public DataContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Data Source=.; Initial Catalog=ePrijevozSarajevo;Trusted_Connection=True;TrustServerCertificate=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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

            modelBuilder.Entity<Status>()
                .Property(p => p.Discount)
                .HasPrecision(5, 2);

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

            modelBuilder.Entity<Vehicle>()
                .HasIndex(v => v.RegistrationNumber)
                .IsUnique();

            BuildUserRoles(modelBuilder);
            BuildUserStatus(modelBuilder);
        }

        private static void BuildUserRoles(ModelBuilder modelBuilder)
        {
            List<Role> roles = new()
        {
            new()
            {
                Id = 1,
                Name = "User"
            },
            new()
            {
                Id = 2,
                Name = "Admin"
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
                Id=1,
                Name="Unemployed",
                Discount=0.4
            },
            new()
            {
                Id=2,
                Name="Employed",
                Discount=0.15
            },
            new()
            {
                Id=3,
                Name = "Student",
                Discount=0.3

            },
            new()
            {
                Id=4,
                Name="Pensioner",
                Discount=0.5
            },
            new()
            {
                Id=5,
                Name="Tourist",
                Discount=0.0
            }
        };

            modelBuilder.Entity<Status>()
                .HasData(statuses);
        }
    }

}
