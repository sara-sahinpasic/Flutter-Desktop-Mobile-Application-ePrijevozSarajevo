using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Services.Database;
using MapsterMapper;

namespace ePrijevozSarajevo.Services
{
    public class RequestService : IRequestsService
    {
        public DataContext _context;
        public IMapper _mapper;

        public RequestService(DataContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        /*public List<Request> RequestsList = new List<Request>()
        {
            new Request()
            {
                RequestId = 1,
                Active = true,
                Approved = true,
                DocumentLink = "test"
            }
        };*/
        public List<Model.Request> GetList()
        {
            var result = new List<Model.Request>();
            var list = _context.Requests.ToList();

            _mapper.Map(list, result);
            return result;
        }

        public Model.Request Insert(RequestInsertRequest request)
        {
            var entity = new Database.Request();

            _mapper.Map(request, entity);

            _context.Requests.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Request>(entity);
        }

        public Model.Request Update(int id, RequestUpdateRequest request)
        {
            var entity = _context.Requests.Find(id);
            _mapper.Map(request, entity);

            _context.SaveChanges();

            return _mapper.Map<Model.Request>(entity);
        }
    }
};
