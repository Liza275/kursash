using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SchoolBusinessLogic.BusinessLogic;
using SchoolBusinessLogic.HelperModel;
using SchoolBusinessLogic.Interface;
using SchoolDAL.Implement;
using System;

namespace SchoolEmployeeWebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            MailLogic.MailConfig(new MailConfig
            {
                SmtpClientHost = configuration["SmtpClientHost"],
                SmtpClientPort = Convert.ToInt32(configuration["SmtpClientPort"]),
                MailLogin = configuration["MailLogin"],
                MailPassword = configuration["MailPassword"],
            });
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddTransient<EmployeeLogic>();
            services.AddTransient<LessonLogic>();
            services.AddTransient<CostLogic>();
            services.AddTransient<SocietyLogic>();
            services.AddTransient<PaymentLogic>();
            services.AddTransient<ReportLogic>();
            services.AddTransient<MailLogic>();
            services.AddTransient<DiagramLogic>();

            services.AddTransient<ILessonStorage, LessonStorage>();
            services.AddTransient<IEmployeeStorage, EmployeeStorage>();
            services.AddTransient<ICostStorage, CostStorage>();
            services.AddTransient<ISocietyStorage, SocietyStorage>();
            services.AddTransient<IPaymentStorage, PaymentStorage>();
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
