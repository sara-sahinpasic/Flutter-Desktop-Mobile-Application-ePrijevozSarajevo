using ePrijevozSarajevo.Model.Exceptions;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services.Database;
using MapsterMapper;

namespace ePrijevozSarajevo.Services
{
    public class StatusService : BaseCRUDService<Model.Status, StatusSearchObject, Database.Status, StatusInsertRequest, StatusUpdateRequest>, IStatusService
    {
        public StatusService(DataContext context, IMapper mapper) : base(context, mapper) { }
        public override IQueryable<Status> AddFilter(StatusSearchObject search, IQueryable<Status> query)
        {
            query = base.AddFilter(search, query);

            if (!string.IsNullOrWhiteSpace(search?.NameGTE))
            {
                query = query.Where(x => x.Name.Contains(search.NameGTE));
            }
            return query;
        }
        public override async Task<Model.Status> Insert(StatusInsertRequest request)
        {
            Database.Status entity = _mapper.Map<Database.Status>(request);

            var uniqueName = _dataContext.Statuses.FirstOrDefault(x => x.Name == entity.Name);
            if (uniqueName != null)
            {
                throw new UserException($"Naziv {entity.Name} već postoji.");
            }

            await _dataContext.Statuses.AddAsync(entity);
            await _dataContext.SaveChangesAsync();

            return _mapper.Map<Model.Status>(entity);
        }
        public override async Task<Model.Status> Update(int id, StatusUpdateRequest request)
        {
            var entity = await _dataContext.Statuses.FindAsync(id);

            var existingName = _dataContext.Statuses
                .FirstOrDefault(x => x.Name == request.Name);

            if (existingName != null)
            {
                throw new UserException($"Naziv {request.Name} već postoji.");
            }

            _mapper.Map(request, entity);

            await _dataContext.SaveChangesAsync();

            return _mapper.Map<Model.Status>(entity);
        }
    }
}
