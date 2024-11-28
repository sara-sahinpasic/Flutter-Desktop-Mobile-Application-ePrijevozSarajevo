using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;

namespace ePrijevozSarajevo.Services
{
    public interface IRoleService : ICRUDService
        <Model.Role, RoleSearchObject, RoleUpsertRequest, RoleUpsertRequest>
    {
    }
}
