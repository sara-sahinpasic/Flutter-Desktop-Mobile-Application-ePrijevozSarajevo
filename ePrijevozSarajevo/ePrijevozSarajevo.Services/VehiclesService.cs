using ePrijevozSarajevo.Model;

namespace ePrijevozSarajevo.Services
{
    public class VehiclesService : IVehiclesService
    {
        public List<Vehicle> VehiclesList = new List<Vehicle>()
        {
            new Vehicle()
            {
                VehicleId = 1,
                Number = 15,
                Color = "Yellow",
                RegistrationNumber = "A57-J-231",
                BuildYear = 1998
            }
        };
        public List<Vehicle> GetVehiclesList()
        {
            return VehiclesList;
        }
    }
}
