using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services.Database;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace ePrijevozSarajevo.Services
{
    public class VehicleManufacturerService : BaseCRUDService<Model.VehicleManufacturer, VehicleManufacturerSearchObject, Database.VehicleManufacturer,
        VehicleManufacturerUpsertRequest, VehicleManufacturerUpsertRequest>, IVehicleManufacturerService
    {
        public VehicleManufacturerService(DataContext context, IMapper mapper) : base(context, mapper)
        {
           
        }
        //public override IQueryable<VehicleManufacturer> AddFilter(VehicleManufacturerSearchObject search, IQueryable<VehicleManufacturer> query)
        //{
        //    query= base.AddFilter(search, query);

        //    if (search.IsManufactureIncluded == true)
        //    {
        //        query=query.Include(x=>x.Manufacturer);
        //    }
        //    return query;
        //}
    }
}
