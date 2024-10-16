using ePrijevozSarajevo.Model.SearchObjects;

namespace ePrijevozSarajevo.Services
{
    public interface ICRUDService <TModel, TSearch, TInsert, TUpdate> : IService<TModel, TSearch>
        where TModel : class
        where TSearch : BaseSearchObject
    {
        public Task<TModel> Insert(TInsert request);
        public Task <TModel> Update(int id, TUpdate request);
        public Task Delete(int id);

    }
}
