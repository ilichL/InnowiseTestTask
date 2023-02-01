using FridgeWarehouse.Core.DTOs;
using FridgeWarehouse.Core.Interfaces;
using FridgeWarehouse.Core.Interfaces.Data;
using FridgeWarehouse.Data;
using FridgeWarehouse.Data.Entities;
using FridgeWarehouse.DataAccess;
using FridgeWarehouse.Domain.Constats;
using FridgeWarehouse.Domain.Interfaces;
using FridsgeWarehouse.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace FridgeApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString(DatabaseConstants.DatabaseConnectionStringName);

            services.AddDbContext<Context>(opt
                => opt.UseSqlServer((connectionString), 
                x => x.MigrationsAssembly("FridgeWarehouse.Data")));//fix Context Error
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IRepository<Fridge>, Repository<Fridge>>();
            services.AddScoped<IRepository<FridgeModel>, Repository<FridgeModel>>();
            services.AddScoped<IRepository<FridgeProduct>, Repository<FridgeProduct>>();
            services.AddScoped<IRepository<Product>, Repository<Product>>();
            services.AddScoped<IFridgeService, FridgeService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IFridgeProductService, FridgeProductService>();
            services.AddScoped<IJsonSerializeService<BaseDTO>, JsonSerializeService<BaseDTO>>();
            services.AddHttpClient();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Add services to the container.

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}
