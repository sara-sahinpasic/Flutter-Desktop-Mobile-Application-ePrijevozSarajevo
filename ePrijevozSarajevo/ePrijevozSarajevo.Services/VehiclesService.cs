using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services.Database;
using MapsterMapper;

namespace ePrijevozSarajevo.Services
{
    public class VehiclesService : BaseService<Model.Vehicle, VehicleSearchObject, Database.Vehicle>, IVehiclesService
    {
        public DataContext context;
        public IMapper mapper;

        public VehiclesService(DataContext context, IMapper mapper) : base(context, mapper) { }
        //{
        //    this.context = context;
        //    this.mapper = mapper;
        //}
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
        /*public List<Model.Vehicle> GetList()
        {
            var result = new List<Model.Vehicle>();
            var list = _context.Vehicles.ToList();

            _mapper.Map(list, result);

            return result;
        }*/

        //Vehicle
       /* public PagedResult<Model.Vehicle> GetList(VehicleSearchObject searchObject)
        {
            var result = new List<Model.Vehicle>();

            var query = context.Vehicles.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchObject?.RegistrationNumberGTE))
            {
                query = query.Where(x => x.RegistrationNumber.StartsWith(searchObject.RegistrationNumberGTE));
            }


            if (searchObject.Page.HasValue == true && searchObject.PageSize.HasValue == true)
            {
                query = query.Skip(searchObject.PageSize.Value * searchObject.Page.Value)
                           .Take(searchObject.PageSize.Value);
            }

            int count = query.Count();

            var list = query.ToList();

            var resultList = mapper.Map(list, result);

            PagedResult<Model.Vehicle> response = new PagedResult<Model.Vehicle>();
            response.ResultList = resultList;
            response.Count = count;

            return response;
        }*/

        public Model.Vehicle Insert(VehicleInsertRequest request)
        {
            var entity = new Database.Vehicle();

            mapper.Map(request, entity);

            context.Add(entity);
            context.SaveChanges();

            return mapper.Map<Model.Vehicle>(entity);
        }
        public Model.Vehicle Update(int id, VehicleUpdateRequest request)
        {
            var entity = context.Vehicles.Find(id);
            mapper.Map(request, entity);

            context.SaveChanges();

            return mapper.Map<Model.Vehicle>(entity);
        }

        //VehicleType
        public List<Model.VehicleType> GetVehicleTypeList()
        {
            var result = new List<Model.VehicleType>();
            var list = context.VehicleTypes.ToList();

            result = mapper.Map(list, result);

            return result;
        }

        public Model.VehicleType InsertVehicleType(VehicleTypeInsertRequest request)
        {
            var entity = new Database.VehicleType();

            mapper.Map(request, entity);

            context.Add(entity);
            context.SaveChanges();

            return mapper.Map<Model.VehicleType>(entity);
        }

        public Model.VehicleType UpdateVehicleType(int id, VehicleTypeUpdateRequest request)
        {
            var entity = context.VehicleTypes.Find(id);

            mapper.Map(request, entity);

            context.SaveChanges();
            return mapper.Map<Model.VehicleType>(entity);
        }

        //Manufacturer
        public List<Model.Manufacturer> GetManufacturerTypeList()
        {
            var result = new List<Model.Manufacturer>();
            var list = context.Manufacturers.ToList();

            result = mapper.Map(list, result);

            return result;
        }

        public Model.Manufacturer InsertManufacturer(ManufacturerInsertRequest request)
        {
            var entity = new Database.Manufacturer();

            mapper.Map(request, entity);

            context.Add(entity);
            context.SaveChanges();

            return mapper.Map<Model.Manufacturer>(entity);
        }

        public Model.Manufacturer UpdateManufacturer(int id, ManufacturerUpdateRequest request)
        {
            var entity = context.Manufacturers.Find(id);

            mapper.Map(request, entity);

            context.SaveChanges();
            return mapper.Map<Model.Manufacturer>(entity);
        }
    }
}
