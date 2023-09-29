using BussinessLogic.Services;
using DataAccess.Repository;
using DataAccess.Entities;
using DataAccess.IRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// builder.

// ADD Entity framework con mysql

builder.Services.AddDbContext<MydbContext>(options => options.UseMySQL(builder.Configuration.GetConnectionString("dbConnection")));

//agrego la inyeccion de dependencia de los repositorios y el UnitOfWork
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<ServicePrueba>();


builder.Services.AddCors(opciones =>
{
    opciones.AddPolicy("politica", app =>
    {
        app.AllowAnyOrigin();
        app.AllowAnyHeader();
        app.AllowAnyMethod();
    });
});

var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<MydbContext>();
        context.Database.EnsureCreated();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred creating the DB.");
    }
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) 
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//habilito los cors

app.UseCors("politica");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

