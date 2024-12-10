using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services.Database;
using MapsterMapper;

namespace ePrijevozSarajevo.Services
{
    public class ManufacturerService : BaseCRUDService<Model.Manufacturer, ManufacturerSearchObject, Database.Manufacturer,
        ManufacturerUpsertRequest, ManufacturerUpsertRequest>, IManufacturerService
    {
        public ManufacturerService(DataContext context, IMapper mapper) : base(context, mapper) { }
        public override IQueryable<Manufacturer> AddFilter(ManufacturerSearchObject search, IQueryable<Manufacturer> query)
        {
            query = base.AddFilter(search, query);
            if (!string.IsNullOrWhiteSpace(search.NameGTE))
            {
                query = query.Where(x => x.Name.StartsWith(search.NameGTE));
            }
            return query;
        }
    }
}
