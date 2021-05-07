using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AdvertisementsService.API.BLL.AutoMapper;
using AdvertisementsService.API.DAL.DataBase.Entities;
using AdvertisementsService.API.BLL.Interfaces;
using AdvertisementsService.API.BLL.Services;
using AdvertisementsService.API.DAL.Interfaces;
using AdvertisementsService.API.DAL.Repository;
using AdvertisementsService.API.DAL.DataBase.Contexts;
using Microsoft.EntityFrameworkCore;

namespace AdvertisementsService.API
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
            services.AddControllers();

            services.AddDbContext<AdvertisementContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:AdService"]));

            services.AddAutoMapper(typeof(AutoMapperProfile));

            services.AddScoped<IRepository<Advertisement, AdvertisementURI>, Repository<Advertisement, AdvertisementURI>>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IAdService, AdService>();

            services.AddMvc();
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
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=AdvertisementsController}/{action=Home}/{id?}");
            });
        }
    }
}
