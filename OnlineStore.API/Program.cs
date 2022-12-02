using Home = OnlineStore.API.MappingProfiles.Home;
using ProductDetails = OnlineStore.API.MappingProfiles.ProductDetails;
using ShoppingCart = OnlineStore.API.MappingProfiles.ShoppingCart;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add AutoMapper profiles.
builder.Services.AddAutoMapper(
    typeof(Home.LaptopProfile),
    typeof(ProductDetails.LaptopProfile),
    typeof(ShoppingCart.LaptopProfile));

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
