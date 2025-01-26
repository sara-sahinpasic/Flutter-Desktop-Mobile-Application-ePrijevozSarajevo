using ePrijevozSarajevo.Model.Exceptions;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services.Database;
using MapsterMapper;

namespace ePrijevozSarajevo.Services
{
    public class MalfunctionService : BaseCRUDService<Model.Malfunction,
        MalfunctionSearchObject, Database.Malfunction,
        MalfunctionInsertRequest, MalfunctionUpdateRequest>
        , IMalfunctionService
    {
        public MalfunctionService(DataContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
        public override IQueryable<Malfunction> AddFilter(MalfunctionSearchObject search, IQueryable<Malfunction> query)
        {
                query = base.AddFilter(search, query);
            if (search?.VehicleIdGTE >= 0)
                {
                    query = query.Where(x => x.VehicleId == search.VehicleIdGTE);
                }
            return query;
        }
        public override Task<Model.Malfunction> Insert(MalfunctionInsertRequest request)
        {
            if (request != null && request.DateOfMalufunction != null && request.DateOfMalufunction.Value.Date > DateTime.Now.Date)
            {
                throw new UserException("Nije moguće unositi kvarove iz budućnosti");

            }
            return base.Insert(request);
        }
    }
}
