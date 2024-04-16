using ePrijevozSarajevo.Model.SearchObjects;

namespace ePrijevozSarajevo.Services
{
    public interface ICRUDService <TModel, TSearch, TInsert, TUpdate> : IService<TModel, TSearch>
        where TModel : class
        where TSearch : BaseSearchObject
    {
        public TModel Insert(TInsert request);
        public TModel Update(int id, TUpdate request);
    }
}
