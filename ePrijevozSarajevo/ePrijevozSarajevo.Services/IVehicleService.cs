using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;

namespace ePrijevozSarajevo.Services
{
    public interface IVehicleService : ICRUDService<Vehicle, VehicleSearchObject, VehicleInsertRequest, VehicleUpdateRequest> { }
}
