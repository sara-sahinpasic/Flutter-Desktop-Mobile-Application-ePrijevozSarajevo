using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Model.Requests;

namespace ePrijevozSarajevo.Services
{
    public interface IEmployeesService
    {
        public List<User> GetList();
        public User Insert(UserInseretRequest request);
        public User Update(int id, UserUpdateRequest request);
    }
}
