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
        public IssuedTicketService(DataContext context, IMapper mapper) : base(context, mapper) { }

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
                    .Include(x => x.User)
                        .ThenInclude(y => y.UserCountry)
                    .Include(x => x.User)
                        .ThenInclude(y => y.UserRoles)
                        .ThenInclude(z => z.Role);

            }
            if (search.IsTicketIncluded == true)
            {
                query = query.Include(x => x.Ticket);
            }

            if (search.IsRouteIncluded == true)
            {
                query = query
                    .Include(x => x.Route)
                        .ThenInclude(r => r.StartStation)
                    .Include(x => x.Route)
                     .ThenInclude(r => r.EndStation)
                    .Include(x => x.Route)
                        .ThenInclude(r => r.Vehicle)
                        .ThenInclude(v => v.Manufacturer)
                    .Include(x => x.Route)
                        .ThenInclude(r => r.Vehicle)
                        .ThenInclude(v => v.Type);
            }

            return query.OrderByDescending(x => x.ValidTo);
        }
    }
}
