using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;

namespace ePrijevozSarajevo.Services
{
    public interface IUserService : IService<Model.User, UserSearchObject>
    {
        /*
         public List<User> GetList();
        public PagedResult<User> GetList(UserSearchObject searchObject);
        */
        public User Insert(UserInseretRequest request);
        public User Update(int id, UserUpdateRequest request);
    }
}
