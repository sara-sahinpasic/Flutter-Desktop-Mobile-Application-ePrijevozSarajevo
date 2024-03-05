using ePrijevozSarajevo.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Dependency Injection
builder.Services.AddTransient<IEmployeesService, EmployeesService>();
builder.Services.AddTransient<IVehiclesService, VehiclesService>();
builder.Services.AddTransient<IRoutesService, RoutesService>();
builder.Services.AddTransient<IStationsService, StationsService>();
builder.Services.AddTransient<IRequestsService, RequestService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
