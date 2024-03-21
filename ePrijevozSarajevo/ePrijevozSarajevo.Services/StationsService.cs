using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Services.Database;
using MapsterMapper;

namespace ePrijevozSarajevo.Services
{
    public class StationsService : IStationsService
    {
        public DataContext _context;
        public IMapper _mapper;
        public StationsService(DataContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        /*public List<Station> StationsList = new List<Station>()
        {
            new Station()
            {
                StationId = 1,
                DateCreated = DateTime.Now.Date,
                DateTime = DateTime.Now,
                Name = "Otoka"
            }
        };*/

        public List<Model.Station> GetList()
        {
            var result = new List<Model.Station>();
            var list = _context.Stations.ToList();
            _mapper.Map(list, result);

            return result;
        }

        public Model.Station Insert(StationInsertRequest request)
        {
            var entity = new Database.Station();
            _mapper.Map(request, entity);

            _context.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Station>(entity);
        }

        public Model.Station Update(int id, StationUpdateRequest request)
        {
            var entity = _context.Stations.Find(id);

            _mapper.Map(request, entity);

            _context.SaveChanges();

            return _mapper.Map<Model.Station>(entity);
        }
    }
}
