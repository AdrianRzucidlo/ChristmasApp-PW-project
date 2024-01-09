using Rzucidlo.ChristmasApp.API.Controllers;
using Rzucidlo.ChristmasApp.BL.Builders;
using Rzucidlo.ChristmasApp.BL;
using Rzucidlo.ChristmasApp.DAO.Database;
using Rzucidlo.ChristmasApp.BL.Middleware;

var builder = WebApplication.CreateBuilder(args);
var daoLibraryPath = builder.Configuration.GetValue<string>("DAOLibraryPath")!;

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
builder.Services.AddSwaggerGen();
builder.Services.AddDAOServices(daoLibraryPath);
builder.Services.AddScoped<ErrorHandlingMiddleware>();

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "SWAGGER");
    });
}

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();