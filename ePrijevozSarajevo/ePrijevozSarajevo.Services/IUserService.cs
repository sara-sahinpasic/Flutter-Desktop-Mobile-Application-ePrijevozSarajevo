using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;

namespace ePrijevozSarajevo.Services
{
    public interface IUserService : ICRUDService<User, UserSearchObject, UserInseretRequest, UserUpdateRequest>
    {
        User Login(string username, string password);
    }
}
