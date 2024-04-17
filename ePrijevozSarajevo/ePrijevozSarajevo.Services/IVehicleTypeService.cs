using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;

namespace ePrijevozSarajevo.Services
{
    public interface IVehicleTypeService : ICRUDService<Model.VehicleType, VehicleTypeSearchObject, VehicleTypeInsertRequest, VehicleTypeUpdateRequest>
    {
    }
}
