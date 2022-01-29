using DjValetingCarBookingApp.Core.Repositories;
using DjValetingCarBookingApp.Core.Services;
using DjValetingCarBookingApp.Core.UnitOfWorks;
using DjValetingCarBookingApp.Repository;
using DjValetingCarBookingApp.Repository.Repositories;
using DjValetingCarBookingApp.Repository.UnitOfWorks;
using DjValetingCarBookingApp.Service.Mapping;
using DjValetingCarBookingApp.Service.Services;
using DjValetingCarBookingApp.Service.Validations;
using DjValetingCarBookingApp.WebUI.Filters;
using DjValetingCarBookingApp.WebUI.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Reflection;

namespace DjValetingCarBookingApp.WebUI
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
            services.AddControllersWithViews()
                .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<BookingInfoDtoValidator>())
                .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<CustomerDtoValidator>());

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

            services.AddHttpClient<BookingInfoApiService>(opt =>
            {
                opt.BaseAddress = new Uri(Configuration["BaseUrl"]);
            });

            services.AddHttpClient<CustomerApiService>(opt =>
            {
                opt.BaseAddress = new Uri(Configuration["BaseUrl"]);
            });

            services.AddScoped(typeof(NotFoundFilter<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
