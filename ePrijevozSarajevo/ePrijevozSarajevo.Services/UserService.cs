using ePrijevozSarajevo.Model.Exceptions;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services.Database;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;

namespace ePrijevozSarajevo.Services
{
    public class UserService : BaseCRUDService<Model.User, UserSearchObject, Database.User, UserInsertRequest, UserUpdateRequest>, IUserService
    {
        ILogger<UserService> _logger;

        public UserService(DataContext context, IMapper mapper, ILogger<UserService> logger) : base(context, mapper)
        {
            this._logger = logger;
        }

        public override IQueryable<Database.User> AddFilter(UserSearchObject search, IQueryable<User> query)
        {
            query = base.AddFilter(search, query);

            if ((!string.IsNullOrWhiteSpace(search?.FirstNameGTE)) || (!string.IsNullOrWhiteSpace(search?.LastNameGTE)))
            {
                query = query.Where((x => x.FirstName.StartsWith(search.FirstNameGTE) || x.LastName.StartsWith(search.LastNameGTE)));
            }

            if (search.IsRoleIncluded == true)
            {
                query = query
                    .Include(x => x.UserRoles)
                        .ThenInclude(x => x.Role);
            }

            if (search?.IsUserStatusIncluded == true)
            {
                query = query.Include(x => x.UserStatus);
            }

            if (search?.IsCountryIncluded == true)
            {
                query = query.Include(x => x.UserCountry);
            }

            return query;
        }

        public override async Task BeforeInsert(UserInsertRequest request, User entity)
        {
            _logger.LogInformation($"Adding user: {entity.FirstName} {entity.LastName}");

            if (request.Password != request.PasswordConfirmation)
            {
                throw new UserException("Lozinke se moraju podudarati.");
            }

            entity.PasswordSalt = GenerateSalt();
            entity.PasswordHash = GenerateHash(entity.PasswordSalt, request.Password);

            base.BeforeInsert(request, entity);
        }

        public static string GenerateSalt()
        {
            var byteArray = RNGCryptoServiceProvider.GetBytes(16);

            return Convert.ToBase64String(byteArray);
        }
        public static string GenerateHash(string? salt, string?
            password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }

        public override async Task BeforeUpdate(UserUpdateRequest? request, User? entity)
        {
            base.BeforeUpdate(request, entity);

            if (request.Password != null)
            {
                if (request.Password != request.PasswordConfirmation)
                {
                    throw new UserException("Lozinke se moraju podudarati.");
                }
                entity.PasswordSalt = GenerateSalt();
                entity.PasswordHash = GenerateHash(entity.PasswordSalt, request.Password);
            }
        }
        public async Task<Model.User> Login(string username, string password)
        {
            var entity = await _dataContext.Users
                .Include(x => x.UserRoles)
                .ThenInclude(y => y.Role)
                .FirstOrDefaultAsync(x => x.UserName == username);

            if (entity == null)
            {
                return null;
            }
            var hash = GenerateHash(entity.PasswordSalt, password);

            if (hash != entity.PasswordHash)
            {
                return null;
            }

            return _mapper.Map<Model.User>(entity);
        }

        public async Task ResetPassword(string username, string newPassword, string passwordConfirmation)
        {
            var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.UserName == username);

            if (user == null)
            {
                throw new UserException("Korisnik nije pronađen. Lozinku možete promijeniti samo za već postojećeg korisnika.");
            }

            if (newPassword != passwordConfirmation)
            {
                throw new UserException("Lozinke se moraju podudarati.");
            }

            user.PasswordSalt = GenerateSalt();
            user.PasswordHash = GenerateHash(user.PasswordSalt, newPassword);

            await _dataContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteUser(int userId)
        {

            var userRoles = await _dataContext.UserRoles
                    .Where(ur => ur.UserId == userId).ToListAsync();

            if (userRoles.Any())
            {
                _dataContext.UserRoles.RemoveRange(userRoles);
            }

            // Remove the user
            var user = await _dataContext.Users.FindAsync(userId);
            if (user != null)
            {
                _dataContext.Users.Remove(user);
            }

            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<Model.User> InsertUser(UserInsertRequest request)
        {
            Database.User entity = _mapper.Map<Database.User>(request);

            var uniqueUserName = _dataContext.Users.Where(x => x.UserName == entity.UserName).ToList();
            if (!uniqueUserName.IsNullOrEmpty())   
            {
                throw new UserException("Korisničko ime već postoji.");
            }

            var uniqueEmail = _dataContext.Users.Where(x => x.Email == entity.Email).ToList();
            if (!uniqueEmail.IsNullOrEmpty())
            {
                throw new UserException($"Račun sa unesenom email adresom {entity.Email} već postoji.");
            }
            await BeforeInsert(request, entity);

            if (entity.DateOfBirth > DateTime.Now)
            {
                throw new UserException("Datum rođenja ne može biti u budućnosti.");
            }

            DateTime twelveYearsAgo = DateTime.Now.AddYears(-12);
            if (entity.DateOfBirth > twelveYearsAgo)
            {
                throw new UserException("Korisnik mora imati najmanje 12 godina.");
            }

            await _dataContext.AddAsync(entity);
            await _dataContext.SaveChangesAsync();

            var userRole = new Database.UserRole
            {
                UserId = entity.UserId,
                RoleId = 2
            };

            await _dataContext.UserRoles.AddAsync(userRole);
            await _dataContext.SaveChangesAsync();

            return _mapper.Map<Model.User>(entity);

        }
    }
}
