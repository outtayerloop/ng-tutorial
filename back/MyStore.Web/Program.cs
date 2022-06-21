using Azure.Identity;
using Microsoft.EntityFrameworkCore;
using MyStore.Core.Data.Context.Postgres;
using MyStore.Core.Domain.Service.Store;
using MyStore.Core.Domain.Service.Validation;
using MyStore.Core.Domain.Service.Validation.Rules;
using MyStore.Core.Repository;
using MyStore.Core.Repository.Products;
using MyStore.Core.Repository.Shippings;

var builder = WebApplication.CreateBuilder(args);
string corsPolicy = builder.Configuration["CorsSettings:CorsPolicy"];

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsPolicy,
        corsBuilder =>
        {
            corsBuilder.WithOrigins(builder.Configuration["CorsSettings:ClientHost"]).AllowAnyHeader();
        });
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(typeof(IStoreRepository<>), typeof(StoreRepository<>));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IShippingRepository, ShippingRepository>();
builder.Services.AddScoped<IShoppingService, ShoppingService>();
builder.Services.AddScoped<NameRule>();
builder.Services.AddScoped<DescriptionRule>();
builder.Services.AddScoped<PriceRule>();
builder.Services.AddScoped<IProductValidator, ProductValidator>();

// Configure the database context
string connectionString;
if (builder.Environment.IsDevelopment())
    connectionString = Environment.GetEnvironmentVariable("MY_STORE_DB_CONNECTION_STRING")!;
else
{
    builder.Configuration.AddAzureKeyVault(
           new Uri($"https://{builder.Configuration["KeyVaultName"]}.vault.azure.net/"),
           new DefaultAzureCredential());
    connectionString = builder.Configuration["MY-STORE-CONNECTION-STRING"];
}
builder.Services.AddDbContext<MyStoreDbContext>(options => options.UseNpgsql(connectionString));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseCors(corsPolicy);

app.UseAuthorization();

app.MapControllers();

app.Run();