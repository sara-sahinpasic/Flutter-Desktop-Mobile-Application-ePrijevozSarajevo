using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services.Database;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML;

namespace ePrijevozSarajevo.Services
{
    public class RouteService : BaseCRUDService<Model.Route, RouteSearchObject, Database.Route, RouteInsertRequest, RouteUpdateRequest>, IRouteService
    {
        private static readonly MLContext mlContext = new();
        private static readonly object isLocked = new();
        private static ITransformer model = null;
        private static readonly string modelPath = "RouteRecommendationModel7.zip";

        public RouteService(DataContext context, IMapper mapper) : base(context, mapper) 
        {
            lock (isLocked)
            {
                if (File.Exists(modelPath))
                {
                    Console.WriteLine("Loading existing model...");
                    using var fileStream = new FileStream(modelPath, FileMode.Open, FileAccess.Read, FileShare.Read);
                    model = mlContext.Model.Load(fileStream, out _);
                }
                else
                {
                    Console.WriteLine("Training new model...");
                    TrainModel();
                }
            }
        }

        public override IQueryable<Database.Route> AddFilter(RouteSearchObject search, IQueryable<Database.Route> query)
        {
            query = base.AddFilter(search, query);

            if ((search?.StartStationIdGTE >= 0) && (search.DateGTE.Year > 1))
            {

                query = query.Where(x => x.StartStationId == search.StartStationIdGTE || x.EndStationId == search.EndStationIdGTE)
                             .Where(x => x.Departure.Date.Equals(search.DateGTE.Date))
                             .Where(x => x.Departure.Date >= search.DateGTE.Date && x.Departure.TimeOfDay >= search.DateGTE.TimeOfDay);

            }
            if (search.IsStationIncluded == true)
            {
                query = query.Include(x => x.StartStation)
                   .Include(y => y.EndStation);
            }
            if (search.IsVehicleIncluded == true)
            {
                query = query.Include(x => x.Vehicle)
                             .ThenInclude(y => y.Type)
                             .Include(x => x.Vehicle.Manufacturer);
            }

            return query;
        }
        public async Task DeleteRouteWithIssuedTickets(int routeId)
        {
            // Route from past
            DateTime todayDate = DateTime.Now;

            var route = await _dataContext.Routes.FindAsync(routeId);

            if (route == null)
            {
                throw new InvalidOperationException("Ruta nije pronađena.");
            }

            if (route.Departure <= todayDate)
            {
                throw new InvalidOperationException("Nije moguće izbrisati rutu s prošlim datumom polaska.");
            }

            // Find and delete issued tickets related to the route
            var issuedTickets = _dataContext.IssuedTickets.Where(t => t.RouteId == routeId);
            _dataContext.IssuedTickets.RemoveRange(issuedTickets);

            _dataContext.Routes.Remove(route);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Model.Route> InsertArrivalDeparture(RouteInsertRequest request)
        {
            Database.Route entity = _mapper.Map<Database.Route>(request);
            await BeforeInsert(request, entity);

            if (entity.Arrival < entity.Departure)
            {
                throw new InvalidOperationException("Vrijeme dolaska ne može biti biti manje od vremena polaska.");
            }
            else
            {
                await _dataContext.AddAsync(entity);
                await _dataContext.SaveChangesAsync();
            }
            return _mapper.Map<Model.Route>(entity);
        }

        public async Task<Model.Route> UpdateArrivalDeparture(int id, RouteUpdateRequest request)
        {
            var set = _dataContext.Set<Database.Route>();
            var entity = await set.FindAsync(id);

            if (entity != null && request.Arrival < request.Departure)
            {
                throw new InvalidOperationException("Update:: Vrijeme dolaska ne može biti biti manje od vremena polaska.");
            }
            else
            {
                _mapper.Map(request, entity);
                await BeforeUpdate(request, entity);
                await _dataContext.SaveChangesAsync();
            }
            return _mapper.Map<Model.Route>(entity);
        }
        //
        /*public List<Model.Route> GetRecommendations(int userId, int maxRecommendations = 5)
        {
            // Step 1: Get the user's previously purchased tickets
            var userTickets = _dataContext.IssuedTickets
                .Where(t => t.UserId == userId)
                .Select(t => t.RouteId)
                .Distinct()
                .ToList();

            if (!userTickets.Any())
                return new List<Model.Route>(); // No recommendations if user has no history

            // Step 2: Get routes related to the user's ticket history
            var userRoutes = _dataContext.Routes
                .Where(r => userTickets.Contains(r.RouteId))
                .ToList();

            // Step 3: Build a similarity-based recommendation list
            var recommendedRoutes = _dataContext.Routes
                .Where(r => !userTickets.Contains(r.RouteId)) // Exclude already purchased routes
                .AsEnumerable()
                .Select(r => new
                {
                    Route = r,
                    Similarity = CalculateRouteSimilarity(r, userRoutes)
                })
                .Where(x => x.Similarity > 0) // Filter routes with no similarity
                .OrderByDescending(x => x.Similarity) // Sort by similarity
                .Take(maxRecommendations) // Limit the number of recommendations
                .Select(x => x.Route)
                .ToList();

            return _mapper.Map<List<Model.Route>>(recommendedRoutes);
        }

        private double CalculateRouteSimilarity(Database.Route candidateRoute, List<Database.Route> userRoutes)
        {
            double similarity = 0;

            foreach (var userRoute in userRoutes)
            {
                // Add weights to prioritize certain properties (e.g., StartStationId and EndStationId)
                double stationMatch = (candidateRoute.StartStationId == userRoute.StartStationId ? 0.5 : 0) +
                                      (candidateRoute.EndStationId == userRoute.EndStationId ? 0.5 : 0);

                double vehicleMatch = (candidateRoute.VehicleId == userRoute.VehicleId ? 0.3 : 0);

                similarity += stationMatch + vehicleMatch;
            }

            return similarity / userRoutes.Count; // Average similarity across all user routes
        }*/

        public List<Model.Route> GetRecommendations(int userId, int maxRecommendations = 5)
        {
            // Step 1: Get the user's previously purchased tickets
            var userTickets = _dataContext.IssuedTickets
                .Where(t => t.UserId == userId)
                .Select(t => t.RouteId)
                .Distinct()
                .ToList();

            if (!userTickets.Any())
                return new List<Model.Route>(); // No recommendations if user has no history

            // Step 2: Retrieve user's route history
            var userRoutes = _dataContext.Routes
                .Where(r => userTickets.Contains(r.RouteId))
                .ToList();

            // Step 3: Generate recommendations using ML model
            var predictionResults = new List<(Route Route, float Score)>();

            foreach (var candidateRoute in _dataContext.Routes.Where(r => !userTickets.Contains(r.RouteId)))
            {
                var predictionEngine = mlContext.Model.CreatePredictionEngine<RouteFeatures, CopurchasePrediction>(model);
                var prediction = predictionEngine.Predict(new RouteFeatures
                {
                    StartStationId = (float)candidateRoute.StartStationId,
                    EndStationId = (float)candidateRoute.EndStationId
                });

                predictionResults.Add((candidateRoute, prediction.Score));
            }

            // Step 4: Return top recommendations
            var recommendedRoutes = predictionResults
                .OrderByDescending(x => x.Score)
                .Take(maxRecommendations)
                .Select(x => x.Route)
                .ToList();

            return _mapper.Map<List<Model.Route>>(recommendedRoutes);
        }
        //.
        private void TrainModel()
        {
            // Retrieve data from the database
            var issuedTickets = _dataContext.IssuedTickets.Include("Route").ToList();
            var data = issuedTickets.Select(ticket => new RouteFeatures
            {
                StartStationId = (float)ticket.Route.StartStationId,
                EndStationId = (float)ticket.Route.EndStationId,
                MatrixColumnIndex = ticket.TicketId, // Example mapping
                 Label = 1 // Example: Assign a constant score for training purposes
            }).ToList();



            // Load data into ML.NET
            IDataView dataView = mlContext.Data.LoadFromEnumerable(data);

            // Build data processing pipeline
            var dataPipeline = mlContext.Transforms
            .Concatenate("Features", nameof(RouteFeatures.StartStationId), nameof(RouteFeatures.EndStationId))
            .Append(mlContext.Transforms.NormalizeMinMax("Features"))
            .Append(mlContext.Transforms.CopyColumns("Label", nameof(RouteFeatures.Label))); // Ensure Label is used


            // Define the regression trainer
            var trainer = mlContext.Regression.Trainers.Sdca(labelColumnName: "Label", featureColumnName: "Features");

            // Build and train the pipeline
            var trainingPipeline = dataPipeline.Append(trainer);
            model = trainingPipeline.Fit(dataView);

            // Save the trained model
            Console.WriteLine("Saving the trained model...");
            mlContext.Model.Save(model, dataView.Schema, modelPath);
        }
        
        // Supporting classes
        public class CopurchasePrediction
        {
            public float Score { get; set; }
        }

        public class RouteFeatures
        {
            public float StartStationId { get; set; }
            public float EndStationId { get; set; }
            public int MatrixColumnIndex { get; set; } // Add missing fields
            public float Label { get; set; }
        }
    }
}