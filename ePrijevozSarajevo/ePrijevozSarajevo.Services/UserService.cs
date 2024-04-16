using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services.Database;
using MapsterMapper;
using System.Security.Cryptography;
using System.Text;

namespace ePrijevozSarajevo.Services
{
    public class UserService : BaseCRUDService<Model.User, UserSearchObject, Database.User, UserInseretRequest, UserUpdateRequest>, IUserService
    {
        public DataContext context;
        public IMapper mapper;

        public UserService(DataContext context, IMapper mapper) : base(context, mapper) { }

        public override IQueryable<Database.User> AddFilter(UserSearchObject search, IQueryable<Database.User> query)
        {
            query = base.AddFilter(search, query);

            if (!string.IsNullOrWhiteSpace(search?.FirstNameGTE))
            {
                query = query.Where(x => x.FirstName.StartsWith(search.FirstNameGTE));
            }
            if (!string.IsNullOrWhiteSpace(search?.LastNameGTE))
            {
                query = query.Where(x => x.LastName.StartsWith(search.LastNameGTE));
            }
            return query;
        }

        public override void BeforeInsert(UserInseretRequest request, Database.User entity)
        {
            if (request.Password != request.PasswordConfirmation)
            {
                throw new Exception("Password and password confirmation must be the same.");
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
        public static string GenerateHash(string salt, string password)
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

        public override void BeforeUpdate(UserUpdateRequest? request, Database.User? entity)
        {
            base.BeforeUpdate(request, entity);

            if (request.Password != null)
            {
                if (request.Password != request.PasswordConfirmation)
                {
                    throw new Exception("Password and password confirmation must be the same.");
                }
            }

            entity.PasswordSalt = GenerateSalt();
            entity.PasswordHash = GenerateHash(entity.PasswordSalt, request.Password);
        }
    }
}
