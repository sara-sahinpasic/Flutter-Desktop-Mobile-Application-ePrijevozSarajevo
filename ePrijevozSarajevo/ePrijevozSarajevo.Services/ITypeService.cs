using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;

namespace ePrijevozSarajevo.Services
{
    public interface ITypeService : ICRUDService<Model.Type,
        TypeSearchObject, TypeUpsertRequest, TypeUpsertRequest>
    { }
}
