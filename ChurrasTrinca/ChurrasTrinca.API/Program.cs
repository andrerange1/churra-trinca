using ChurrasTrinca.Domain;
using System.Reflection;
using ChurrasTrinca.Contracts;
using ChurrasTrinca.Domain.Interfaces.Services;
using ChurrasTrinca.Domain.Interfaces.Repositories;
using ChurrasTrinca.Infra.Repository;
using ChurrasTrinca.App;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Churras Api",
        Version = "v1",
        Description = "API do Churrasco"
    });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSingleton(new AutoMapperConfig().Config().CreateMapper());

builder.Services.AddScoped<IChurrascoRepository, ChurrascoRepository>();
builder.Services.AddScoped<IChurrascoService, ChurrascoService>();
builder.Services.AddScoped<IChurrascoAppService, ChurrascoAppService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
