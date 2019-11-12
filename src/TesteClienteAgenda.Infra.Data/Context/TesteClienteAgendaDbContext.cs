using System.Configuration;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using TesteClienteAgenda.Domain.Models;
using TesteClienteAgenda.Infra.CrossCutting.Helpers;
using TesteClienteAgenda.Infra.Data.EntityConfig;

namespace TesteClienteAgenda.Infra.Data.Context
{
    public class TesteClienteAgendaDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public TesteClienteAgendaDbContext(DbContextOptions<TesteClienteAgendaDbContext> options, IConfiguration configuration)
            : base(options) 
        {
            _configuration = configuration;
            ChangeTracker.AutoDetectChangesEnabled = false;
            ChangeTracker.LazyLoadingEnabled = false;
        }

        public DbSet<Cliente> Clientes { get;set; }
        public DbSet<Agenda> Agendas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteConfig());
            modelBuilder.ApplyConfiguration(new AgendaConfig());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var teste = _configuration.GetConnectionString("DefaultConnection");
                //"Data Source = (LocalDb)\\MSSQLLocalDB; AttachDbFilename =| DataDirectory |\\db_standBy.mdf; Initial Catalog = db_standBy; Integrated Security = True\" providerName=\"System.Data.SqlClient\"";
            //var teste = WebHelper.DefaultConnectionString;


            optionsBuilder.UseSqlServer(teste);
            base.OnConfiguring(optionsBuilder);
        }
    }
}