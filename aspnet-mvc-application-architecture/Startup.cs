using SampleApplication.Models.Builder;
using SampleApplication.Models.Facades;
using SampleApplication.Models.Repositories;
using SampleApplication.Models.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApplication
{

    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<SampleDbContext>(options =>
                options.UseSqlServer(this.Configuration.GetConnectionString("SampleDbContext")));
            services.AddTransient<IExpenseService, ExpenseService>();
            services.AddTransient<IEmployeeFacade, ExpenseFacade>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseBrowserLink();
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Expense}/{action=Index}/{id?}");
            });
            app.UseAutoMapper();
            app.UseSeeded();
        }

    }

}
