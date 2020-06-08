using CovidDashboard.DbContexts;
using CovidDashboard.Helpers;
using CovidDashboard.Mappers;
using CovidDashboard.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CovidDashboard
{
    public class Startup
    {
        public static string ConnectionString { get; private set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddXmlDataContractSerializerFormatters();

            services.AddScoped<ICovidObservationsDataRepository, CovidObservationsDataRepository>();

            services.AddScoped<ICovidObservationDataMapper, CovidObservationDataMapper>();

            ConnectionString = Configuration.GetConnectionString("CovidObservationsDatabase");

            services.AddDbContext<CovidObservationsContext>(options =>
                options.UseNpgsql(ConnectionString));

            CSVSeedHelper.SeedCSVData();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {   
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}