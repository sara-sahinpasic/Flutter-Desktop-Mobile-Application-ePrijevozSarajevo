using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services.Database;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace ePrijevozSarajevo.Services
{
    public class IssuedTicketService : BaseCRUDService<Model.IssuedTicket, IssuedTicketSearchObject, Database.IssuedTicket,
        IssuedTicketInsertequest, IssuedTicketUpdateRequest>, IIssuedTicketService
    {
        public IssuedTicketService(DataContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IQueryable<IssuedTicket> AddFilter(IssuedTicketSearchObject search, IQueryable<IssuedTicket> query)
        {
            query = base.AddFilter(search, query);

            if (search.IssuedTicketIdGTE > 0)
            {
                query = query.Where(x => x.IssuedTicketId == search.IssuedTicketIdGTE);
            }
            if (search.IsUserIncluded == true)
            {
                query = query
                    .Include(x => x.User)
                        .ThenInclude(y => y.UserStatus)
                        .Include(x => x.User.UserRoles)
                        .Include(x => x.User.UserCountry);

            }
            if (search.IsTicketIncluded == true)
            {
                query = query.Include(x => x.Ticket);
            }

            if (search.IsRouteIncluded == true)
            {
                query = query.Include(x => x.Route)
                    .ThenInclude(y => y.StartStation)
                    .Include(x => x.Route.EndStation)
                    .Include(z => z.Route.Vehicle)
                    .ThenInclude(z => z.Manufacturer)
                    .Include(z => z.Route.Vehicle)
                    .ThenInclude(z => z.Type);
            }

            return query.OrderByDescending(x=>x.ValidTo);
        }
    }
}
