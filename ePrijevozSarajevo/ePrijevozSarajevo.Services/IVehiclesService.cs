using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Model.Requests;

namespace ePrijevozSarajevo.Services
{
    public interface IVehiclesService
    {
        public List<Vehicle> GetList();
        public Vehicle Insert(VehiclesInsertRequest request);
        public Vehicle Update(int id, VehiclesUpdateRequest request);
    }
}
