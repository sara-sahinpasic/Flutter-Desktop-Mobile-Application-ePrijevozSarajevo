using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Model.Exceptions;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services.Database;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace ePrijevozSarajevo.Services
{
    public class RezervacijaProstoraService : BaseCRUDService<Model.RezervacijaProstora20022025,
        RezervacijaProstora20022025SearchObject, Database.RezervacijaProstora20022025,
        RezervacijaProstora20022025UpsertRequest, RezervacijaProstora20022025UpsertRequest>,
            IRezervacijeProstoraService
    {
        public RezervacijaProstoraService(DataContext context, IMapper mapper) : base(context, mapper)
        {
        }

        private IQueryable<Database.RezervacijaProstora20022025> filterByDate(IQueryable<Database.RezervacijaProstora20022025> query,
            RezervacijaProstora20022025SearchObject search)
        {
            return query.Where(x =>
                x.PocetakRezervacije.Date >= search.PocetakRezervacije.Value.Date);

        }

        private IQueryable<Database.RezervacijaProstora20022025> filterByRaspolozenje(IQueryable<Database.RezervacijaProstora20022025> query,
            RezervacijaProstora20022025SearchObject search)
        {
            return query.Where(x => x.RadniProstorId == search.RadniProstorId);

        }

        private IQueryable<Database.RezervacijaProstora20022025> filterByUser(IQueryable<Database.RezervacijaProstora20022025> query, RezervacijaProstora20022025SearchObject search)
        {
            return query.Where(x => x.UserId == search.UserId);

        }

          private IQueryable<Database.RezervacijaProstora20022025> applyFilters(IQueryable<Database.RezervacijaProstora20022025> query,
              RezervacijaProstora20022025SearchObject search)
          {
              query = query.Include(x => x.StatusRezervacije);
              query = query.Include(x => x.User);

               bool userSelectedDateFilter = search.PocetakRezervacije != null;
               bool userSelectedRaspolozenjeFilter = search.RadniProstorId != null;
               bool userSelectedUserFilter = search.UserId != null;

               if (userSelectedDateFilter)
               {
                   query = filterByDate(query, search);
               }
               if (userSelectedRaspolozenjeFilter)
               {
                   query = filterByRaspolozenje(query, search);
               }
               if (userSelectedUserFilter)
               {
                   query = filterByUser(query, search);
               }

              return query;
          }


        private IQueryable<TotalDto> mapToDto(IQueryable<Database.RezervacijaProstora20022025> query)
        {
            return query
                .GroupBy(x => new { x.StatusRezervacijeId, })
                .Select(g => new TotalDto
                {
                    StatusRezervacijeId = g.Key.StatusRezervacijeId,
                    CountStatusa = g.Count()
                });

        }



        public override IQueryable<Database.RezervacijaProstora20022025> AddFilter(RezervacijaProstora20022025SearchObject search,
            IQueryable<Database.RezervacijaProstora20022025> query)
        {
            query = base.AddFilter(search, query);

            return applyFilters(query, search);
        }

        public async Task<List<TotalDto>> TotalList(RezervacijaProstora20022025SearchObject search) // labela ispod tabele
        {
            List<TotalDto> result = new();
            var query = _dataContext.RezervacijaProstora20022025s.AsQueryable();

            query = applyFilters(query, search);

            result = mapToDto(query).ToList();

            return result;
        }

        public override async Task<Model.RezervacijaProstora20022025> Insert(RezervacijaProstora20022025UpsertRequest request)
        {
            request.StatusRezervacijeId = 1;
            Database.RezervacijaProstora20022025 entity = _mapper.Map<Database.RezervacijaProstora20022025>(request);

            var countStatusaPoJednomDanu = _dataContext.RezervacijaProstora20022025s
                .Where(x => x.UserId == request.UserId)
                
                //.Where(x => x.DatumEvidencije == request.DatumEvidencije)
                .Count();
            if (countStatusaPoJednomDanu >= 2)
            {
                throw new UserException($"Ne može se unijeti više od 2 raspoloženja za usera u danu.");
            }

            await _dataContext.RezervacijaProstora20022025s.AddAsync(entity);
            await _dataContext.SaveChangesAsync();

            return _mapper.Map<Model.RezervacijaProstora20022025>(entity);
        }

    }
}


