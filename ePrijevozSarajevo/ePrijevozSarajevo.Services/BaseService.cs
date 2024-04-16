using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services.Database;
using MapsterMapper;

namespace ePrijevozSarajevo.Services
{
    public class BaseService<TModel, TSearch, TDbEntity> 
        : IService<TModel, TSearch>
        where TSearch : BaseSearchObject
        where TDbEntity : class
        where TModel : class
    {
        public DataContext Context { get; set; }
        public IMapper Mapper { get; set; }

        public BaseService(DataContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public TModel GetById(int id)
        {
            var entitiy = Context.Set<TModel>().Find(id);
            if (entitiy != null)
            {
                return Mapper.Map<TModel>(entitiy);
            }
            else
            {
                return null;
            }
        }

        public PagedResult<TModel> GetPaged(TSearch search)
        {
            List<TModel> result = new List<TModel>();

            var query = Context.Set<TDbEntity>().AsQueryable();

            query = AddFilter(search, query);


            if (search?.Page.HasValue == true && search?.PageSize.HasValue == true)
            {
                query = query.Skip(search.Page.Value * search.PageSize.Value).Take(search.PageSize.Value);
            }

            int count = query.Count();
            
            var list = query.ToList();

            result = Mapper.Map(list, result);

            PagedResult<TModel> pagedResult = new PagedResult<TModel>();
            pagedResult.ResultList = result;
            pagedResult.Count = count;

            return pagedResult;
        }

        public virtual IQueryable<TDbEntity> AddFilter(TSearch search, IQueryable<TDbEntity> query)
        {
            return query;
        }
    }
}
