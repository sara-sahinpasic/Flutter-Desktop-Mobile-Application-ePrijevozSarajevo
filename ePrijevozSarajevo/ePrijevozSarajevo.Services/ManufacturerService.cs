using ePrijevozSarajevo.Model.Exceptions;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services.Database;
using MapsterMapper;
using Microsoft.IdentityModel.Tokens;

namespace ePrijevozSarajevo.Services
{
    public class ManufacturerService : BaseCRUDService<Model.Manufacturer, ManufacturerSearchObject, Database.Manufacturer,
        ManufacturerUpsertRequest, ManufacturerUpsertRequest>, IManufacturerService
    {
        public ManufacturerService(DataContext context, IMapper mapper) : base(context, mapper) { }
        public override IQueryable<Manufacturer> AddFilter(ManufacturerSearchObject search, IQueryable<Manufacturer> query)
        {
            query = base.AddFilter(search, query);
            if (!string.IsNullOrWhiteSpace(search.NameGTE))
            {
                query = query.Where(x => x.Name.StartsWith(search.NameGTE));
            }
            return query;
        }
        public override async Task<Model.Manufacturer> Insert(ManufacturerUpsertRequest request)
        {
            Database.Manufacturer entity = _mapper.Map<Database.Manufacturer>(request);

            var uniqueName = _dataContext.Manufacturers.FirstOrDefault(x => x.Name == entity.Name);
            if (uniqueName != null)
            {
                throw new UserException($"Naziv {entity.Name} već postoji.");
            }

            await _dataContext.Manufacturers.AddAsync(entity);
            await _dataContext.SaveChangesAsync();

            return _mapper.Map<Model.Manufacturer>(entity);
        }

        public override async Task<Model.Manufacturer> Update(int id, ManufacturerUpsertRequest request)
        {
            var entity = await _dataContext.Manufacturers.FindAsync(id);

            var existingManufacturer = _dataContext.Manufacturers
                .FirstOrDefault(x => x.Name == request.Name);

            if (existingManufacturer != null)
            {
                throw new UserException($"Naziv {request.Name} već postoji.");
            }

            _mapper.Map(request, entity);

            await _dataContext.SaveChangesAsync();

            return _mapper.Map<Model.Manufacturer>(entity);
        }
    }
}
