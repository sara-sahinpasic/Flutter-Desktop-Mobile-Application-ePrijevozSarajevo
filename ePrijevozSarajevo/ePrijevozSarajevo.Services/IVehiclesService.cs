using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;

namespace ePrijevozSarajevo.Services
{
    public interface IVehiclesService : IService<Model.Vehicle, VehicleSearchObject>
    {
        //Vehicle
        //public PagedResult<Vehicle> GetList(VehicleSearchObject searchObject);
        public Vehicle Insert(VehicleInsertRequest request);
        public Vehicle Update(int id, VehicleUpdateRequest request);
        //VehicleType
        public List<VehicleType> GetVehicleTypeList();
        public VehicleType InsertVehicleType(VehicleTypeInsertRequest request);
        public VehicleType UpdateVehicleType(int id, VehicleTypeUpdateRequest request);
        //Manufacturer
        public List<Manufacturer> GetManufacturerTypeList();
        public Manufacturer InsertManufacturer(ManufacturerInsertRequest request);
        public Manufacturer UpdateManufacturer(int id, ManufacturerUpdateRequest request);
    }
}
