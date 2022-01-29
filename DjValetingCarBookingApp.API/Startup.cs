using DjValetingCarBookingApp.API.Filters;
using DjValetingCarBookingApp.API.Middlewares;
using DjValetingCarBookingApp.Core.Repositories;
using DjValetingCarBookingApp.Core.Services;
using DjValetingCarBookingApp.Core.UnitOfWorks;
using DjValetingCarBookingApp.Repository;
using DjValetingCarBookingApp.Repository.Repositories;
using DjValetingCarBookingApp.Repository.UnitOfWorks;
using DjValetingCarBookingApp.Service.Mapping;
using DjValetingCarBookingApp.Service.Services;
using DjValetingCarBookingApp.Service.Validations;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace DjValetingCarBookingApp.API
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
            services.AddControllers(options => options.Filters.Add(new ValidateFilterAttribute()))
                .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<BookingInfoDtoValidator>())
                .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<CustomerDtoValidator>());

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DjValetingCarBookingApp.API", Version = "v1" });
            });

            services.AddScoped(typeof(NotFoundFilter<>));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped(typeof(IService<>), typeof(Service<>));

            services.AddAutoMapper(typeof(MapProfile));

            services.AddScoped<IBookingInfoRepository, BookingInfoRepository>();

            services.AddScoped<IBookingInfoService, BookingInfoService>();

            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddScoped<ICustomerService, CustomerService>();

            services.AddDbContext<AppDbContext>(x =>
            {
                x.UseSqlServer(Configuration.GetConnectionString("SqlConnection"), option =>
                {
                    option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DjValetingCarBookingApp.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCustomException();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
