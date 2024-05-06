using ePrijevozSarajevo.API;
using ePrijevozSarajevo.API.Filters;
using ePrijevozSarajevo.Services;
using ePrijevozSarajevo.Services.Database;
using ePrijevozSarajevo.Services.TicketsStateMachine;
using Mapster;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

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
builder.Services.AddTransient<HiddenTicketState>();


//Connection string EF
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});

//Mapster
builder.Services.AddMapster();

builder.Services.AddControllers(x =>
{
    x.Filters.Add<ExceptionFilter>();
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//Basic Authentication
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("basicAuth", new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
    {
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "basic"
    });
    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
              Reference =new OpenApiReference{Type=ReferenceType.SecurityScheme, Id="basicAuth"}
            },
            new string[]{ }
        }
    });
});
//Basic Authentication
builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

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
