using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services.Database;
using MapsterMapper;

namespace ePrijevozSarajevo.Services
{
    public class StatusService : BaseCRUDService<Model.Status, StatusSearchObject, Database.Status, StatusInsertRequest, StatusUpdateRequest>, IStatusService
    {
        public StatusService(DataContext context, IMapper mapper) : base(context, mapper) { }
        public override IQueryable<Status> AddFilter(StatusSearchObject search, IQueryable<Status> query)
        {
            query = base.AddFilter(search, query);

            if (!string.IsNullOrWhiteSpace(search?.NameGTE))
            {
                query = query.Where(x => x.Name.Contains(search.NameGTE));
            }
            return query;
        }
    }
}
