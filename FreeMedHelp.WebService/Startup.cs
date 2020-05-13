using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FreeMedHelp.ApplicationServices.GetMedPointListUseCase;
using FreeMedHelp.ApplicationServices.Repositories;
using FreeMedHelp.DomainObjects.Ports;
using FreeMedHelp.DomainObjects;
using System.Collections.Generic;

namespace FreeMedHelp.WebService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        { 
            services.AddScoped<InMemoryMedPointRepository>(x => new InMemoryMedPointRepository(
                new List<MedPoint> {
                    new MedPoint() 
                    { 
                        Id = 1, 
                        FullName = "Государственное бюджетное учреждение города Москвы «Станция скорой и неотложной медицинской помощи им. А.С. Пучкова» Департамента здравоохранения города Москвы", 
                        IsMedHelpFree = "Да", 
                      
                    },
                    new MedPoint()
                    {
                       Id = 1, 
                        FullName = "Государственное бюджетное учреждение здравоохранения города Москвы «Научно-исследовательский институт скорой помощи им. Н.В. Склифосовского Департамента здравоохранения города Москвы»", 
                        IsMedHelpFree = "Да", 
                    },
                    new MedPoint()
                    {
                        Id = 1, 
                        FullName = "Государственное бюджетное учреждение здравоохранения города Москвы «Центр патологии речи и нейрореабилитации Департамента здравоохранения города Москвы»", 
                        IsMedHelpFree = "Нет", 
                    }
            }));
            services.AddScoped<IReadOnlyMedPointRepository>(x => x.GetRequiredService<InMemoryMedPointRepository>());
            services.AddScoped<IMedPointRepository>(x => x.GetRequiredService<InMemoryMedPointRepository>());

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
