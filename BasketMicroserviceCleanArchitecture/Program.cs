using BaketMicroservice_Domain.BasketEntities;
using BasketMicroserviceCleanArchitecture_Application.BasketService;
using BasketMicroserviceCleanArchitecture_Application.IBasketService;
using BasketMicroserviceCleanArchitecture_Infrastracture.Application_Context;
using BasketMicroserviceCleanArchitecture_Infrastracture.BasketRepository;
using BasketMicroserviceCleanArchitecture_Infrastracture.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Sql Dependency Injection
var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(ConnectionString));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

#region Service Injected
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICustomService<Basket>, BasketService>();
#endregion
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ESports Shop Basket Microservice: Clean Architecture", Version = "v2" });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
