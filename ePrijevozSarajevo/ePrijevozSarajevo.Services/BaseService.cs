using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services.Database;
using MapsterMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ePrijevozSarajevo.Services
{
    public class BaseService<TModel, TSearch, TdbEntity> : IService<TModel, TSearch>
        where TSearch : BaseSearchObject
        where TdbEntity : class
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
            var result = new List<TModel>();
            var query = Context.Set<TdbEntity>().AsQueryable();

            query = AddFilter(search, query);

            int count = query.Count();

            if (search.Page.HasValue == true && search.PageSize.HasValue == true)
            {
                query = query.Skip(search.Page.Value * search.PageSize.Value)
                    .Take(search.PageSize.Value);
            }

            var list = query.ToList();
            var resultList = Mapper.Map(list, result);

            PagedResult<TModel> response = new PagedResult<TModel>();
            response.ResultList = resultList;
            response.Count = count;

            return response;
        }

        private IQueryable<TdbEntity> AddFilter(TSearch search, IQueryable<TdbEntity> query)
        {
            return query;
        }
    }
}
