using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Model.SearchObjects;

namespace ePrijevozSarajevo.Services
{
    public interface IService<TModel, TSearch>
            where TSearch : BaseSearchObject
    {
        public Task<PagedResult<TModel>> GetPaged(TSearch search);
        public Task<TModel> GetById(int id);
    }
}
