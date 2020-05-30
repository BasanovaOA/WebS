using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FreeMedHelp.InfrastructureServices.Gateways.Database;
using Microsoft.EntityFrameworkCore;
using FreeMedHelp.ApplicationServices.GetMedPointListUseCase;
using FreeMedHelp.ApplicationServices.Ports.Gateways.Database;
using FreeMedHelp.ApplicationServices.Repositories;
using FreeMedHelp.DomainObjects.Ports;

namespace FreeMedHelp.WebService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration; -
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MedContext>(opts => 
                opts.UseSqlite($"Filename={System.IO.Path.Combine(System.Environment.CurrentDirectory, "FreeMedHelp.db")}")
            );

            services.AddScoped<IMedDatabaseGateway, MedEFSqliteGateway>();

            services.AddScoped<DbMedPointRepository>();
            services.AddScoped<IReadOnlyMedPointRepository>(x => x.GetRequiredService<DbMedPointRepository>());
            services.AddScoped<IMedPointRepository>(x => x.GetRequiredService<DbMedPointRepository>());


            services.AddScoped<IGetMedPointListUseCase, GetMedPointListUseCase>();

            
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
