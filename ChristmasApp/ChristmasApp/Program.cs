using Rzucidlo.ChristmasApp.BL;
using Rzucidlo.ChristmasApp.BL.Middleware;
using Rzucidlo.ChristmasApp.BL.Repository;
using Rzucidlo.ChristmasApp.Core.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var daoLibraryPath = builder.Configuration.GetValue<string>("DAOLibraryPath")!;

// Add services to the container.

builder.Services.AddControllers();
//    .AddNewtonsoftJson(options =>
//    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
//);
builder.Services.AddDAOServices(daoLibraryPath);
builder.Services.AddScoped<ErrorHandlingMiddleware>();
builder.Services.AddScoped<IDataRepository, DataRepository>();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "SWAGGER");
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();