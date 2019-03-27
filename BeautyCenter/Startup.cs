using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BeautyCenter.Automapper;
using BeautyCenter.Business.Appointments;
using BeautyCenter.Business.Customers;
using BeautyCenter.Common.Infra.DataLayer;
using BeautyCenter.Data.Context;
using BeautyCenter.Data.Context.UnitOfWork;
using BeautyCenter.Data.DataService.Appointments;
using BeautyCenter.Data.DataService.Customers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using NToastNotify;

namespace BeautyCenter
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            var connection = @"Server=Tumer;Database=BeautyCenterDb;User ID=sa;Password=1234qqqQ;TrustServerCertificate=True;Trusted_Connection=False;Connection Timeout=30;Integrated Security=False;Persist Security Info=False;Encrypt=True;MultipleActiveResultSets=True;";
            services.AddDbContext<BeautyCenterContext>(options => options.UseSqlServer(connection));
            services.AddTransient<IAppointmentBusiness, AppointmentBusiness>();
            services.AddTransient<IAppointmentDataService, AppointmentDataService>();
            services.AddTransient<ICustomerBusiness, CustomerBusiness>();
            services.AddTransient<ICustomerDataService, CustomerDataService>();
            services.AddTransient<IRepository, EntityFrameworkRepository>();
            services.AddTransient<IReadOnlyRepository, EntityFrameworkReadOnlyRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IDbFactory, DbFactory>();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                    .AddJsonOptions(options =>
                                    options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            services.AddMvc().AddNToastNotifyToastr(new ToastrOptions()
            {
                PositionClass = ToastPositions.TopRight,
                ProgressBar = true,
                
            },new NToastNotifyOption() {
                DefaultSuccessTitle = "Başarılı",
                DefaultErrorTitle = "Hata"
            });

            Mapper.Initialize(cfg => cfg.AddProfile<MappingProfile>());

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseNToastNotify();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
