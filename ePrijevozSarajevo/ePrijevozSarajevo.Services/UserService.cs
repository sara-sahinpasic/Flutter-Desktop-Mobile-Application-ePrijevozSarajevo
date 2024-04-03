using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services.Database;
using MapsterMapper;
using System.Security.Cryptography;
using System.Text;

namespace ePrijevozSarajevo.Services
{
    public class UserService : BaseService<Model.User, UserSearchObject, Database.User>, IUserService
    {
        public DataContext context;
        public IMapper mapper;

        /*public List<User> EmployeesList = new List<User>()
{ 
new User()
{
Id= 1,
FirstName="Ime",
LastName="Prezime",
Email="ime.prezime@mail.com",
DateOfBirth=DateTime.Now,
PhoneNumber="033222555",
Address="Neka 1"
}
};*/

        public UserService(DataContext context, IMapper mapper) : base(context, mapper) { }
        /*{
       this.context = context;
       this.mapper = mapper;
   }*/
        /*public List<Model.User> GetList()
        {
            var result = new List<Model.User>();
            var list = _context.Users.ToList();

            result = _mapper.Map(list, result);
            return result;
        }*/
        /* public PagedResult<Model.User> GetList(UserSearchObject searchObject)
        {
            var result = new List<Model.User>();

            var query = context.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchObject?.FirstNameGTE))
            {
                query = query.Where(x => x.FirstName.StartsWith(searchObject.FirstNameGTE));
            }

            if (!string.IsNullOrWhiteSpace(searchObject?.LastNameGTE))
            {
                query = query.Where(x => x.LastName.StartsWith(searchObject.LastNameGTE));
            }


            if (searchObject.Page.HasValue == true && searchObject.PageSize.HasValue == true)
            {
                query = query.Skip(searchObject.Page.Value * searchObject.PageSize.Value)
                             .Take(searchObject.PageSize.Value);
            }

            int count = query.Count();

            var list = query.ToList();

            var resultList = mapper.Map(list, result);
            PagedResult<Model.User> response = new PagedResult<Model.User>();
            response.ResultList = resultList;
            response.Count = count;

            return response;
        }
       */


        public Model.User Insert(UserInseretRequest request)
        {
            if (request.Password != request.PasswordConfirmation)
            {
                throw new Exception("Password and confirmation password must be the same!");
            }

            var entity = new Database.User();

            mapper.Map(request, entity);
            entity.UserId = request.UserId;
            entity.PasswordSalt = GenerateSalt();
            entity.PasswordHash = GenerateHash(entity.PasswordSalt, request.Password);

            context.Add(entity);
            context.SaveChanges();

            return mapper.Map<Model.User>(entity);
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

        public Model.User Update(int id, UserUpdateRequest request)
        {
            var entity = context.Users.Find(id);

            mapper.Map(request, entity);

            if (request.Password != request.PasswordConfirmation)
            {
                throw new Exception("Password and confirmation password must be the same!");
            }

            entity.PasswordSalt = GenerateSalt();
            entity.PasswordHash = GenerateHash(entity.PasswordSalt, request.Password);

            context.SaveChanges();
            return mapper.Map<Model.User>(entity);

        }

    }
}
