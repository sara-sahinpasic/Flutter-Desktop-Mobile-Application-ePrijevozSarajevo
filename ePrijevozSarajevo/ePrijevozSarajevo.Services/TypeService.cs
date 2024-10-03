using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services.Database;
using MapsterMapper;

namespace ePrijevozSarajevo.Services
{
    public class TypeService : BaseCRUDService<Model.Type, TypeSearchObject, Database.Type,
        TypeUpsertRequest, TypeUpsertRequest>, ITypeService
    {
        public TypeService(DataContext context, IMapper mapper) : base(context, mapper)
        {
        }
        
    }
}
