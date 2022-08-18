using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OrcamentoFamiliar.Application.Services;
using OrcamentoFamiliar.Application.Services.Interfaces;
using OrcamentoFamiliar.Domain.AutoMapper;
using OrcamentoFamiliar.Infra.Persistence;
using OrcamentoFamiliar.Infra.Persistence.Repository;
using OrcamentoFamiliar.Infra.Persistence.Repository.Interfaces;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var config = AutoMapperConfig.RegisterMappings();

var connectionString = builder.Configuration.GetConnectionString("Banco");
builder.Services.AddDbContext<OrcamentoFamiliarDbContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddSingleton<IMapper>(new Mapper(config));

builder.Services.AddSingleton(new TokenService(builder.Configuration));

builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<IDespesasRepository, DespesasRepository>();
builder.Services.AddTransient<IReceitasRepository, ReceitasRepository>();

builder.Services.AddTransient<IReceitaService, ReceitaService>();
builder.Services.AddTransient<IDespesaService, DespesaService>();
builder.Services.AddTransient<IResumoService, ResumoService>();

builder.Services.AddControllers();
var key = Encoding.ASCII.GetBytes(builder.Configuration.GetSection("Secret").Value);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
