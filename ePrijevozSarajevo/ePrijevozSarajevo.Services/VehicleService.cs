using ePrijevozSarajevo.Model.Exceptions;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services.Database;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace ePrijevozSarajevo.Services
{
    public class VehicleService : BaseCRUDService<Model.Vehicle, VehicleSearchObject, Database.Vehicle, VehicleInsertRequest, VehicleUpdateRequest>, IVehicleService
    {
        public VehicleService(DataContext context, IMapper mapper) : base(context, mapper) { }

        public override IQueryable<Database.Vehicle> AddFilter(VehicleSearchObject search, IQueryable<Database.Vehicle> query)
        {
            query = base.AddFilter(search, query);

            if (!string.IsNullOrWhiteSpace(search?.RegistrationNumberGTE))
            {
                query = query.Where(x => x.RegistrationNumber.Contains(search.RegistrationNumberGTE));
            }

            if (search.IsManufacturerIncluded == true)
            {
                query = query.Include(x => x.Manufacturer);
            }

            if (search.IsVehicleTypeIncluded == true)
            {
                query = query.Include(x => x.Type);
            }
            return query;
        }
        public override async Task<Model.Vehicle> Update(int id, VehicleUpdateRequest request)
        {
            var set = _dataContext.Set<Database.Vehicle>();
            var entity = await set.FindAsync(id);

            var existingVehicle = await set
                .Where(x => x.Number == request.Number)
                .FirstOrDefaultAsync();

            if (existingVehicle != null)
            {
                throw new UserException("Broj vozila već postoji.");
            }

            _mapper.Map(request, entity);
            await BeforeUpdate(request, entity);
            await _dataContext.SaveChangesAsync();

            return _mapper.Map<Model.Vehicle>(entity);
        }

    }
}
