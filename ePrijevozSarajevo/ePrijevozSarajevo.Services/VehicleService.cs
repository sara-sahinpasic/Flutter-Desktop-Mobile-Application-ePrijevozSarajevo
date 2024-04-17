using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services.Database;
using MapsterMapper;

namespace ePrijevozSarajevo.Services
{
    public class VehicleService : BaseCRUDService<Model.Vehicle, VehicleSearchObject, Database.Vehicle, VehicleInsertRequest, VehicleUpdateRequest>, IVehicleService
    {
        public VehicleService(DataContext context, IMapper mapper) : base(context, mapper) { }

        public override IQueryable<Database.Vehicle> AddFilter(VehicleSearchObject search, IQueryable<Database.Vehicle> query)
        {
            var filteredQuery = base.AddFilter(search, query);
            if (!string.IsNullOrWhiteSpace(search?.RegistrationNumberGTE))
            {
                filteredQuery = filteredQuery.Where(x => x.RegistrationNumber.Contains(search.RegistrationNumberGTE));
            }
            return filteredQuery;
        }
    }
}
