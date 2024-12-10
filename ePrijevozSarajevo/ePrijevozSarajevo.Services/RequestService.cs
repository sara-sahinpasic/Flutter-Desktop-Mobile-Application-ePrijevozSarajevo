using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services.Database;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace ePrijevozSarajevo.Services
{
    public class RequestService : BaseCRUDService<Model.Request, RequestSearchObject, Database.Request, RequestInsertRequest, RequestUpdateRequest>,
        IRequestService
    {
        public RequestService(DataContext context, IMapper mapper) : base(context, mapper) { }

        public override IQueryable<Request> AddFilter(RequestSearchObject search, IQueryable<Request> query)
        {
            query = base.AddFilter(search, query);


            if (search?.UserStatusIdGTE >= 0)
            {
                query = query.Where(x => x.UserStatusId == search.UserStatusIdGTE);
            }

            if (search?.IsUserIncluded == true)
            {
                query = query
                    .Include(x => x.User)
                        .ThenInclude(y => y.UserStatus)
                    .Include(x => x.User)
                        .ThenInclude(y => y.UserCountry)
                    .Include(x => x.User)
                        .ThenInclude(y => y.UserRoles)
                        .ThenInclude(z => z.Role);
            }

            return query.Where(x => x.Active == true);
        }

        public async Task ApproveRequest(int requestId, DateTime expirationDate)
        {
#pragma warning disable CS8600 
            Request request = await _dataContext.Requests
                 .Include(r => r.User)
                 .FirstOrDefaultAsync(r => r.RequestId == requestId);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            User? user = request?.User;

            if (user != null)
            {
                request.Active = false;
                request.Approved = true;
                user.UserStatusId = (int)request.UserStatusId;
                user.StatusExpirationDate = expirationDate;

                if (user.StatusExpirationDate < DateTime.UtcNow || user.StatusExpirationDate == null && request.Active == false)
                {
                    user.UserStatusId = 1;
                    user.StatusExpirationDate = null;
                }

                _dataContext.Users.Update(user);
                _dataContext.Requests.Update(request);

                await _dataContext.SaveChangesAsync();
            }
        }

        public async Task<bool> RejectRequest(int requestId, string rejectionReason)
        {
#pragma warning disable CS8600 
            Request request = await _dataContext.Requests
                .Include(r => r.User)
                .FirstOrDefaultAsync(r => r.RequestId == requestId);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            if (request != null && request.Active == false)
            {
                return false;
            }

            User? user = request.User;

            request.Active = false;
            request.Approved = false;
            request.RejectionReason = rejectionReason;

            user.UserStatusId = 1;
            user.StatusExpirationDate = null;

            _dataContext.Users.Update(user);
            _dataContext.Requests.Update(request);

            await _dataContext.SaveChangesAsync();

            string content = rejectionReason;

            return true;
        }
    }
};
