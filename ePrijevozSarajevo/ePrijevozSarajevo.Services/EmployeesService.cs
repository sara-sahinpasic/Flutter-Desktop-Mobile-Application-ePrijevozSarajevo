using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Services.Database;
using MapsterMapper;
using System.Security.Cryptography;
using System.Text;

namespace ePrijevozSarajevo.Services
{
    public class EmployeesService : IEmployeesService
    {
        public DataContext _context;
        public IMapper _mapper;

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

        public EmployeesService(DataContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public List<Model.User> GetList()
        {
            var result = new List<Model.User>();
            var list = _context.Users.ToList();

            result = _mapper.Map(list, result);
            return result;
        }

        public Model.User Insert(UserInseretRequest request)
        {
            if (request.Password != request.PasswordConfirmation)
            {
                throw new Exception("Password and confirmation password must be the same!");
            }

            var entity = new Database.User();

            _mapper.Map(request, entity);
            entity.PasswordSalt = GenerateSalt();
            entity.PasswordHash = GenerateHash(entity.PasswordSalt, request.Password);

            _context.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.User>(entity);
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
            var entity = _context.Users.Find(id);

            _mapper.Map(request, entity);

            if (request.Password != request.PasswordConfirmation)
            {
                throw new Exception("Password and confirmation password must be the same!");
            }

            entity.PasswordSalt = GenerateSalt();
            entity.PasswordHash = GenerateHash(entity.PasswordSalt, request.Password);

            _context.SaveChanges();
            return _mapper.Map<Model.User>(entity);

        }
    }
}
