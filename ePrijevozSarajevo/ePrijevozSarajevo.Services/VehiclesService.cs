using ePrijevozSarajevo.Model;

namespace ePrijevozSarajevo.Services
{
    public class VehiclesService : IVehiclesService
    {
        public List<Vehicles> VehiclesList = new List<Vehicles>()
        {
            new Vehicles()
            {
                VehicleId = 1,
                Number = 15,
                Color = "Yellow",
                RegistrationNumber = "A57-J-231",
                BuildYear = 1998
            }
        };
        public List<Vehicles> GetVehiclesList()
        {
            return VehiclesList;
        }
    }
}
