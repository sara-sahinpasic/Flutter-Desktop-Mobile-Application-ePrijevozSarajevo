using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services.Database;
using MapsterMapper;

namespace ePrijevozSarajevo.Services
{
    public class TicketService : BaseCRUDService<Model.Ticket, TicketSearchObject, Database.Ticket, TicketInsertRequest, TicketUpdateRequest>, ITicketService
    {
        public TicketService(DataContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IQueryable<Ticket> AddFilter(TicketSearchObject search, IQueryable<Ticket> query)
        {
            query = base.AddFilter(search, query);

            if (!string.IsNullOrEmpty(search.NameGTE))
            {
                query = query.Where(x => x.Name.StartsWith(search.NameGTE));
            }
           
            return query;
        }
    }
}
