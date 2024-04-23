using ePrijevozSarajevo.Services;
using ePrijevozSarajevo.Services.Database;
using ePrijevozSarajevo.Services.TicketsStateMachine;
using Mapster;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Dependency Injection
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IVehicleService, VehicleService>();
builder.Services.AddTransient<IRouteService, RouteService>();
builder.Services.AddTransient<IStationService, StationService>();
builder.Services.AddTransient<IRequestService, RequestService>();
builder.Services.AddTransient<IManufacturerService, ManufacturerService>();
builder.Services.AddTransient<IVehicleTypeService, VehicleTypeService>();
builder.Services.AddTransient<ITicketService, TicketService>();
builder.Services.AddTransient<IIssuedTicketService, IssuedTicketService>();

//State machine
builder.Services.AddTransient<BaseTicketState>();
builder.Services.AddTransient<InitialTicketState>();
builder.Services.AddTransient<DraftTicketState>();
builder.Services.AddTransient<ActiveTicketState>();





//Connection string EF
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});

//Mapster
builder.Services.AddMapster();

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
