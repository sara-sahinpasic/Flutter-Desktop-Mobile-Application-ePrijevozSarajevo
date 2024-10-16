using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services.Database;
using MapsterMapper;

namespace ePrijevozSarajevo.Services
{
    public class BaseCRUDService<TModel, TSearch, TDbEntity, TInsert, TUpdate> : BaseService<TModel, TSearch, TDbEntity>
        where TModel : class
        where TSearch : BaseSearchObject
        where TDbEntity : class
    {
        public BaseCRUDService(DataContext context, IMapper mapper) : base(context, mapper) { }

        public virtual async Task<TModel> Insert(TInsert request)
        {
            TDbEntity entity = _mapper.Map<TDbEntity>(request);
            await BeforeInsert(request, entity);

            await _dataContext.AddAsync(entity);
            await _dataContext.SaveChangesAsync();

            return _mapper.Map<TModel>(entity);
        }

        public virtual async Task BeforeInsert(TInsert request, TDbEntity entity)
        {
        }

        public virtual async Task<TModel> Update(int id, TUpdate request)
        {
            var set = _dataContext.Set<TDbEntity>();
            var entity = await set.FindAsync(id);

            _mapper.Map(request, entity);

            await BeforeUpdate(request, entity);

            await _dataContext.SaveChangesAsync();

            return _mapper.Map<TModel>(entity);
        }

        public virtual async Task BeforeUpdate(TUpdate? request, TDbEntity? entity)
        {
        }
        public virtual async Task Delete(int id)
        {
            var entity = await _dataContext.Set<TDbEntity>().FindAsync(id);

            _dataContext.Set<TDbEntity>().Remove(entity);

            await _dataContext.SaveChangesAsync();
        }
    }
}
