using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services.Database;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace ePrijevozSarajevo.Services
{
    public class BaseService<TModel, TSearch, TDbEntity>
        : IService<TModel, TSearch>
        where TSearch : BaseSearchObject
        where TDbEntity : class
        where TModel : class
    {
        public DataContext _dataContext { get; set; }
        public IMapper _mapper { get; set; }

        public BaseService(DataContext context, IMapper mapper)
        {
            _dataContext = context;
            _mapper = mapper;
        }

        public virtual async Task<PagedResult<TModel>> GetPaged(TSearch search)
        {
            List<TModel> result = new List<TModel>();

            var query = _dataContext.Set<TDbEntity>().AsQueryable();

            query = AddFilter(search, query);


            if (search?.Page.HasValue == true && search?.PageSize.HasValue == true)
            {
                query = query.Skip(search.Page.Value * search.PageSize.Value).Take(search.PageSize.Value);
            }

            int count = await query.CountAsync();

            var list = await query.ToListAsync();

            result = _mapper.Map(list, result);

            PagedResult<TModel> pagedResult = new PagedResult<TModel>();
            pagedResult.ResultList = result;
            pagedResult.Count = count;

            return pagedResult;
        }

        public virtual IQueryable<TDbEntity> AddFilter(TSearch search, IQueryable<TDbEntity> query)
        {
            return query;
        }

        public virtual async Task<TModel> GetById(int id)
        {
            var entitiy = await _dataContext.Set<TDbEntity>().FindAsync(id);

            return _mapper.Map<TModel>(entitiy);
        }
    }
}
