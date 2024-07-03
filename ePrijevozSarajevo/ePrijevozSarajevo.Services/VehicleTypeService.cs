using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services.Database;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace ePrijevozSarajevo.Services
{
    public class VehicleTypeService : BaseCRUDService<Model.VehicleType, VehicleTypeSearchObject, 
        Database.VehicleType,
        VehicleTypeUpsertRequest, VehicleTypeUpsertRequest>, IVehicleTypeService
    {
        public VehicleTypeService(DataContext context, IMapper mapper) : base(context, mapper)
        {
           
        }
        //public override IQueryable<VehicleType> AddFilter(VehicleTypeSearchObject search, IQueryable<VehicleType> query)
        //{
        //    query = base.AddFilter(search, query);

        //    if (search.IsTypeIncluded == true)
        //    {
        //        query = query.Include(x => x.Type);
        //    }
        //    return query;
        //}

    }
}
