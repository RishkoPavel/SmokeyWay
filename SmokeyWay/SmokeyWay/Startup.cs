using DAL.Entities;
using DAL.UnitOfWork;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SmokeyWay.Validators;

namespace SmokeyWay
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
            services.AddControllersWithViews();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

            services.AddMvc().AddFluentValidation();
            services.AddDbContext<SmokeyWayDbContext>(item => item.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<IUnitOfWork, UnitOfWork>(provider =>
               new UnitOfWork(provider.GetRequiredService<SmokeyWayDbContext>()));

            services.AddSwaggerGen();

            // Validators.
            services.AddTransient<IValidator<UserRole>, UserRoleValidator>();
            services.AddTransient<IValidator<User>, UserValidator>();
            services.AddTransient<IValidator<Table>, TableValidator>();
            services.AddTransient<IValidator<OfflineTableReservation>, OfflineTableReservationValidator>();
            services.AddTransient<IValidator<Gender>, GenderValidator>();
            services.AddTransient<IValidator<Game>, GameValidator>();
            services.AddTransient<IValidator<Employee>, EmployeeValidator>();
            services.AddTransient<IValidator<EmployeePosition>, EmployeePositionValidator>();
            services.AddTransient<IValidator<Dish>, DishValidator>();
            services.AddTransient<IValidator<DishType>, DishTypeValidator>();
            services.AddTransient<IValidator<Departament>, DepartamentValidator>();
            services.AddTransient<IValidator<GameConsoleType>, GameConsoleTypeValidator>();
            services.AddTransient<IValidator<GameConsole>, GameConsoleValidator>();
            services.AddTransient<IValidator<OnlineTableReservation>, OnlineTableResrvationValidator>();
            services.AddTransient<IValidator<Order>, OrderValidator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            loggerFactory.AddFile("Logs/mylog-{Date}.txt");

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
