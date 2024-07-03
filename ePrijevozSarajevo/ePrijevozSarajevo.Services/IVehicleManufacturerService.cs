using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;

namespace ePrijevozSarajevo.Services
{
    public interface IVehicleManufacturerService : ICRUDService<Model.VehicleManufacturer, VehicleManufacturerSearchObject, VehicleManufacturerUpsertRequest, VehicleManufacturerUpsertRequest>
    {
    }
}
