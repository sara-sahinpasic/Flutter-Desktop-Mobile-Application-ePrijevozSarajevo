using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services.Database;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace ePrijevozSarajevo.Services
{
    public class RequestService : BaseCRUDService<Model.Request, RequestSearchObject, Database.Request, RequestInsertRequest, RequestUpdateRequest>, IRequestService
    {
        public RequestService(DataContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IQueryable<Request> AddFilter(RequestSearchObject search, IQueryable<Request> query)
        {
            query = base.AddFilter(search, query);

            /* if (search?.UserIdGTE > 0)
             {
                 query = query.Where(x => x.UserId == search.UserIdGTE);
             }

             if (search?.UserStatusIdGTE > 0)
             {
                 query = query.Where(x => x.User.UserStatusId == search.UserStatusIdGTE);
             }*/

            if (search?.UserStatusIdGTE >= 0)
            {
                query=query.Where(x=>x.UserStatusId==search.UserStatusIdGTE);
            }

            if (search?.IsUserIncluded == true)
            {
                query = query
                   .Include(x => x.User)
                    .ThenInclude(x => x.UserRoles).ThenInclude(y => y.Role);
            }
            //ToDo
                    //.Include(x => x.User)
                    //    .ThenInclude(x => x.UserStatus)
                   // .Include(x => x.User)
                   //     .ThenInclude(x => x.Role);

            return query;
        }
    }
};
