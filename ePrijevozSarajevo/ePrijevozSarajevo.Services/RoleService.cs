using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services.Database;
using MapsterMapper;

namespace ePrijevozSarajevo.Services
{
    public class RoleService : BaseCRUDService
        <Model.Role, RoleSearchObject, Database.Role, RoleUpsertRequest,
        RoleUpsertRequest>, IRoleService
    {
        public RoleService(DataContext context, IMapper mapper) : base(context, mapper) { }
    }
}
