using MyStore.Core.Application;
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
builder.Services.AddSingleton<IStoreApplication, StoreApplication>();
builder.Services.AddSingleton(typeof(IStoreRepository<>), typeof(StoreRepository<>));

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
