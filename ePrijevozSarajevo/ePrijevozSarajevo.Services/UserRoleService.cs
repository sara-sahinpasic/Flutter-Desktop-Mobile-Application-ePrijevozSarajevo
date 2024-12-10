using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services.Database;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace ePrijevozSarajevo.Services
{
    public class UserRoleService : BaseCRUDService<Model.UserRole, UserRoleSearchObjects, Database.UserRole, UserRoleUpsertRequest, UserRoleUpsertRequest>, IUserRoleService
    {
        public UserRoleService(DataContext context, IMapper mapper) : base(context, mapper) { }

        public override IQueryable<UserRole> AddFilter(UserRoleSearchObjects search, IQueryable<UserRole> query)
        {
            query = base.AddFilter(search, query);

            if (search?.IsRoleIncluded == true)
            {
                query = query.Include(x => x.Role);
            }
            return query;
        }
    }
}
