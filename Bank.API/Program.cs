var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//Se agrega para utilizar controladores (envez de minimal api)
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

//Mapea los controladores a una ruta:
//ej: se crea el controlador BankController, se crea la ruta api/back
app.MapControllers();



app.Run();
