using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OrcamentoFamiliar.API.AutoMapper;
using OrcamentoFamiliar.API.Persistence;
using OrcamentoFamiliar.API.Persistence.Repository;
using OrcamentoFamiliar.API.Persistence.Repository.Interfaces;
using OrcamentoFamiliar.API.Services;
using OrcamentoFamiliar.API.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var config = AutoMapperConfig.RegisterMappings();

var connectionString = builder.Configuration.GetConnectionString("Banco");
builder.Services.AddDbContext<OrcamentoFamiliarDbContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddSingleton<IMapper>(new Mapper(config));

builder.Services.AddTransient<IDespesasRepository, DespesasRepository>();
builder.Services.AddTransient<IReceitasRepository, ReceitasRepository>();

builder.Services.AddTransient<IReceitaService, ReceitaService>();
builder.Services.AddTransient<IDespesaService, DespesaService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
