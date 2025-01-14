using ePrijevozSarajevo.Model.Exceptions;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services.Database;
using MapsterMapper;
using Microsoft.IdentityModel.Tokens;

namespace ePrijevozSarajevo.Services
{
    public class StationService : BaseCRUDService<Model.Station, StationSearchObject, Database.Station, StationInsertRequest, StationUpdateRequest>, IStationService
    {
        public StationService(DataContext context, IMapper mapper) : base(context, mapper) { }
        public override IQueryable<Station> AddFilter(StationSearchObject search, IQueryable<Station> query)
        {
            query = base.AddFilter(search, query);

            if (!string.IsNullOrWhiteSpace(search?.NameGTE))
            {
                query = query.Where(x => x.Name.StartsWith(search.NameGTE));
            }

            return query;
        }

        public override Task Delete(int id)
        {
            var routes = _dataContext.Routes.Where(x => x.StartStationId == id || x.EndStationId == id);
            if (!routes.IsNullOrEmpty())
            {
                throw new UserException("Nije moguće obrisati stanicu koja se koristi. Potrebno obrisati prvo rute.");
            }
            return base.Delete(id);
        }
        public override async Task<Model.Station> Insert(StationInsertRequest request)
        {
            Database.Station entity = _mapper.Map<Database.Station>(request);

            var uniqueName = _dataContext.Stations.FirstOrDefault(x => x.Name == entity.Name);
            if (uniqueName != null)
            {
                throw new UserException($"Naziv {entity.Name} već postoji.");
            }

            await _dataContext.Stations.AddAsync(entity);
            await _dataContext.SaveChangesAsync();

            return _mapper.Map<Model.Station>(entity);
        }
        public override async Task<Model.Station> Update(int id, StationUpdateRequest request)
        {
            var entity = await _dataContext.Stations.FindAsync(id);

            var existingName = _dataContext.Stations
                .FirstOrDefault(x => x.Name == request.Name);

            if (existingName != null)
            {
                throw new UserException($"Naziv {request.Name} već postoji.");
            }

            _mapper.Map(request, entity);

            await _dataContext.SaveChangesAsync();

            return _mapper.Map<Model.Station>(entity);
        }
    }
}
