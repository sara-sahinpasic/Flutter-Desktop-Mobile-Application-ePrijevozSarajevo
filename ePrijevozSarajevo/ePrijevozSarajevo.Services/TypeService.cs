using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services.Database;
using MapsterMapper;

namespace ePrijevozSarajevo.Services
{
    public class TypeService : BaseCRUDService<Model.Type, TypeSearchObject, Database.Type, TypeUpsertRequest, TypeUpsertRequest>, ITypeService
    {
        public TypeService(DataContext context, IMapper mapper) : base(context, mapper) { }
        public override IQueryable<Database.Type> AddFilter(TypeSearchObject search, IQueryable<Database.Type> query)
        {
            query = base.AddFilter(search, query);

            if (!string.IsNullOrWhiteSpace(search?.NameGTE))
            {
                query = query.Where(x => x.Name.Contains(search.NameGTE));
            }
            return query;
        }
    }
}
