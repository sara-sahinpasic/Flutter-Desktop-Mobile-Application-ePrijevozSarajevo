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
    }
}
