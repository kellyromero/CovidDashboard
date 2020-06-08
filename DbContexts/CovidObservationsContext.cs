using CovidDashboard.Entities;
using Microsoft.EntityFrameworkCore;

namespace CovidDashboard.DbContexts
{
    public class CovidObservationsContext : DbContext
    {
        public CovidObservationsContext(DbContextOptions<CovidObservationsContext> options)
           : base(options)
        {
        }

        public DbSet<CovidObservationDatum> CovidObservationData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(Startup.ConnectionString);
    }
}