using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services.Database;
using MapsterMapper;

namespace ePrijevozSarajevo.Services
{
    public class VehicleTypeService : BaseCRUDService<Model.VehicleType,
        VehicleTypeSearchObject, Database.VehicleType, VehicleTypeInsertRequest, VehicleTypeUpdateRequest>, IVehicleTypeService
    {
        public VehicleTypeService(DataContext context, IMapper mapper) : base(context, mapper) { }
        public override IQueryable<VehicleType> AddFilter(VehicleTypeSearchObject search, IQueryable<VehicleType> query)
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
