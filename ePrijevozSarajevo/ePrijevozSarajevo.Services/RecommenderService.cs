using ePrijevozSarajevo.Services.Database;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using Microsoft.ML.Data;

namespace ePrijevozSarajevo.Services
{
    public class RecommenderService : IRecommenderService
    {
        private static readonly MLContext mlContext = new();
        private static readonly object isLocked = new();
        private static ITransformer? model = null;
        private static readonly string modelPath = "RouteRecommendationModel.zip";
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public RecommenderService(DataContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task TrainModelAsync()
        {
            lock (isLocked)
            {
                if (model != null)
                    return; // model already trained
            }

            // prepare data
            var routeUsage = _context.IssuedTickets
                .GroupBy(t => new { t.UserId, t.RouteId })
                .Select(g => new RouteUsageData
                {
                    UserId = g.Key.UserId,
                    RouteId = g.Key.RouteId,
                    UsageCount = g.Count()
                })
                .ToList();

            var trainingData = mlContext.Data.LoadFromEnumerable(routeUsage);

            // pipeline
            var pipeline = mlContext.Transforms.Conversion.MapValueToKey("UserId")
                .Append(mlContext.Transforms.Conversion.MapValueToKey("RouteId"))
                .Append(mlContext.Recommendation().Trainers.MatrixFactorization(
                    labelColumnName: "UsageCount",
                    matrixColumnIndexColumnName: "UserId",
                    matrixRowIndexColumnName: "RouteId"));

            // train the model
            var trainedModel = pipeline.Fit(trainingData);

            // save the model
            lock (isLocked)
            {
                model = trainedModel;
            }

            await Task.Run(() =>
            {
                mlContext.Model.Save(trainedModel, trainingData.Schema, modelPath);
            });
        }

        public async Task LoadModelAsync()
        {
            if (model != null)
                return; // model already loaded

            if (File.Exists(modelPath))
            {
                lock (isLocked)
                {
                    if (model == null)
                    {
                        model = mlContext.Model.Load(modelPath, out _);
                    }
                }
            }
            else
            {
               await TrainModelAsync();
            }
        }

        public async Task<IEnumerable<Model.Route>> RecommendRoutesAsync(int userId, int numberOfRecommendations)
        {
            await LoadModelAsync();

            if (model == null)
                throw new InvalidOperationException("Model not trained or loaded.");

            // create a prediction engine
            var predictionEngine = mlContext.Model.CreatePredictionEngine<RouteUsageData, RoutePrediction>(model);

            // fetching issuedTickets for the given user
            var userIssuedTickets = await FetchIssuedTicketsByUserAsync(userId);

            if (userIssuedTickets == null || !userIssuedTickets.Any())
            {
                return Enumerable.Empty<Model.Route>(); // no data for the user
            }

            // unique route IDs from the user
            var userRouteIds = userIssuedTickets
                .DistinctBy(t => new { t.Route.StartStationId, t.Route.EndStationId })
                .Select(t => t.RouteId);    

            // predict scores 
            var recommendedRoutes = new List<(int RouteId, float Score)>();

            foreach (var routeId in userRouteIds)
            {
                var prediction = predictionEngine.Predict(new RouteUsageData
                {
                    UserId = userId,
                    RouteId = routeId
                });

                recommendedRoutes.Add((routeId, prediction.Score));
            }

            var recommended = recommendedRoutes
                .OrderByDescending(r => r.Score)
                .Take(numberOfRecommendations)
                .Select(r => r.RouteId)
                .ToList();

            var allRoutes = GetAllRouteIdsAsync();

            var result = new List<Route>();
            recommended.ForEach(r => result.Add(allRoutes.Result.First(route => route.RouteId == r)));

            return _mapper.Map<List<Model.Route>>(result);
        }

        private async Task<IEnumerable<IssuedTicket>> FetchIssuedTicketsByUserAsync(int userId)
        {
            return await _context.IssuedTickets.Include(x => x.Route).Where(x => x.UserId == userId).ToListAsync();
        }

        private async Task<IEnumerable<Route>> GetAllRouteIdsAsync()
        {
            return await _context.Routes.ToListAsync();
        }
    }

    public class RouteUsageData
    {
        [LoadColumn(0)]
        public int UserId { get; set; }

        [LoadColumn(1)]
        public int RouteId { get; set; }

        [LoadColumn(2)]
        public float UsageCount { get; set; } 
    }

    public class RoutePrediction
    {
        [ColumnName("Score")]
        public float Score { get; set; }
    }
}
