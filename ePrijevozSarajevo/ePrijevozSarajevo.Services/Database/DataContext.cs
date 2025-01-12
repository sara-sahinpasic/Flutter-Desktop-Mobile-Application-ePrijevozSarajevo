using Microsoft.EntityFrameworkCore;

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
                options.EnableSensitiveDataLogging();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Vehicle

            modelBuilder.Entity<Vehicle>()
                .HasIndex(v => v.RegistrationNumber)
                .IsUnique();

            modelBuilder.Entity<Vehicle>()
                .HasIndex(v => v.Number)
                .IsUnique();

            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.Manufacturer)
                .WithMany()
                .HasForeignKey(v => v.ManufacturerId);

            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.Type)
                .WithMany()
                .HasForeignKey(v => v.TypeId);

            // Manufacturer

            modelBuilder.Entity<Manufacturer>()
                .HasOne(m => m.ManufacturerCountry)
                .WithMany()
                .HasForeignKey(m => m.ManufacturerCountryId)
                .OnDelete(DeleteBehavior.SetNull);  

            // Status

            modelBuilder.Entity<Status>()
                .Property(p => p.Discount)
                .HasPrecision(5, 2);

            // User

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
               .HasIndex(u => u.UserName)
               .IsUnique();

            modelBuilder.Entity<User>()
                .HasOne(user => user.UserStatus)
                .WithMany()
                .HasForeignKey(user => user.UserStatusId)
                .OnDelete(DeleteBehavior.SetNull); 
            
            modelBuilder.Entity<User>()
                .HasOne(user => user.UserCountry)
                .WithMany()
                .HasForeignKey(user => user.UserCountryId)
                .OnDelete(DeleteBehavior.SetNull);

            // Request

            modelBuilder.Entity<Request>()
                .HasOne(request => request.User)
                .WithMany()
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Request>()
                .HasOne(request => request.UserStatus)
                .WithMany()
                .HasForeignKey(r => r.UserStatusId);


            // Route

            modelBuilder.Entity<Route>()
                .HasOne(r => r.StartStation)
                .WithMany()
                .HasForeignKey(r => r.StartStationId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Route>()
                .HasOne(r => r.EndStation)
                .WithMany()
                .HasForeignKey(r => r.EndStationId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Route>()
                .HasOne(r => r.Vehicle)
                .WithMany()
                .HasForeignKey(r => r.VehicleId);

            // Issued Ticket

            modelBuilder.Entity<IssuedTicket>()
                .HasOne(i => i.Route)
                .WithMany()
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<IssuedTicket>()
               .HasOne(i => i.Ticket)
               .WithMany()
               .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<IssuedTicket>()
               .HasOne(i => i.User)
               .WithMany()
               .OnDelete(DeleteBehavior.SetNull);

            var routeList = BuildRoutes(modelBuilder);
            BuildIssuedTickets(modelBuilder, routeList);
            BuildUsers(modelBuilder);
            BuildCountries(modelBuilder);
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
                PhoneNumber = "+38761222333",
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
                LastName = "Senadić",
                UserName = "mobile",
                Email = "eprijevozsarajevoapp@gmail.com",
                PasswordSalt = UserService.GenerateSalt(),
                DateOfBirth = new DateTime(1988, 10, 26),
                PhoneNumber = "+38761222444",
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
                Email = "sara.sahinpasic@hotmail.com",
                PasswordSalt = UserService.GenerateSalt(),
                DateOfBirth = new DateTime(1975, 05, 06),
                PhoneNumber = "+38761222444",
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
                Email = "eprijevozsarajevotest@outlook.com",
                PasswordSalt = UserService.GenerateSalt(),
                DateOfBirth = new DateTime(1965, 07, 14),
                PhoneNumber = "+38761222666",
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
                Email = "eprijevozsarajevo.app@gmx.de",
                PasswordSalt = UserService.GenerateSalt(),
                DateOfBirth = new DateTime(1982, 04, 27),
                PhoneNumber = "+38761222777",
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
                PhoneNumber = "+38761222888",
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
        private static void BuildIssuedTickets(ModelBuilder modelBuilder, List<Route> routes)
        {
            List<IssuedTicket> issuedTickets = new();
            var random = new Random();
            int totalIssuedTickets = 100;
            int maxUsers = 6;
            int maxTickets = 5;
            int maxRoutes = routes.Count;

            for (int i = 1; i <= totalIssuedTickets; i++)
            {
                int userId = random.Next(1, maxUsers + 1);
                int ticketId = random.Next(1, maxTickets + 1);
                int routeId = random.Next(1, maxRoutes + 1);
                DateTime issuedDate;
                do
                {
                    int year = DateTime.Now.Year - random.Next(0, 2); // current year or last year
                    int month = year == DateTime.Now.Year ? random.Next(1, DateTime.Now.Month + 1):random.Next(1, 13);
                    int day = (year == DateTime.Now.Year) && (month == DateTime.Now.Month) ? random.Next(1, DateTime.Now.Day) : random.Next(1, DateTime.DaysInMonth(year, month) + 1);
                    issuedDate = new DateTime(year, month, day);
                } while (issuedDate.CompareTo(DateTime.Now) > 0);
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
                    Amount = random.Next(1, 10),
                    RouteId = routeId
                });
            }
            modelBuilder.Entity<IssuedTicket>()
              .HasData(issuedTickets);
        } //2
        private static List<Route> BuildRoutes(ModelBuilder modelBuilder)
        {
            int totalStations = 15;
            int totalVehicles = 6;
            var random = new Random();

            List<Route> routes = new();
            List<DateTime> dateWithRoutes = new();
            dateWithRoutes.Add(new DateTime(2025, 01, 05));
            dateWithRoutes.Add(new DateTime(2025, 01, 15));
            dateWithRoutes.Add(new DateTime(2025, 01, 25));
            dateWithRoutes.Add(new DateTime(2025, 02, 05));
            dateWithRoutes.Add(new DateTime(2025, 02, 15));
            dateWithRoutes.Add(new DateTime(2025, 02, 25));
            int routeCounter = 1;

            for (int i = 0; i< dateWithRoutes.Count; i++)
            {
                for (int j = 1; j <= totalStations; j++)
                {
                    for(int k = j+1; k > 0; k--)
                    {
                        DateTime departure = new DateTime(dateWithRoutes[i].Year, dateWithRoutes[i].Month, dateWithRoutes[i].Day, 10, 15, 0);
                        DateTime arrival = departure.AddMinutes(30);

                        if (k != j && k <= totalStations)
                        {
                            routes.Add(new Route()
                            {
                                RouteId = routeCounter++,
                                StartStationId = j,
                                EndStationId = k,
                                VehicleId = random.Next(1, totalVehicles + 1),
                                Departure = departure,
                                Arrival = arrival
                            });
                        }
                    }
                }

            }
            modelBuilder.Entity<Route>()
               .HasData(routes);
            return routes;
        } //3
        private static void BuildCountries(ModelBuilder modelBuilder)
        {
            var result = new List<Country>();
            List<String> countriesList = new() {
                "Afghanistan",
                "Albania",
                "Algeria",
                "Andorra",
                "Angola",
                "Antigua and Barbuda",
                "Argentina",
                "Armenia",
                "Australia",
                "Austria",
                "Azerbaijan",
                "Bahrain",
                "Bangladesh",
                "Barbados",
                "Belarus",
                "Belgium",
                "Belize",
                "Benin",
                "Bhutan",
                "Bolivia",
                "Bosnia and Herzegovina",
                "Botswana",
                "Brazil",
                "Brunei",
                "Bulgaria",
                "Burkina Faso",
                "Burundi",
                "Cambodia",
                "Cameroon",
                "Canada",
                "Cape Verde",
                "Central African Republic",
                "Chad",
                "Chile",
                "China",
                "Colombia",
                "Comoros",
                "Congo",
                "Congo (Democratic Republic)",
                "Costa Rica",
                "Croatia",
                "Cuba",
                "Cyprus",
                "Czechia",
                "Denmark",
                "Djibouti",
                "Dominica",
                "Dominican Republic",
                "East Timor",
                "Ecuador",
                "Egypt",
                "El Salvador",
                "Equatorial Guinea",
                "Eritrea",
                "Estonia",
                "Eswatini",
                "Ethiopia",
                "Fiji",
                "Finland",
                "France",
                "Gabon",
                "Georgia",
                "Germany",
                "Ghana",
                "Greece",
                "Grenada",
                "Guatemala",
                "Guinea",
                "Guinea-Bissau",
                "Guyana",
                "Haiti",
                "Honduras",
                "Hungary",
                "Iceland",
                "India",
                "Indonesia",
                "Iran",
                "Iraq",
                "Ireland",
                "Israel",
                "Italy",
                "Ivory Coast",
                "Jamaica",
                "Japan",
                "Jordan",
                "Kazakhstan",
                "Kenya",
                "Kiribati",
                "Kosovo",
                "Kuwait",
                "Kyrgyzstan",
                "Laos",
                "Latvia",
                "Lebanon",
                "Lesotho",
                "Liberia",
                "Libya",
                "Liechtenstein",
                "Lithuania",
                "Luxembourg",
                "Madagascar",
                "Malawi",
                "Malaysia",
                "Maldives",
                "Mali",
                "Malta",
                "Marshall Islands",
                "Mauritania",
                "Mauritius",
                "Mexico",
                "Federated States of Micronesia",
                "Moldova",
                "Monaco",
                "Mongolia",
                "Montenegro",
                "Morocco",
                "Mozambique",
                "Myanmar (Burma)",
                "Namibia",
                "Nauru",
                "Nepal",
                "Netherlands",
                "New Zealand",
                "Nicaragua",
                "Niger",
                "Nigeria",
                "North Korea",
                "North Macedonia",
                "Norway",
                "Oman",
                "Pakistan",
                "Palau",
                "Panama",
                "Papua New Guinea",
                "Paraguay",
                "Peru",
                "Philippines",
                "Poland",
                "Portugal",
                "Qatar",
                "Romania",
                "Russia",
                "Rwanda",
                "St Kitts and Nevis",
                "St Lucia",
                "St Vincent",
                "Samoa",
                "San Marino",
                "Sao Tome and Principe",
                "Saudi Arabia",
                "Senegal",
                "Serbia",
                "Seychelles",
                "Sierra Leone",
                "Singapore",
                "Slovakia",
                "Slovenia",
                "Solomon Islands",
                "Somalia",
                "South Africa",
                "South Korea",
                "South Sudan",
                "Spain",
                "Sri Lanka",
                "Sudan",
                "Suriname",
                "Sweden",
                "Switzerland",
                "Syria",
                "Tajikistan",
                "Tanzania",
                "Thailand",
                "The Bahamas",
                "The Gambia",
                "Togo",
                "Tonga",
                "Trinidad and Tobago",
                "Tunisia",
                "Turkey",
                "Turkmenistan",
                "Tuvalu",
                "Uganda",
                "Ukraine",
                "United Arab Emirates",
                "United Kingdom",
                "United States",
                "Uruguay",
                "Uzbekistan",
                "Vanuatu",
                "Vatican City",
                "Venezuela",
                "Vietnam",
                "Yemen",
                "Zambia",
                "Zimbabwe"
            };
            int index = 1;
            foreach (var countryName in countriesList)
            {
                result.Add(new Country()
                {
                    CountryId = index,
                    Name = countryName,
                    ModifiedDate = DateTime.Now,
                });
                index++;
            }
            modelBuilder.Entity<Country>()
                        .HasData(result);
        }//4
    }
}
