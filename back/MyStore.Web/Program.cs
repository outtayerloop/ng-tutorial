using Azure.Identity;
using Microsoft.EntityFrameworkCore;
using MyStore.Core.Application;
using MyStore.Core.Database;
using MyStore.Core.Repository;

var builder = WebApplication.CreateBuilder(args);
string corsPolicy = builder.Configuration["CorsSettings:CorsPolicy"];

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsPolicy,
        corsBuilder =>
        {
            corsBuilder.WithOrigins(builder.Configuration["CorsSettings:ClientHost"]);
        });
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(typeof(IStoreRepository<>), typeof(StoreRepository<>));
builder.Services.AddScoped<IStoreApplication, StoreApplication>();

// Configure the database context
string connectionString = Environment.GetEnvironmentVariable("MY_STORE_DB_CONNECTION_STRING");
builder.Services.AddDbContext<MyStoreDbContext>(options => options.UseNpgsql(connectionString));

// Configure the Azure Key Vault access
if (!builder.Environment.IsDevelopment())
{
    builder.Configuration.AddAzureKeyVault(
           new Uri($"https://{builder.Configuration["KeyVaultName"]}.vault.azure.net/"),
           new DefaultAzureCredential());
}


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

app.MapGet("/", (IConfiguration config) =>
{
    try
    {
        return string.Join(
            Environment.NewLine,
            "SecretName (Name in Key Vault: 'SecretName')",
            @"Obtained from configuration with config[""MY-STORE-DB-CONNECTION-STRING""]",
            $"Value: {config["MY-STORE-DB-CONNECTION-STRING"]}",
            "");
    }
    catch(Exception ex)
    {
        string res = "Exception message : ";
        res += ex.Message;
        if(ex.InnerException != null)
            res += "\nInner exception message : " + ex.InnerException.Message;
        res += "\nStack trace : " + ex.StackTrace;
        return res;
    }
});

app.Run();