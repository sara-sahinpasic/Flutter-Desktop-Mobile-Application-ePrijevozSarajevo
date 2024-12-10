using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;

namespace ePrijevozSarajevo.Services
{
    public interface IUserRoleService :
        ICRUDService<Model.UserRole, UserRoleSearchObjects,
            UserRoleUpsertRequest, UserRoleUpsertRequest>
    { }
}
