using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;

namespace ePrijevozSarajevo.Services
{
    public interface IUserService : ICRUDService<User, UserSearchObject, UserInseretRequest, UserUpdateRequest>
    {
        public Task<User> Login(string username, string password);
        public Task ResetPassword(string email, string password, string passwordConfirmation);
        public Task<bool> DeleteUser(int userId);
    }
}
