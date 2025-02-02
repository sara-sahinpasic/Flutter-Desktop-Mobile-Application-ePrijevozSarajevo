using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Model.Exceptions;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services.Database;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace ePrijevozSarajevo.Services
{
    public class MoodTrackerService : BaseCRUDService<Model.MoodTracker30012025, MoodTracker30012025SearchObject,
        Database.MoodTracker30012025, MoodTracker30012025UpsertRequest, MoodTracker30012025UpsertRequest>
        , IMoodTrackerService
    {
        public MoodTrackerService(DataContext context, IMapper mapper) : base(context, mapper) { }
        //public override IQueryable<Database.MoodTracker30012025> AddFilter(MoodTracker30012025SearchObject search, 
        //    IQueryable<Database.MoodTracker30012025> query)
        //{
        //    query = base.AddFilter(search, query);
        //    if (search?.IsRaspolozenjeIncluded == true)
        //    {
        //        query = query.Include(x => x.VrijednostRaspolozenja);
        //    }

        //    if (search?.UserId != null && search?.VrijednostRaspolozenjaId != null && search?.DatumEvidencije != null)
        //    {

        //        query = query.Where(x =>
        //        x.UserId == search.UserId
        //        && x.VrijednostRaspolozenjaId == search.VrijednostRaspolozenjaId
        //        && x.DatumEvidencije.Date == search.DatumEvidencije.Value.Date
        //        );
        //    }

        //    return query;
        //}

        public override async Task<Model.MoodTracker30012025> Insert(MoodTracker30012025UpsertRequest request)
        {
            Database.MoodTracker30012025 entity = _mapper.Map<Database.MoodTracker30012025>(request);

            DateTime today = DateTime.Now;

            int unosRaspolozenjaPoDanu = await _dataContext.MoodTracker30012025s
                .Where(x =>
                x.DatumEvidencije.Date == today &&
                x.UserId == request.UserId)
                .CountAsync();

            if (unosRaspolozenjaPoDanu >= 2)
            {
                throw new UserException("Max 2 unosa raspoloženja u danu.");
            }
            await _dataContext.AddAsync(entity);
            await _dataContext.SaveChangesAsync();
            return _mapper.Map<Model.MoodTracker30012025>(entity);
        }


        public async Task<CountRaspolozenja> GetCountRaspolozenja()
        {
            int countRaspolozenjeSretan = _dataContext.MoodTracker30012025s.Where(x => x.VrijednostRaspolozenjaId == 1).Count();
            int countRaspolozenjeTuzan = _dataContext.MoodTracker30012025s.Where(x => x.VrijednostRaspolozenjaId == 2).Count();
            int countRaspolozenjeUzbuden = _dataContext.MoodTracker30012025s.Where(x => x.VrijednostRaspolozenjaId == 3).Count();
            int countRaspolozenjeUmoran = _dataContext.MoodTracker30012025s.Where(x => x.VrijednostRaspolozenjaId == 4).Count();
            int countRaspolozenjePodStresom = _dataContext.MoodTracker30012025s.Where(x => x.VrijednostRaspolozenjaId == 5).Count();

            return new CountRaspolozenja()
            {
                SretanCount = countRaspolozenjeSretan,
                TuzanCount = countRaspolozenjeTuzan,
                UzbudenCount = countRaspolozenjeUzbuden,
                UmoranCount = countRaspolozenjeUmoran,
                PodStresomCount = countRaspolozenjePodStresom
            };
        }


    }
}
