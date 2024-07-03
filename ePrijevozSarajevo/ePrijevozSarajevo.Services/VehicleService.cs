using EasyNetQ.Logging;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services.Database;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace ePrijevozSarajevo.Services
{
    public class VehicleService : BaseCRUDService<Model.Vehicle, VehicleSearchObject, Database.Vehicle, VehicleInsertRequest, VehicleUpdateRequest>, IVehicleService
    {
        //ILogger<VehicleService> _logger;
        public VehicleService(DataContext context, IMapper mapper 
            //ILogger<VehicleService> logger
            ) : base(context, mapper) {
            //_logger = logger;
        }

        public override IQueryable<Database.Vehicle> AddFilter(VehicleSearchObject search, IQueryable<Database.Vehicle> query)
        {
            query = base.AddFilter(search, query);
           
            if (!string.IsNullOrWhiteSpace(search?.RegistrationNumberGTE))
            {
                query = query.Where(x => x.RegistrationNumber.Contains(search.RegistrationNumberGTE));
            }
            //if (search.IsManufacturerIncluded == true)
            //{
            //    query=query.Include(x=>x.VehicleManufacturers).ThenInclude(x=>x.Manufacturer);
            //}
            //if(search.IsVehicleTypeIncluded == true)
            //{
            //    query=query.Include(x=>x.VehicleTypes).ThenInclude(x=>x.Type);
            //}
           /* if (search?.IsVehicleTypeIncluded == true)
            {
                query = query.Include(x => x.VehicleType);
            }
            if (search?.IsManufacturerIncluded == true)
            {
                query = query.Include(x => x.Manufacturer);
            }*/
            return query;
        }
    }
}
