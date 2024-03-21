using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Services.Database;
using MapsterMapper;

namespace ePrijevozSarajevo.Services
{
    public class VehiclesService : IVehiclesService
    {
        public DataContext _context;
        public IMapper _mapper;

        public VehiclesService(DataContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        /* public List<Vehicle> VehiclesList = new List<Vehicle>()
         {
             new Vehicle()
             {
                 VehicleId = 1,
                 Number = 15,
                 Color = "Yellow",
                 RegistrationNumber = "A57-J-231",
                 BuildYear = 1998
             }
         };*/
        public List<Model.Vehicle> GetList()
        {
            var result = new List<Model.Vehicle>();
            var list = _context.Vehicles.ToList();

            _mapper.Map(list, result);

            return result;
        }

        public Model.Vehicle Insert(VehiclesInsertRequest request)
        {
            var entity = new Database.Vehicle();

            _mapper.Map(request, entity);

            _context.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Vehicle>(entity);
        }

        public Model.Vehicle Update(int id, VehiclesUpdateRequest request)
        {
            var entity = _context.Vehicles.Find(id);
            _mapper.Map(request, entity);

            _context.SaveChanges();

            return _mapper.Map<Model.Vehicle>(entity);
        }
    }
}
