using ePrijevozSarajevo.Model.Exceptions;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services.Database;
using MapsterMapper;

namespace ePrijevozSarajevo.Services
{
    public class CountryService : BaseCRUDService<Model.Country,
        CountrySearchObject, Database.Country, CountryUpsertRequest,
        CountryUpsertRequest>, ICountryService
    {
        public CountryService(DataContext context, IMapper mapper) : base(context, mapper) { }

        public override IQueryable<Database.Country> AddFilter(CountrySearchObject search, IQueryable<Country> query)
        {
            query = base.AddFilter(search, query);

            if (!string.IsNullOrWhiteSpace(search?.CountryNameGTE))
            {
                query = query.Where(x => x.Name.Contains(search.CountryNameGTE));
            }
            return query;
        }
        public override async Task<Model.Country> Insert(CountryUpsertRequest request)
        {
            Database.Country entity = _mapper.Map<Database.Country>(request);

            var uniqueName = _dataContext.Countries.FirstOrDefault(x => x.Name == entity.Name);
            if (uniqueName != null)
            {
                throw new UserException($"Naziv {entity.Name} već postoji.");
            }

            await _dataContext.Countries.AddAsync(entity);
            await _dataContext.SaveChangesAsync();

            return _mapper.Map<Model.Country>(entity);
        }
        public override async Task<Model.Country> Update(int id, CountryUpsertRequest request)
        {
            var entity = await _dataContext.Countries.FindAsync(id);

            var existingManufacturer = _dataContext.Countries
                .FirstOrDefault(x => x.Name == request.Name);

            if (existingManufacturer != null)
            {
                throw new UserException($"Naziv {request.Name} već postoji.");
            }

            _mapper.Map(request, entity);

            await _dataContext.SaveChangesAsync();

            return _mapper.Map<Model.Country>(entity);
        }
    }
}
