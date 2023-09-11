var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// EN LA CAPA DEL CLIENTE, LA PARTE DE LA API, DENTRO DEL PROGRAM AGREGO LOS CORS PARA PERMITIR COMUNICARME CON EL SERVER

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

