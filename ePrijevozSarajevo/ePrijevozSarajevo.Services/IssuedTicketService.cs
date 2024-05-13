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
                    //ToDo
                    //.Include(x => x.User)
                      //  .ThenInclude(x => x.Role)
                    .Include(x => x.User)
                        .ThenInclude(x => x.UserStatus);
            }
            if (search.IsTicketIncluded == true)
            {
                query = query.Include(x => x.Ticket);
            }       

            return query;
        }
    }
}
