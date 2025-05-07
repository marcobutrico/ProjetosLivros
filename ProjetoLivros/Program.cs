//-- Criar as models
//--Criar o Context
//--Transformar BD

using ProjetoLivros.Context;
using ProjetoLivros.Interface;
using ProjetoLivros.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LivrosContext>();
builder.Services.AddScoped<ICategoriaRepository,CategoriaRepository>();

var app = builder.Build();

//Avisa o .Net que eu tenho controladores
app.MapControllers();

// Aplica o Swagger
app.UseSwagger();
app.UseSwaggerUI(options => // Faz o Swagger abrir direto
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});


//dotnet ef migrations add Inicial
//dotnet ef database update



app.Run();
