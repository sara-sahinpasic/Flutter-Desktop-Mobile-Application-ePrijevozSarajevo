using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Services.Database;
using MapsterMapper;

namespace ePrijevozSarajevo.Services
{
    public class RoutesService : IRoutesService
    {
        public DataContext _context;
        public IMapper _mapper;

        public RoutesService(DataContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        /*public List<Route> RoutesList = new List<Route>()
        {
            new Route ()
            {
                RouteId = 1,
                Date = DateTime.Now.Date,
                TimeOfArrival = DateTime.Now.TimeOfDay,
                TimeOfDeparture = DateTime.Now.TimeOfDay,
                Active = true,
                ActiveOnHolidays = true,
                ActiveOnWeekend = true
            }
        };*/

        public List<Model.Route> GetList()
        {
            var result = new List<Model.Route>();
            var list = _context.Routes.ToList();

            result = _mapper.Map(list, result);
            return result;
        }

        public Model.Route Insert(RouteInsertRequest request)
        {
            var entity = new Database.Route();

            _mapper.Map(request, entity);

            _context.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Route>(entity);
        }

        public Model.Route Update(int id, RouteUpdateRequest request)
        {
            var entity = _context.Routes.Find(id);

            _mapper.Map(request, entity);

            _context.SaveChanges();

            return _mapper.Map<Model.Route>(entity);
        }
    }
}
