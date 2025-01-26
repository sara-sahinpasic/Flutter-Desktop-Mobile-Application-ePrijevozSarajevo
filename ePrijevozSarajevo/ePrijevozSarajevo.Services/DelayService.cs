using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services.Database;
using MapsterMapper;

namespace ePrijevozSarajevo.Services
{
    public class DelayService : BaseCRUDService<Model.Delay, DelaySearchObject, Database.Delay,
        DelayInsertRequest, DelayUpdateRequest>, IDelayService
    {
        public DelayService(DataContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override IQueryable<Delay> AddFilter(DelaySearchObject search, IQueryable<Delay> query)
        {
            query= base.AddFilter(search, query);

            if (search?.TypeIdGTE >= 0)
            {
                query = query.Where(x => x.TypeId == search.TypeIdGTE);
            }
            return query;
        }
    }
}
