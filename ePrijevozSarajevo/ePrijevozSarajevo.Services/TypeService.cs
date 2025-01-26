using ePrijevozSarajevo.Model.Exceptions;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services.Database;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ePrijevozSarajevo.Services
{
    public class TypeService : BaseCRUDService<Model.Type, TypeSearchObject, Database.Type, TypeUpsertRequest, TypeUpsertRequest>, ITypeService
    {
        public TypeService(DataContext context, IMapper mapper) : base(context, mapper) { }
        public override IQueryable<Database.Type> AddFilter(TypeSearchObject search, IQueryable<Database.Type> query)
        {
            query = base.AddFilter(search, query);

            if (!string.IsNullOrWhiteSpace(search?.NameGTE))
            {
                query = query.Where(x => x.Name.Contains(search.NameGTE));
            }
            return query;
        }
        public override async Task<Model.Type> Insert(TypeUpsertRequest request)
        {
            Database.Type entity = _mapper.Map<Database.Type>(request);

            var uniqueName = _dataContext.Types.FirstOrDefault(x => x.Name == entity.Name);
            if (uniqueName != null)
            {
                throw new UserException($"Naziv {entity.Name} već postoji.");
            }

            await _dataContext.Types.AddAsync(entity);
            await _dataContext.SaveChangesAsync();

            return _mapper.Map<Model.Type>(entity);
        }
        public override async Task<Model.Type> Update(int id, TypeUpsertRequest request)
        {
            var entity = await _dataContext.Types.FindAsync(id);

            var existingName = _dataContext.Types
                .FirstOrDefault(x => x.Name == request.Name);

            if (existingName != null)
            {
                throw new UserException($"Naziv {request.Name} već postoji.");
            }

            _mapper.Map(request, entity);

            await _dataContext.SaveChangesAsync();

            return _mapper.Map<Model.Type>(entity);
        }
        public override async Task Delete(int id)
        {
            var vehicleSet = _dataContext.Set<Database.Vehicle>();
            var vehicleExists = vehicleSet
                //.Include(x => x.Type)
                .Where(x => x.TypeId == id)
                .ToList();

            if (!vehicleExists.IsNullOrEmpty())
            {
                throw new UserException("Ne može se obrisati tip vozila za koje već postoji vozilo. Potrebno je prvo obrisati vozilo.");
            }

            var delaySet = _dataContext.Set<Database.Delay>();
            var delayExists = delaySet
            //.Include(x => x.Type)
            .Where(x => x.TypeId == id)
            .ToList();

            if (!delayExists.IsNullOrEmpty())
            {
                throw new UserException("Ne može se obrisati tip vozila za koje postoji kašnjenje. Potrebno je prvo obrisati kašnjenje.");
            }

            await base.Delete(id);
        }
    }
}
