using Microsoft.EntityFrameworkCore;
using OrcamentoFamiliar.Domain.Entity;
using OrcamentoFamiliar.Infra.Persistence.Mapping;

namespace OrcamentoFamiliar.Infra.Persistence
{
    public class OrcamentoFamiliarDbContext : DbContext
    {
        //dotnet ef migrations add InitialMigration -o Persistence/Migrations
        //dotnet ef database update
        //dotnet tool install --global dotnet-ef

        public OrcamentoFamiliarDbContext(DbContextOptions<OrcamentoFamiliarDbContext> options)
            : base(options)
        {

        }

        public DbSet<Receitas> Receitas { get; set; }
        public DbSet<Despesas> Despesas { get; set; }
        public DbSet<Usuario> User { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ReceitasMapping());
            builder.ApplyConfiguration(new DespesasMapping());
            builder.ApplyConfiguration(new UsuarioMapping());
        }
    }
}
