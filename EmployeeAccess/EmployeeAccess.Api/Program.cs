using EmployeeAccess.Application;
using EmployeeAccess.Persistence;
using EmployeeAccess.Persistence.Seeds;
using System.Text.Json.Serialization;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
       .AddJsonOptions(options =>
       {
           options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
       });
builder.Services.AddOpenApi();

builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

await DataBaseSeeder.SeedAsync(app.Services);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();